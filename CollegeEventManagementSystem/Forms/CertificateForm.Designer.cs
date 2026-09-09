namespace CollegeEventManagementSystem.Forms
{
    partial class CertificateForm
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
            this.grpCertificateDetails = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dtpIssueDate = new System.Windows.Forms.DateTimePicker();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.cmbCertificateType = new System.Windows.Forms.ComboBox();
            this.lblCertificateType = new System.Windows.Forms.Label();
            this.txtCertificateNo = new System.Windows.Forms.TextBox();
            this.lblCertificateNo = new System.Windows.Forms.Label();
            this.cmbParticipant = new System.Windows.Forms.ComboBox();
            this.lblParticipant = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvCertificates = new System.Windows.Forms.DataGridView();
            this.pnlTitle.SuspendLayout();
            this.grpCertificateDetails.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCertificates)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(200, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Certificate Records";
            // 
            // grpCertificateDetails
            // 
            this.grpCertificateDetails.Controls.Add(this.btnClear);
            this.grpCertificateDetails.Controls.Add(this.btnDelete);
            this.grpCertificateDetails.Controls.Add(this.btnUpdate);
            this.grpCertificateDetails.Controls.Add(this.btnAdd);
            this.grpCertificateDetails.Controls.Add(this.dtpIssueDate);
            this.grpCertificateDetails.Controls.Add(this.lblIssueDate);
            this.grpCertificateDetails.Controls.Add(this.cmbCertificateType);
            this.grpCertificateDetails.Controls.Add(this.lblCertificateType);
            this.grpCertificateDetails.Controls.Add(this.txtCertificateNo);
            this.grpCertificateDetails.Controls.Add(this.lblCertificateNo);
            this.grpCertificateDetails.Controls.Add(this.cmbParticipant);
            this.grpCertificateDetails.Controls.Add(this.lblParticipant);
            this.grpCertificateDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCertificateDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCertificateDetails.ForeColor = System.Drawing.Color.FromArgb(74, 20, 140);
            this.grpCertificateDetails.Location = new System.Drawing.Point(0, 52);
            this.grpCertificateDetails.Name = "grpCertificateDetails";
            this.grpCertificateDetails.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.grpCertificateDetails.Size = new System.Drawing.Size(1024, 220);
            this.grpCertificateDetails.TabIndex = 1;
            this.grpCertificateDetails.TabStop = false;
            this.grpCertificateDetails.Text = "Certificate Details";
            // 
            // lblParticipant
            // 
            this.lblParticipant.AutoSize = true;
            this.lblParticipant.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblParticipant.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblParticipant.Location = new System.Drawing.Point(20, 38);
            this.lblParticipant.Name = "lblParticipant";
            this.lblParticipant.Size = new System.Drawing.Size(82, 17);
            this.lblParticipant.TabIndex = 0;
            this.lblParticipant.Text = "Participant *";
            // 
            // cmbParticipant
            // 
            this.cmbParticipant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParticipant.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbParticipant.FormattingEnabled = true;
            this.cmbParticipant.Location = new System.Drawing.Point(150, 35);
            this.cmbParticipant.Name = "cmbParticipant";
            this.cmbParticipant.Size = new System.Drawing.Size(430, 25);
            this.cmbParticipant.TabIndex = 1;
            // 
            // lblCertificateNo
            // 
            this.lblCertificateNo.AutoSize = true;
            this.lblCertificateNo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblCertificateNo.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblCertificateNo.Location = new System.Drawing.Point(20, 78);
            this.lblCertificateNo.Name = "lblCertificateNo";
            this.lblCertificateNo.Size = new System.Drawing.Size(120, 17);
            this.lblCertificateNo.TabIndex = 2;
            this.lblCertificateNo.Text = "Certificate No *";
            // 
            // txtCertificateNo
            // 
            this.txtCertificateNo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCertificateNo.Location = new System.Drawing.Point(150, 75);
            this.txtCertificateNo.MaxLength = 100;
            this.txtCertificateNo.Name = "txtCertificateNo";
            this.txtCertificateNo.Size = new System.Drawing.Size(220, 25);
            this.txtCertificateNo.TabIndex = 3;
            // 
            // lblCertificateType
            // 
            this.lblCertificateType.AutoSize = true;
            this.lblCertificateType.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblCertificateType.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblCertificateType.Location = new System.Drawing.Point(420, 78);
            this.lblCertificateType.Name = "lblCertificateType";
            this.lblCertificateType.Size = new System.Drawing.Size(110, 17);
            this.lblCertificateType.TabIndex = 4;
            this.lblCertificateType.Text = "Certificate Type";
            // 
            // cmbCertificateType
            // 
            this.cmbCertificateType.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCertificateType.FormattingEnabled = true;
            this.cmbCertificateType.Items.AddRange(new object[] {
            "Participation",
            "Winner",
            "Runner-up",
            "Appreciation",
            "Volunteer"});
            this.cmbCertificateType.Location = new System.Drawing.Point(560, 75);
            this.cmbCertificateType.MaxLength = 100;
            this.cmbCertificateType.Name = "cmbCertificateType";
            this.cmbCertificateType.Size = new System.Drawing.Size(220, 25);
            this.cmbCertificateType.TabIndex = 5;
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblIssueDate.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblIssueDate.Location = new System.Drawing.Point(20, 118);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(72, 17);
            this.lblIssueDate.TabIndex = 6;
            this.lblIssueDate.Text = "Issue Date";
            // 
            // dtpIssueDate
            // 
            this.dtpIssueDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIssueDate.Location = new System.Drawing.Point(150, 115);
            this.dtpIssueDate.Name = "dtpIssueDate";
            this.dtpIssueDate.Size = new System.Drawing.Size(220, 25);
            this.dtpIssueDate.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(150, 165);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 34);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(270, 165);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 34);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(390, 165);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 34);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(510, 165);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 34);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvCertificates);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 272);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(16);
            this.pnlGrid.Size = new System.Drawing.Size(1024, 368);
            this.pnlGrid.TabIndex = 2;
            // 
            // dgvCertificates
            // 
            this.dgvCertificates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCertificates.Location = new System.Drawing.Point(16, 16);
            this.dgvCertificates.Name = "dgvCertificates";
            this.dgvCertificates.Size = new System.Drawing.Size(992, 336);
            this.dgvCertificates.TabIndex = 0;
            this.dgvCertificates.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCertificates_CellClick);
            // 
            // CertificateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 640);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.grpCertificateDetails);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "CertificateForm";
            this.Text = "Certificate Records";
            this.Load += new System.EventHandler(this.CertificateForm_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.grpCertificateDetails.ResumeLayout(false);
            this.grpCertificateDetails.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCertificates)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpCertificateDetails;
        private System.Windows.Forms.Label lblParticipant;
        private System.Windows.Forms.ComboBox cmbParticipant;
        private System.Windows.Forms.Label lblCertificateNo;
        private System.Windows.Forms.TextBox txtCertificateNo;
        private System.Windows.Forms.Label lblCertificateType;
        private System.Windows.Forms.ComboBox cmbCertificateType;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.DateTimePicker dtpIssueDate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvCertificates;
    }
}
