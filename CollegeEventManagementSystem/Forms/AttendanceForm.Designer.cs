namespace CollegeEventManagementSystem.Forms
{
    partial class AttendanceForm
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
            this.grpAttendanceDetails = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dtpAttendanceDate = new System.Windows.Forms.DateTimePicker();
            this.lblAttendanceDate = new System.Windows.Forms.Label();
            this.cmbParticipant = new System.Windows.Forms.ComboBox();
            this.lblParticipant = new System.Windows.Forms.Label();
            this.cmbEvent = new System.Windows.Forms.ComboBox();
            this.lblEvent = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvAttendance = new System.Windows.Forms.DataGridView();
            this.pnlTitle.SuspendLayout();
            this.grpAttendanceDetails.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(240, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Attendance Management";
            // 
            // grpAttendanceDetails
            // 
            this.grpAttendanceDetails.Controls.Add(this.btnClear);
            this.grpAttendanceDetails.Controls.Add(this.btnDelete);
            this.grpAttendanceDetails.Controls.Add(this.btnUpdate);
            this.grpAttendanceDetails.Controls.Add(this.btnSave);
            this.grpAttendanceDetails.Controls.Add(this.cmbStatus);
            this.grpAttendanceDetails.Controls.Add(this.lblStatus);
            this.grpAttendanceDetails.Controls.Add(this.dtpAttendanceDate);
            this.grpAttendanceDetails.Controls.Add(this.lblAttendanceDate);
            this.grpAttendanceDetails.Controls.Add(this.cmbParticipant);
            this.grpAttendanceDetails.Controls.Add(this.lblParticipant);
            this.grpAttendanceDetails.Controls.Add(this.cmbEvent);
            this.grpAttendanceDetails.Controls.Add(this.lblEvent);
            this.grpAttendanceDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAttendanceDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpAttendanceDetails.ForeColor = System.Drawing.Color.FromArgb(74, 20, 140);
            this.grpAttendanceDetails.Location = new System.Drawing.Point(0, 52);
            this.grpAttendanceDetails.Name = "grpAttendanceDetails";
            this.grpAttendanceDetails.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.grpAttendanceDetails.Size = new System.Drawing.Size(1024, 180);
            this.grpAttendanceDetails.TabIndex = 1;
            this.grpAttendanceDetails.TabStop = false;
            this.grpAttendanceDetails.Text = "Attendance Details";
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
            this.cmbEvent.SelectedIndexChanged += new System.EventHandler(this.cmbEvent_SelectedIndexChanged);
            // 
            // lblParticipant
            // 
            this.lblParticipant.AutoSize = true;
            this.lblParticipant.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblParticipant.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblParticipant.Location = new System.Drawing.Point(510, 38);
            this.lblParticipant.Name = "lblParticipant";
            this.lblParticipant.Size = new System.Drawing.Size(82, 17);
            this.lblParticipant.TabIndex = 2;
            this.lblParticipant.Text = "Participant *";
            // 
            // cmbParticipant
            // 
            this.cmbParticipant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParticipant.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbParticipant.FormattingEnabled = true;
            this.cmbParticipant.Location = new System.Drawing.Point(620, 35);
            this.cmbParticipant.Name = "cmbParticipant";
            this.cmbParticipant.Size = new System.Drawing.Size(320, 25);
            this.cmbParticipant.TabIndex = 3;
            // 
            // lblAttendanceDate
            // 
            this.lblAttendanceDate.AutoSize = true;
            this.lblAttendanceDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblAttendanceDate.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblAttendanceDate.Location = new System.Drawing.Point(20, 78);
            this.lblAttendanceDate.Name = "lblAttendanceDate";
            this.lblAttendanceDate.Size = new System.Drawing.Size(120, 17);
            this.lblAttendanceDate.TabIndex = 4;
            this.lblAttendanceDate.Text = "Attendance Date";
            // 
            // dtpAttendanceDate
            // 
            this.dtpAttendanceDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpAttendanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAttendanceDate.Location = new System.Drawing.Point(150, 75);
            this.dtpAttendanceDate.Name = "dtpAttendanceDate";
            this.dtpAttendanceDate.Size = new System.Drawing.Size(220, 25);
            this.dtpAttendanceDate.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblStatus.Location = new System.Drawing.Point(510, 78);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 17);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status *";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Present",
            "Absent"});
            this.cmbStatus.Location = new System.Drawing.Point(620, 75);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(180, 25);
            this.cmbStatus.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(150, 125);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 34);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(270, 125);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 34);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(390, 125);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 34);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(510, 125);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 34);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvAttendance);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 232);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(16);
            this.pnlGrid.Size = new System.Drawing.Size(1024, 408);
            this.pnlGrid.TabIndex = 2;
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttendance.Location = new System.Drawing.Point(16, 16);
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.Size = new System.Drawing.Size(992, 376);
            this.dgvAttendance.TabIndex = 0;
            this.dgvAttendance.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttendance_CellClick);
            // 
            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 640);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.grpAttendanceDetails);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "AttendanceForm";
            this.Text = "Attendance";
            this.Load += new System.EventHandler(this.AttendanceForm_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.grpAttendanceDetails.ResumeLayout(false);
            this.grpAttendanceDetails.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpAttendanceDetails;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.ComboBox cmbEvent;
        private System.Windows.Forms.Label lblParticipant;
        private System.Windows.Forms.ComboBox cmbParticipant;
        private System.Windows.Forms.Label lblAttendanceDate;
        private System.Windows.Forms.DateTimePicker dtpAttendanceDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvAttendance;
    }
}
