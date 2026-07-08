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
            ApplyModernStyling();
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

        private void ApplyModernStyling()
        {
            // Form properties
            this.BackColor = Color.FromArgb(249, 250, 251); // Gray 50
            this.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
            this.ClientSize = new Size(580, 520); // Resize form to a clean dialog size

            // Re-layout controls manually for modern aesthetics
            formLayout.Location = new Point(20, 20);
            formLayout.Size = new Size(540, 380);
            formLayout.ColumnCount = 2;
            formLayout.RowCount = 5;

            // Reset RowStyles and ColumnStyles for neat padding
            formLayout.ColumnStyles.Clear();
            formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            formLayout.RowStyles.Clear();
            for (int i = 0; i < 5; i++)
            {
                formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            }

            // Style labels
            Label[] labels = { lblFirstName, lblLastName, lblEmail, lblSalary, lblDepartment };
            foreach (var lbl in labels)
            {
                lbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                lbl.ForeColor = Color.FromArgb(55, 65, 81); // Gray 700
                lbl.Anchor = AnchorStyles.Left;
                lbl.Margin = new Padding(0, 0, 10, 0);
            }

            // Style inputs
            TextBox[] textBoxes = { txtFirstName, txtLastName, txtEmail, txtSalary };
            foreach (var txt in textBoxes)
            {
                txt.Font = new Font("Segoe UI", 11F);
                txt.Width = 350;
                txt.Anchor = AnchorStyles.Left;
                txt.Margin = new Padding(0);
            }

            cmbDepartment.Font = new Font("Segoe UI", 11F);
            cmbDepartment.Width = 350;
            cmbDepartment.Anchor = AnchorStyles.Left;
            cmbDepartment.Margin = new Padding(0);

            // Position & style action buttons
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.BackColor = Color.FromArgb(16, 185, 129); // Emerald Green
            btnSave.ForeColor = Color.White;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.Size = new Size(110, 38);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Location = new Point(this.ClientSize.Width - 260, this.ClientSize.Height - 65);

            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 1;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219); // Gray 300
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = Color.FromArgb(75, 85, 99); // Gray 600
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.Size = new Size(110, 38);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Location = new Point(this.ClientSize.Width - 130, this.ClientSize.Height - 65);
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
