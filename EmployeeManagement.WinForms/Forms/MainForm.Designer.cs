namespace EmployeeManagement.WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlTop = new Panel();
            labelTitle = new Label();
            pnlToolbar = new Panel();
            txtSearch = new MaskedTextBox();
            lblSearch = new Label();
            dgvEmployees = new DataGridView();
            pnlBottom = new Panel();
            btnViewDetails = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            First_Name = new DataGridViewTextBoxColumn();
            Last_Name = new DataGridViewTextBoxColumn();
            Department_Name = new DataGridViewTextBoxColumn();
            pnlTop.SuspendLayout();
            pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(labelTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1408, 70);
            pnlTop.TabIndex = 0;
            pnlTop.Paint += pnlTop_Paint_1;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Impact", 24F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            labelTitle.Location = new Point(12, 9);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(424, 39);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Employee Management System";
            labelTitle.Click += btnEdit_Click;
            // 
            // pnlToolbar
            // 
            pnlToolbar.Controls.Add(txtSearch);
            pnlToolbar.Controls.Add(lblSearch);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 70);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(1408, 60);
            pnlToolbar.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(99, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(300, 23);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Cambria", 14.25F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblSearch.Location = new Point(15, 18);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(69, 22);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search";
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowDrop = true;
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.AllowUserToOrderColumns = true;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.BackgroundColor = Color.FromArgb(224, 224, 224);
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Columns.AddRange(new DataGridViewColumn[] { First_Name, Last_Name, Department_Name });
            dgvEmployees.Dock = DockStyle.Fill;
            dgvEmployees.EditMode = DataGridViewEditMode.EditOnF2;
            dgvEmployees.Location = new Point(0, 130);
            dgvEmployees.MultiSelect = false;
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(1408, 482);
            dgvEmployees.TabIndex = 2;
            dgvEmployees.CellContentClick += dgvEmployees_CellContentClick;
            // 
            // pnlBottom
            // 
            pnlBottom.Controls.Add(btnViewDetails);
            pnlBottom.Controls.Add(btnDelete);
            pnlBottom.Controls.Add(btnEdit);
            pnlBottom.Controls.Add(btnAdd);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 612);
            pnlBottom.Margin = new Padding(3, 2, 3, 2);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(1408, 94);
            pnlBottom.TabIndex = 3;
            pnlBottom.Paint += panel1_Paint;
            // 
            // btnViewDetails
            // 
            btnViewDetails.BackColor = Color.DarkOrange;
            btnViewDetails.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewDetails.Location = new Point(514, 20);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(140, 63);
            btnViewDetails.TabIndex = 3;
            btnViewDetails.Text = "View Details";
            btnViewDetails.UseVisualStyleBackColor = false;
            btnViewDetails.Click += btnViewDetails_click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(348, 19);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(149, 64);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Yellow;
            btnEdit.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.Location = new Point(181, 19);
            btnEdit.Margin = new Padding(3, 2, 3, 2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(152, 64);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Green;
            btnAdd.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(12, 19);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(152, 64);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // First_Name
            // 
            First_Name.DataPropertyName = "FirstName";
            First_Name.HeaderText = "First Name";
            First_Name.Name = "First_Name";
            First_Name.ReadOnly = true;
            // 
            // Last_Name
            // 
            Last_Name.DataPropertyName = "LastName";
            Last_Name.HeaderText = "Last Name";
            Last_Name.Name = "Last_Name";
            Last_Name.ReadOnly = true;
            // 
            // Department_Name
            // 
            Department_Name.DataPropertyName = "DepartmentName";
            Department_Name.HeaderText = "Department";
            Department_Name.Name = "Department_Name";
            Department_Name.ReadOnly = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1408, 706);
            Controls.Add(dgvEmployees);
            Controls.Add(pnlBottom);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlTop);
            Location = new Point(90, 18);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employee Management System";
            WindowState = FormWindowState.Maximized;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label labelTitle;
        private Panel pnlToolbar;
        private MaskedTextBox txtSearch;
        private Label lblSearch;
        private DataGridView dgvEmployees;
        private Panel pnlBottom;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
        private Button btnViewDetails;
        private DataGridViewTextBoxColumn First_Name;
        private DataGridViewTextBoxColumn Last_Name;
        private DataGridViewTextBoxColumn Department_Name;
    }
}
