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
            ConfigureDataGridView();
            await LoadEmployees();
        }

        private void ConfigureDataGridView()
        {
            // IMPORTANT: Disable auto-generation of columns - only use designer-defined columns
            dgvEmployees.AutoGenerateColumns = false;

            // Set column header styling
            dgvEmployees.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dgvEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 15, FontStyle.Bold);
            dgvEmployees.ColumnHeadersHeight = 30;

            // Alternate row colors for better readability
            dgvEmployees.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvEmployees.DefaultCellStyle.BackColor = Color.White;
            dgvEmployees.DefaultCellStyle.Font = new Font("Arial", 15);

            // Row height
            dgvEmployees.RowTemplate.Height = 40;


        }


        private async void btnEdit_Click(object sender, EventArgs e)
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

        private void btnViewDetails_click(object sender, EventArgs e)
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

            var window = new EmployeeDetailsWindow(employee);

            window.WindowState = System.Windows.WindowState.Maximized;

            window.ShowDialog();

            Show();

            Activate();
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
        }

        private void pnlTop_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }

}
