namespace EmployeeManagement.WinForms.Forms
{
    partial class EmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            lblLastName = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtSalary = new TextBox();
            lblSalary = new Label();
            lblDepartment = new Label();
            cmbDepartment = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            formLayout = new TableLayoutPanel();
            formLayout.SuspendLayout();
            SuspendLayout();
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFirstName.Location = new Point(3, 0);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(137, 32);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "First Name";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(395, 3);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(265, 23);
            txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(395, 74);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(265, 23);
            txtLastName.TabIndex = 3;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLastName.Location = new Point(3, 71);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(133, 32);
            lblLastName.TabIndex = 2;
            lblLastName.Text = "Last Name";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(395, 152);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(265, 23);
            txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(3, 149);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(76, 32);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email";
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(395, 225);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(265, 23);
            txtSalary.TabIndex = 7;
            // 
            // lblSalary
            // 
            lblSalary.AutoSize = true;
            lblSalary.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSalary.Location = new Point(3, 222);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(84, 32);
            lblSalary.TabIndex = 6;
            lblSalary.Text = "Salary";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDepartment.Location = new Point(3, 300);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(152, 32);
            lblDepartment.TabIndex = 8;
            lblDepartment.Text = "Department";
            // 
            // cmbDepartment
            // 
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(395, 303);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(265, 23);
            cmbDepartment.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 384);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(136, 384);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // formLayout
            // 
            formLayout.ColumnCount = 2;
            formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            formLayout.Controls.Add(txtFirstName, 1, 0);
            formLayout.Controls.Add(txtLastName, 1, 1);
            formLayout.Controls.Add(lblFirstName, 0, 0);
            formLayout.Controls.Add(lblDepartment, 0, 4);
            formLayout.Controls.Add(lblSalary, 0, 3);
            formLayout.Controls.Add(txtEmail, 1, 2);
            formLayout.Controls.Add(lblEmail, 0, 2);
            formLayout.Controls.Add(txtSalary, 1, 3);
            formLayout.Controls.Add(lblLastName, 0, 1);
            formLayout.Controls.Add(cmbDepartment, 1, 4);
            formLayout.Location = new Point(3, 4);
            formLayout.Name = "formLayout";
            formLayout.RowCount = 5;
            formLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 47.65101F));
            formLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 52.34899F));
            formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 73F));
            formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 78F));
            formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 73F));
            formLayout.Size = new Size(785, 374);
            formLayout.TabIndex = 12;
            // 
            // EmployeeForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(formLayout);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EmployeeForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Employee";
            Load += EmployeeForm_Load;
            formLayout.ResumeLayout(false);
            formLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblFirstName;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private Label lblLastName;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtSalary;
        private Label lblSalary;
        private Label lblDepartment;
        private ComboBox cmbDepartment;
        private Button btnSave;
        private Button btnCancel;
        private TableLayoutPanel formLayout;
    }
}