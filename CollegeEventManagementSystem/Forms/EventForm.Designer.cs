namespace CollegeEventManagementSystem.Forms
{
    partial class EventForm
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
            this.grpEventDetails = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.dtpEventDate = new System.Windows.Forms.DateTimePicker();
            this.lblEventDate = new System.Windows.Forms.Label();
            this.cmbVenue = new System.Windows.Forms.ComboBox();
            this.lblVenue = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.lblEventName = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.pnlTitle.SuspendLayout();
            this.grpEventDetails.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(190, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Event Management";
            // 
            // grpEventDetails
            // 
            this.grpEventDetails.Controls.Add(this.btnClear);
            this.grpEventDetails.Controls.Add(this.btnDelete);
            this.grpEventDetails.Controls.Add(this.btnUpdate);
            this.grpEventDetails.Controls.Add(this.btnAdd);
            this.grpEventDetails.Controls.Add(this.txtDescription);
            this.grpEventDetails.Controls.Add(this.lblDescription);
            this.grpEventDetails.Controls.Add(this.dtpEventDate);
            this.grpEventDetails.Controls.Add(this.lblEventDate);
            this.grpEventDetails.Controls.Add(this.cmbVenue);
            this.grpEventDetails.Controls.Add(this.lblVenue);
            this.grpEventDetails.Controls.Add(this.cmbCategory);
            this.grpEventDetails.Controls.Add(this.lblCategory);
            this.grpEventDetails.Controls.Add(this.txtEventName);
            this.grpEventDetails.Controls.Add(this.lblEventName);
            this.grpEventDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEventDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpEventDetails.ForeColor = System.Drawing.Color.FromArgb(74, 20, 140);
            this.grpEventDetails.Location = new System.Drawing.Point(0, 52);
            this.grpEventDetails.Name = "grpEventDetails";
            this.grpEventDetails.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.grpEventDetails.Size = new System.Drawing.Size(1024, 220);
            this.grpEventDetails.TabIndex = 1;
            this.grpEventDetails.TabStop = false;
            this.grpEventDetails.Text = "Event Details";
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblEventName.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblEventName.Location = new System.Drawing.Point(20, 38);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(90, 17);
            this.lblEventName.TabIndex = 0;
            this.lblEventName.Text = "Event Name *";
            // 
            // txtEventName
            // 
            this.txtEventName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtEventName.Location = new System.Drawing.Point(150, 35);
            this.txtEventName.MaxLength = 150;
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.Size = new System.Drawing.Size(280, 25);
            this.txtEventName.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblCategory.Location = new System.Drawing.Point(460, 38);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(72, 17);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category *";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(560, 35);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(300, 25);
            this.cmbCategory.TabIndex = 3;
            // 
            // lblVenue
            // 
            this.lblVenue.AutoSize = true;
            this.lblVenue.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblVenue.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblVenue.Location = new System.Drawing.Point(20, 78);
            this.lblVenue.Name = "lblVenue";
            this.lblVenue.Size = new System.Drawing.Size(56, 17);
            this.lblVenue.TabIndex = 4;
            this.lblVenue.Text = "Venue *";
            // 
            // cmbVenue
            // 
            this.cmbVenue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVenue.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbVenue.FormattingEnabled = true;
            this.cmbVenue.Location = new System.Drawing.Point(150, 75);
            this.cmbVenue.Name = "cmbVenue";
            this.cmbVenue.Size = new System.Drawing.Size(280, 25);
            this.cmbVenue.TabIndex = 5;
            // 
            // lblEventDate
            // 
            this.lblEventDate.AutoSize = true;
            this.lblEventDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblEventDate.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblEventDate.Location = new System.Drawing.Point(460, 78);
            this.lblEventDate.Name = "lblEventDate";
            this.lblEventDate.Size = new System.Drawing.Size(80, 17);
            this.lblEventDate.TabIndex = 6;
            this.lblEventDate.Text = "Event Date *";
            // 
            // dtpEventDate
            // 
            this.dtpEventDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpEventDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEventDate.Location = new System.Drawing.Point(560, 75);
            this.dtpEventDate.Name = "dtpEventDate";
            this.dtpEventDate.Size = new System.Drawing.Size(300, 25);
            this.dtpEventDate.TabIndex = 7;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblDescription.Location = new System.Drawing.Point(20, 118);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(78, 17);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDescription.Location = new System.Drawing.Point(150, 115);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(710, 25);
            this.txtDescription.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(150, 165);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 34);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
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
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvEvents);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 272);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(16);
            this.pnlGrid.Size = new System.Drawing.Size(1024, 368);
            this.pnlGrid.TabIndex = 2;
            // 
            // dgvEvents
            // 
            this.dgvEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEvents.Location = new System.Drawing.Point(16, 16);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.Size = new System.Drawing.Size(992, 336);
            this.dgvEvents.TabIndex = 0;
            this.dgvEvents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvents_CellClick);
            // 
            // EventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 640);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.grpEventDetails);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "EventForm";
            this.Text = "Event Management";
            this.Load += new System.EventHandler(this.EventForm_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.grpEventDetails.ResumeLayout(false);
            this.grpEventDetails.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpEventDetails;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblVenue;
        private System.Windows.Forms.ComboBox cmbVenue;
        private System.Windows.Forms.Label lblEventDate;
        private System.Windows.Forms.DateTimePicker dtpEventDate;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvEvents;
    }
}
