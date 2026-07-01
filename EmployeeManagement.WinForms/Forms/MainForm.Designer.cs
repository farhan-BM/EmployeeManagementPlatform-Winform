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
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            pnlTop.SuspendLayout();
            pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = SystemColors.Control;
            pnlTop.Controls.Add(labelTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1408, 70);
            pnlTop.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold);
            labelTitle.Location = new Point(20, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(379, 32);
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
            txtSearch.Location = new Point(90, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(300, 23);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(20, 20);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(42, 15);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search";
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Dock = DockStyle.Fill;
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
            // btnDelete
            // 
            btnDelete.Location = new Point(292, 19);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(107, 22);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete_Employee";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(168, 19);
            btnEdit.Margin = new Padding(3, 2, 3, 2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(104, 22);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit_Employee";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(42, 19);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(106, 22);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add_Employee";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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
    }
}
