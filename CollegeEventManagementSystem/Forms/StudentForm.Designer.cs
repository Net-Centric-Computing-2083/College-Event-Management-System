namespace CollegeEventManagementSystem.Forms
{
    partial class StudentForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpStudentDetails = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSemester = new System.Windows.Forms.TextBox();
            this.lblSemester = new System.Windows.Forms.Label();
            this.txtProgram = new System.Windows.Forms.TextBox();
            this.lblProgram = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.pnlStudentEvents = new System.Windows.Forms.Panel();
            this.lblStudentEvents = new System.Windows.Forms.Label();
            this.dgvStudentEvents = new System.Windows.Forms.DataGridView();
            this.pnlTitle.SuspendLayout();
            this.grpStudentDetails.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.pnlStudentEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.White;
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1024, 52);
            this.pnlTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(74, 20, 140);
            this.lblTitle.Location = new System.Drawing.Point(16, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(210, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Student Registration";
            // 
            // grpStudentDetails
            // 
            this.grpStudentDetails.Controls.Add(this.btnClear);
            this.grpStudentDetails.Controls.Add(this.btnDelete);
            this.grpStudentDetails.Controls.Add(this.btnUpdate);
            this.grpStudentDetails.Controls.Add(this.btnAdd);
            this.grpStudentDetails.Controls.Add(this.txtSemester);
            this.grpStudentDetails.Controls.Add(this.lblSemester);
            this.grpStudentDetails.Controls.Add(this.txtProgram);
            this.grpStudentDetails.Controls.Add(this.lblProgram);
            this.grpStudentDetails.Controls.Add(this.txtPhone);
            this.grpStudentDetails.Controls.Add(this.lblPhone);
            this.grpStudentDetails.Controls.Add(this.txtEmail);
            this.grpStudentDetails.Controls.Add(this.lblEmail);
            this.grpStudentDetails.Controls.Add(this.txtStudentName);
            this.grpStudentDetails.Controls.Add(this.lblStudentName);
            this.grpStudentDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpStudentDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpStudentDetails.ForeColor = System.Drawing.Color.FromArgb(74, 20, 140);
            this.grpStudentDetails.Location = new System.Drawing.Point(0, 52);
            this.grpStudentDetails.Name = "grpStudentDetails";
            this.grpStudentDetails.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.grpStudentDetails.Size = new System.Drawing.Size(1024, 220);
            this.grpStudentDetails.TabIndex = 1;
            this.grpStudentDetails.TabStop = false;
            this.grpStudentDetails.Text = "Student Details";
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblStudentName.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblStudentName.Location = new System.Drawing.Point(20, 38);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(102, 17);
            this.lblStudentName.TabIndex = 0;
            this.lblStudentName.Text = "Student Name *";
            // 
            // txtStudentName
            // 
            this.txtStudentName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtStudentName.Location = new System.Drawing.Point(150, 35);
            this.txtStudentName.MaxLength = 100;
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(280, 25);
            this.txtStudentName.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblEmail.Location = new System.Drawing.Point(460, 38);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(60, 17);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email *";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtEmail.Location = new System.Drawing.Point(560, 35);
            this.txtEmail.MaxLength = 150;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 25);
            this.txtEmail.TabIndex = 3;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblPhone.Location = new System.Drawing.Point(20, 78);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(46, 17);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "Phone";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPhone.Location = new System.Drawing.Point(150, 75);
            this.txtPhone.MaxLength = 20;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(280, 25);
            this.txtPhone.TabIndex = 5;
            // 
            // lblProgram
            // 
            this.lblProgram.AutoSize = true;
            this.lblProgram.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblProgram.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblProgram.Location = new System.Drawing.Point(460, 78);
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Size = new System.Drawing.Size(60, 17);
            this.lblProgram.TabIndex = 6;
            this.lblProgram.Text = "Program";
            // 
            // txtProgram
            // 
            this.txtProgram.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtProgram.Location = new System.Drawing.Point(560, 75);
            this.txtProgram.MaxLength = 100;
            this.txtProgram.Name = "txtProgram";
            this.txtProgram.Size = new System.Drawing.Size(300, 25);
            this.txtProgram.TabIndex = 7;
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSemester.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblSemester.Location = new System.Drawing.Point(20, 118);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(102, 17);
            this.lblSemester.TabIndex = 8;
            this.lblSemester.Text = "Semester (1-8)";
            // 
            // txtSemester
            // 
            this.txtSemester.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSemester.Location = new System.Drawing.Point(150, 115);
            this.txtSemester.MaxLength = 2;
            this.txtSemester.Name = "txtSemester";
            this.txtSemester.Size = new System.Drawing.Size(120, 25);
            this.txtSemester.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(150, 165);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 34);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Register";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(270, 165);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 34);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(390, 165);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 34);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(510, 165);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 34);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.btnShowAll);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Controls.Add(this.lblSearch);
            this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpSearch.ForeColor = System.Drawing.Color.FromArgb(74, 20, 140);
            this.grpSearch.Location = new System.Drawing.Point(0, 272);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.grpSearch.Size = new System.Drawing.Size(1024, 80);
            this.grpSearch.TabIndex = 2;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search Students";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblSearch.Location = new System.Drawing.Point(20, 36);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(120, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Name or Email";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSearch.Location = new System.Drawing.Point(150, 33);
            this.txtSearch.MaxLength = 100;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(280, 25);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(450, 31);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(570, 31);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(110, 30);
            this.btnShowAll.TabIndex = 3;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvStudents);
            this.pnlGrid.Controls.Add(this.pnlStudentEvents);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 352);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(16);
            this.pnlGrid.Size = new System.Drawing.Size(1024, 288);
            this.pnlGrid.TabIndex = 3;
            // 
            // dgvStudents
            // 
            this.dgvStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudents.Location = new System.Drawing.Point(16, 16);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.Size = new System.Drawing.Size(992, 256);
            this.dgvStudents.TabIndex = 0;
            this.dgvStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudents_CellClick);
            // 
            // pnlStudentEvents
            // 
            this.pnlStudentEvents.Controls.Add(this.dgvStudentEvents);
            this.pnlStudentEvents.Controls.Add(this.lblStudentEvents);
            this.pnlStudentEvents.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlStudentEvents.Location = new System.Drawing.Point(592, 16);
            this.pnlStudentEvents.Name = "pnlStudentEvents";
            this.pnlStudentEvents.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.pnlStudentEvents.Size = new System.Drawing.Size(416, 256);
            this.pnlStudentEvents.TabIndex = 1;
            // 
            // lblStudentEvents
            // 
            this.lblStudentEvents.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStudentEvents.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStudentEvents.ForeColor = System.Drawing.Color.FromArgb(74, 20, 140);
            this.lblStudentEvents.Location = new System.Drawing.Point(12, 0);
            this.lblStudentEvents.Name = "lblStudentEvents";
            this.lblStudentEvents.Size = new System.Drawing.Size(404, 28);
            this.lblStudentEvents.TabIndex = 0;
            this.lblStudentEvents.Text = "Events Participated (select a student)";
            this.lblStudentEvents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvStudentEvents
            // 
            this.dgvStudentEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudentEvents.Location = new System.Drawing.Point(12, 28);
            this.dgvStudentEvents.Name = "dgvStudentEvents";
            this.dgvStudentEvents.Size = new System.Drawing.Size(404, 228);
            this.dgvStudentEvents.TabIndex = 1;
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 640);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpStudentDetails);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "StudentForm";
            this.Text = "Student Registration";
            this.Load += new System.EventHandler(this.StudentForm_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.grpStudentDetails.ResumeLayout(false);
            this.grpStudentDetails.PerformLayout();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.pnlStudentEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentEvents)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpStudentDetails;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblProgram;
        private System.Windows.Forms.TextBox txtProgram;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.TextBox txtSemester;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Panel pnlStudentEvents;
        private System.Windows.Forms.Label lblStudentEvents;
        private System.Windows.Forms.DataGridView dgvStudentEvents;
    }
}
