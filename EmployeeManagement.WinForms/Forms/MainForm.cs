using EmployeeManagement.Core.DTOs.Employee;
using EmployeeManagement.WinForms.Forms;
using EmployeeManagement.WinForms.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.WinForms
{
    public partial class MainForm : Form
    {
        private readonly EmployeeService _employeeService;
        private readonly EmployeeForm _employeeForm;
        private readonly IServiceProvider _serviceProvider;
        private List<EmployeeDto> _employees = [];


        public MainForm(EmployeeService employeeService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _employeeService = employeeService;
            _serviceProvider = serviceProvider;

            Load += MainForm_Load;
        }

        private async void MainForm_Load(object? sender, EventArgs e)
        {
            await LoadEmployees();


            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.AllowUserToResizeRows = false;
            dgvEmployees.ReadOnly = true;
            dgvEmployees.MultiSelect = false;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            dgvEmployees.Columns["Id"].HeaderText = "ID";
            dgvEmployees.Columns["FirstName"].HeaderText = "First Name";
            dgvEmployees.Columns["LastName"].HeaderText = "Last Name";
            dgvEmployees.Columns["Email"].HeaderText = "Email";
            dgvEmployees.Columns["Salary"].HeaderText = "Salary";
            dgvEmployees.Columns["DepartmentName"].HeaderText = "Department";

            dgvEmployees.Columns["Salary"].DefaultCellStyle.Format = "N2";

        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            var employeeId = GetSelectedEmployeeId();

            if (employeeId == null)
            {
                MessageBox.Show("Please select an employee.");
                return;
            }

            using var employeeForm = _serviceProvider.GetRequiredService<EmployeeForm>();

            employeeForm.EmployeeId = employeeId;

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
            var employeeId = GetSelectedEmployeeId();

            if (employeeId == null)
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

            var success = await _employeeService.DeleteEmployeeAsync(employeeId.Value);

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

            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = _employees;

            dgvEmployees.ClearSelection();
        }


        private int? GetSelectedEmployeeId()
        {
            if (dgvEmployees.SelectedRows.Count == 0)
                return null;

            return Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["Id"].Value);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var keyword = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvEmployees.DataSource = null;
                dgvEmployees.DataSource = _employees;
                return;
            }

            var filteredEmployees = _employees
                .Where(e =>
                    e.FirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    e.LastName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    e.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    e.DepartmentName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();

            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = filteredEmployees;
        }
    }
}
