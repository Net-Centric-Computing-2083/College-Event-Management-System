namespace CollegeEventManagementSystem.Forms
{
    partial class ParticipantForm
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
            this.grpParticipantDetails = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.dtpRegistrationDate = new System.Windows.Forms.DateTimePicker();
            this.lblRegistrationDate = new System.Windows.Forms.Label();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.lblStudent = new System.Windows.Forms.Label();
            this.cmbEvent = new System.Windows.Forms.ComboBox();
            this.lblEvent = new System.Windows.Forms.Label();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbFilterEvent = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvParticipants = new System.Windows.Forms.DataGridView();
            this.pnlTitle.SuspendLayout();
            this.grpParticipantDetails.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipants)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(330, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Participant Registration and Management";
            // 
            // grpParticipantDetails
            // 
            this.grpParticipantDetails.Controls.Add(this.btnClear);
            this.grpParticipantDetails.Controls.Add(this.btnDelete);
            this.grpParticipantDetails.Controls.Add(this.btnUpdate);
            this.grpParticipantDetails.Controls.Add(this.btnRegister);
            this.grpParticipantDetails.Controls.Add(this.dtpRegistrationDate);
            this.grpParticipantDetails.Controls.Add(this.lblRegistrationDate);
            this.grpParticipantDetails.Controls.Add(this.cmbStudent);
            this.grpParticipantDetails.Controls.Add(this.lblStudent);
            this.grpParticipantDetails.Controls.Add(this.cmbEvent);
            this.grpParticipantDetails.Controls.Add(this.lblEvent);
            this.grpParticipantDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpParticipantDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpParticipantDetails.ForeColor = System.Drawing.Color.FromArgb(74, 20, 140);
            this.grpParticipantDetails.Location = new System.Drawing.Point(0, 52);
            this.grpParticipantDetails.Name = "grpParticipantDetails";
            this.grpParticipantDetails.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.grpParticipantDetails.Size = new System.Drawing.Size(1024, 180);
            this.grpParticipantDetails.TabIndex = 1;
            this.grpParticipantDetails.TabStop = false;
            this.grpParticipantDetails.Text = "Participant Details";
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblEvent.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblEvent.Location = new System.Drawing.Point(20, 38);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(52, 17);
            this.lblEvent.TabIndex = 0;
            this.lblEvent.Text = "Event *";
            // 
            // cmbEvent
            // 
            this.cmbEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEvent.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbEvent.FormattingEnabled = true;
            this.cmbEvent.Location = new System.Drawing.Point(150, 35);
            this.cmbEvent.Name = "cmbEvent";
            this.cmbEvent.Size = new System.Drawing.Size(320, 25);
            this.cmbEvent.TabIndex = 1;
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblStudent.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblStudent.Location = new System.Drawing.Point(510, 38);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(62, 17);
            this.lblStudent.TabIndex = 2;
            this.lblStudent.Text = "Student *";
            // 
            // cmbStudent
            // 
            this.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudent.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbStudent.FormattingEnabled = true;
            this.cmbStudent.Location = new System.Drawing.Point(620, 35);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(320, 25);
            this.cmbStudent.TabIndex = 3;
            // 
            // lblRegistrationDate
            // 
            this.lblRegistrationDate.AutoSize = true;
            this.lblRegistrationDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblRegistrationDate.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblRegistrationDate.Location = new System.Drawing.Point(20, 78);
            this.lblRegistrationDate.Name = "lblRegistrationDate";
            this.lblRegistrationDate.Size = new System.Drawing.Size(120, 17);
            this.lblRegistrationDate.TabIndex = 4;
            this.lblRegistrationDate.Text = "Registration Date";
            // 
            // dtpRegistrationDate
            // 
            this.dtpRegistrationDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpRegistrationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRegistrationDate.Location = new System.Drawing.Point(150, 75);
            this.dtpRegistrationDate.Name = "dtpRegistrationDate";
            this.dtpRegistrationDate.Size = new System.Drawing.Size(220, 25);
            this.dtpRegistrationDate.TabIndex = 5;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(150, 125);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(110, 34);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(270, 125);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 34);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(390, 125);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 34);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(510, 125);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 34);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.btnRefresh);
            this.grpFilter.Controls.Add(this.cmbFilterEvent);
            this.grpFilter.Controls.Add(this.lblFilter);
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpFilter.ForeColor = System.Drawing.Color.FromArgb(74, 20, 140);
            this.grpFilter.Location = new System.Drawing.Point(0, 232);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.grpFilter.Size = new System.Drawing.Size(1024, 80);
            this.grpFilter.TabIndex = 2;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Participant List";
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblFilter.Location = new System.Drawing.Point(20, 36);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(120, 17);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Show event";
            // 
            // cmbFilterEvent
            // 
            this.cmbFilterEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterEvent.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbFilterEvent.FormattingEnabled = true;
            this.cmbFilterEvent.Location = new System.Drawing.Point(150, 33);
            this.cmbFilterEvent.Name = "cmbFilterEvent";
            this.cmbFilterEvent.Size = new System.Drawing.Size(320, 25);
            this.cmbFilterEvent.TabIndex = 1;
            this.cmbFilterEvent.SelectedIndexChanged += new System.EventHandler(this.cmbFilterEvent_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(490, 31);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 30);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvParticipants);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 312);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(16);
            this.pnlGrid.Size = new System.Drawing.Size(1024, 328);
            this.pnlGrid.TabIndex = 3;
            // 
            // dgvParticipants
            // 
            this.dgvParticipants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvParticipants.Location = new System.Drawing.Point(16, 16);
            this.dgvParticipants.Name = "dgvParticipants";
            this.dgvParticipants.Size = new System.Drawing.Size(992, 296);
            this.dgvParticipants.TabIndex = 0;
            this.dgvParticipants.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParticipants_CellClick);
            // 
            // ParticipantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 640);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.grpParticipantDetails);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "ParticipantForm";
            this.Text = "Participant Registration";
            this.Load += new System.EventHandler(this.ParticipantForm_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.grpParticipantDetails.ResumeLayout(false);
            this.grpParticipantDetails.PerformLayout();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipants)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpParticipantDetails;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.ComboBox cmbEvent;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.Label lblRegistrationDate;
        private System.Windows.Forms.DateTimePicker dtpRegistrationDate;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbFilterEvent;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvParticipants;
    }
}
