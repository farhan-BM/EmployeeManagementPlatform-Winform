using EmployeeManagement.Core.DTOs.Employee;
using EmployeeManagement.WinForms.Forms;
using EmployeeManagement.WinForms.Services;
using Microsoft.Extensions.DependencyInjection;
using EmployeeManagement.WPF.Views.Windows;

namespace EmployeeManagement.WinForms
{
    public partial class MainForm : Form
    {
        private readonly EmployeeService _employeeService;
        private readonly EmployeeForm _employeeForm;
        private readonly IServiceProvider _serviceProvider;
        private List<EmployeeDto> _employees = [];
        private string _currentSearchFilter = string.Empty;


        public MainForm(EmployeeService employeeService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _employeeService = employeeService;
            _serviceProvider = serviceProvider;

            Load += MainForm_Load;
        }

        private async void MainForm_Load(object? sender, EventArgs e)
        {
            ApplyModernStyling();
            ConfigureDataGridView();
            await LoadEmployees();
        }

        private void ApplyModernStyling()
        {
            // Form properties
            this.BackColor = Color.FromArgb(249, 250, 251); // Gray 50
            
            // Header panel styling
            pnlTop.BackColor = Color.FromArgb(37, 99, 235); // Blue 600
            pnlTop.Height = 80;
            
            labelTitle.ForeColor = Color.White;
            labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelTitle.Location = new Point(20, (pnlTop.Height - labelTitle.Height) / 2);
            labelTitle.Click -= btnEdit_Click; // Unhook click that edit trigger (was configured strangely in designer)
            labelTitle.Click += (s, e) => {}; 

            // Search bar / Toolbar styling
            pnlToolbar.BackColor = Color.FromArgb(243, 244, 246); // Gray 100
            pnlToolbar.Height = 60;
            
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(75, 85, 99); // Gray 600
            lblSearch.Text = "Search:";
            lblSearch.Location = new Point(20, (pnlToolbar.Height - lblSearch.Height) / 2);
            lblSearch.SendToBack();

            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(lblSearch.Right + 10, (pnlToolbar.Height - txtSearch.Height) / 2);
            txtSearch.Size = new Size(350, txtSearch.Height);
            
            // Bottom Action buttons styling
            pnlBottom.BackColor = Color.FromArgb(243, 244, 246); // Gray 100
            pnlBottom.Height = 80;

            StyleActionButton(btnAdd, Color.FromArgb(16, 185, 129)); // Emerald Green
            StyleActionButton(btnEdit, Color.FromArgb(59, 130, 246)); // Blue
            StyleActionButton(btnViewDetails, Color.FromArgb(245, 158, 11)); // Amber
            StyleActionButton(btnDelete, Color.FromArgb(239, 68, 68)); // Red

            // Position bottom buttons with proper alignment/margins
            int buttonGap = 15;
            int currentLeft = 20;
            Button[] buttons = { btnAdd, btnEdit, btnViewDetails, btnDelete };
            foreach (var btn in buttons)
            {
                btn.Location = new Point(currentLeft, (pnlBottom.Height - btn.Height) / 2);
                currentLeft += btn.Width + buttonGap;
            }
        }

        private void StyleActionButton(Button button, Color backColor)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = backColor;
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button.Size = new Size(130, 42);
            button.Cursor = Cursors.Hand;
        }

        private void ConfigureDataGridView()
        {
            dgvEmployees.AutoGenerateColumns = false;
            dgvEmployees.BorderStyle = BorderStyle.None;
            dgvEmployees.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEmployees.GridColor = Color.FromArgb(229, 231, 235); // Gray 200

            // Header styling
            dgvEmployees.EnableHeadersVisualStyles = false;
            dgvEmployees.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(17, 24, 39); // Gray 900
            dgvEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvEmployees.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEmployees.ColumnHeadersHeight = 45;

            // Row styling
            dgvEmployees.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251); // Gray 50
            dgvEmployees.DefaultCellStyle.BackColor = Color.White;
            dgvEmployees.DefaultCellStyle.ForeColor = Color.FromArgb(55, 65, 81); // Gray 700
            dgvEmployees.DefaultCellStyle.Font = new Font("Segoe UI", 10.5F);
            dgvEmployees.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254); // Blue 100
            dgvEmployees.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 58, 138); // Blue 900

            // Row height
            dgvEmployees.RowTemplate.Height = 40;
        }


        private async void btnEdit_Click(object? sender, EventArgs e)
        {
            var employee = GetSelectedEmployee();

            if (employee == null)
            {
                MessageBox.Show("Please select an employee.");
                return;
            }

            using var employeeForm = _serviceProvider.GetRequiredService<EmployeeForm>();

            employeeForm.EmployeeId = employee.Id;

            if (employeeForm.ShowDialog() == DialogResult.OK)
            {
                await LoadEmployees();
            }
        }

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var employee = GetSelectedEmployee();

            if (employee == null)
            {
                MessageBox.Show(
                    "Please select an employee.",
                    "Delete Employee",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var result = MessageBox.Show(
                "Are you sure you want to delete this employee?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            var success = await _employeeService.DeleteEmployeeAsync(employee.Id);

            if (success)
            {
                MessageBox.Show(
                    "Employee deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadEmployees();
            }
            else
            {
                MessageBox.Show(
                    "Unable to delete employee.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using var employeeForm = _serviceProvider.GetRequiredService<EmployeeForm>();

            if (employeeForm.ShowDialog() == DialogResult.OK)
            {
                await LoadEmployees();
            }

        }
        private async Task LoadEmployees()
        {
            _employees = await _employeeService.GetEmployeesAsync() ?? new List<EmployeeDto>();
            ApplyFilters();
            dgvEmployees.ClearSelection();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _currentSearchFilter = txtSearch.Text.Trim();
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            var filtered = _employees.AsEnumerable();

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(_currentSearchFilter))
            {
                filtered = filtered.Where(e =>
                    e.FirstName.Contains(_currentSearchFilter, StringComparison.OrdinalIgnoreCase) ||
                    e.LastName.Contains(_currentSearchFilter, StringComparison.OrdinalIgnoreCase) ||
                    e.Email.Contains(_currentSearchFilter, StringComparison.OrdinalIgnoreCase) ||
                    e.DepartmentName.Contains(_currentSearchFilter, StringComparison.OrdinalIgnoreCase));
            }

            // Bind filtered data
            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = filtered.ToList();
        }

        private EmployeeDto? GetSelectedEmployee()
        {
            if (dgvEmployees.SelectedRows.Count == 0)
                return null;

            return dgvEmployees.SelectedRows[0].DataBoundItem as EmployeeDto;
        }

        private async void btnViewDetails_click(object sender, EventArgs e)
        {
            var employee = GetSelectedEmployee();

            if (employee == null)
            {
                MessageBox.Show(
                    "Please select an employee.",
                    "View Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            Hide();

            var wpfDeptService = _serviceProvider.GetRequiredService<EmployeeManagement.WPF.Services.DepartmentService>();
            var wpfEmpService = _serviceProvider.GetRequiredService<EmployeeManagement.WPF.Services.EmployeeService>();
            var window = new EmployeeDetailsWindow(employee, wpfDeptService, wpfEmpService);

            window.WindowState = System.Windows.WindowState.Maximized;

            var dialogResult = window.ShowDialog();

            Show();

            Activate();

            if (dialogResult == true)
            {
                await LoadEmployees();
            }
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
        }

        private void pnlTop_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }

}
