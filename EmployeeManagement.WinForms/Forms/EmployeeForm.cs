using EmployeeManagement.Core.DTOs.Employee;
using EmployeeManagement.WinForms.Services;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EmployeeManagement.WinForms.Forms
{



    public partial class EmployeeForm : Form
    {
        private readonly DepartmentService _departmentService;
        private readonly EmployeeService _employeeService;
        public int? EmployeeId { get; set; }

        public EmployeeForm(DepartmentService departmentService,EmployeeService employeeService)
        {
            InitializeComponent();
            _departmentService = departmentService;
            _employeeService = employeeService;
            Load += EmployeeForm_Load;
        }

        private async void EmployeeForm_Load(object? sender, EventArgs e)
        {
            await LoadDepartments();

            if(EmployeeId == null)
            {
                Text = "Add Employee";
            } else
            {
                Text = "Edit Employee";
                await LoadEmployee();
            }
        }

        private async Task LoadDepartments()
        {
            var departments = await _departmentService.GetDepartmentsAsync();

            if (departments == null)
                return;

            cmbDepartment.DataSource = departments;

            cmbDepartment.DisplayMember = "Name";

            cmbDepartment.ValueMember = "Id";
        }

        private async Task LoadEmployee()
        {
            if (EmployeeId == null)
                return;

            var employee = await _employeeService.GetEmployeeByIdAsync(EmployeeId.Value);

            if (employee == null)
                return;

            txtFirstName.Text = employee.FirstName;
            txtLastName.Text = employee.LastName;
            txtEmail.Text = employee.Email;
            txtSalary.Text = employee.Salary.ToString();

            cmbDepartment.SelectedValue = employee.DepartmentId;
        }

        private CreateEmployeeDto GetCreateEmployeeDto()
        {
            return new CreateEmployeeDto
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Salary = decimal.Parse(txtSalary.Text),
                DepartmentId = (int)cmbDepartment.SelectedValue
            };
        }

        private UpdateEmployeeDto GetUpdateEmployeeDto()
        {
            return new UpdateEmployeeDto
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Salary = decimal.Parse(txtSalary.Text),
                DepartmentId = (int)cmbDepartment.SelectedValue
            };
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.");
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required.");
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.");
                txtEmail.Focus();
                return false;
            }

            try
            {
                var mail = new MailAddress(txtEmail.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a valid email address.");
                txtEmail.Focus();
                return false;
            }

            if (!decimal.TryParse(txtSalary.Text, out _))
            {
                MessageBox.Show("Enter a valid salary.");
                txtSalary.Focus();
                return false;
            }

            if (cmbDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("Select a department.");
                cmbDepartment.Focus();
                return false;
            }

            return true;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            bool success;

            if (EmployeeId == null)
            {
                var employee = GetCreateEmployeeDto();

                success = await _employeeService.CreateEmployeeAsync(employee);
            }
            else
            {
                var employee = GetUpdateEmployeeDto();

                success = await _employeeService.UpdateEmployeeAsync(EmployeeId.Value, employee);
            }

            if (success)
            {
                MessageBox.Show("Employee saved successfully.");

                DialogResult = DialogResult.OK;

                Close();
            }
            else
            {
                MessageBox.Show("Unable to save employee.");
            }
        }






    }
}
