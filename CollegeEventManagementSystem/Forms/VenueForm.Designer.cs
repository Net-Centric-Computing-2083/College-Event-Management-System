namespace CollegeEventManagementSystem.Forms
{
    partial class VenueForm
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
            this.grpVenueDetails = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtVenueName = new System.Windows.Forms.TextBox();
            this.lblVenueName = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvVenues = new System.Windows.Forms.DataGridView();
            this.pnlTitle.SuspendLayout();
            this.grpVenueDetails.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenues)).BeginInit();
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
            this.lblTitle.Text = "Venue Management";
            // 
            // grpVenueDetails
            // 
            this.grpVenueDetails.Controls.Add(this.btnClear);
            this.grpVenueDetails.Controls.Add(this.btnDelete);
            this.grpVenueDetails.Controls.Add(this.btnUpdate);
            this.grpVenueDetails.Controls.Add(this.btnAdd);
            this.grpVenueDetails.Controls.Add(this.txtCapacity);
            this.grpVenueDetails.Controls.Add(this.lblCapacity);
            this.grpVenueDetails.Controls.Add(this.txtLocation);
            this.grpVenueDetails.Controls.Add(this.lblLocation);
            this.grpVenueDetails.Controls.Add(this.txtVenueName);
            this.grpVenueDetails.Controls.Add(this.lblVenueName);
            this.grpVenueDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpVenueDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpVenueDetails.ForeColor = System.Drawing.Color.FromArgb(74, 20, 140);
            this.grpVenueDetails.Location = new System.Drawing.Point(0, 52);
            this.grpVenueDetails.Name = "grpVenueDetails";
            this.grpVenueDetails.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.grpVenueDetails.Size = new System.Drawing.Size(1024, 185);
            this.grpVenueDetails.TabIndex = 1;
            this.grpVenueDetails.TabStop = false;
            this.grpVenueDetails.Text = "Venue Details";
            // 
            // lblVenueName
            // 
            this.lblVenueName.AutoSize = true;
            this.lblVenueName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblVenueName.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblVenueName.Location = new System.Drawing.Point(20, 38);
            this.lblVenueName.Name = "lblVenueName";
            this.lblVenueName.Size = new System.Drawing.Size(94, 17);
            this.lblVenueName.TabIndex = 0;
            this.lblVenueName.Text = "Venue Name *";
            // 
            // txtVenueName
            // 
            this.txtVenueName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtVenueName.Location = new System.Drawing.Point(150, 35);
            this.txtVenueName.MaxLength = 100;
            this.txtVenueName.Name = "txtVenueName";
            this.txtVenueName.Size = new System.Drawing.Size(280, 25);
            this.txtVenueName.TabIndex = 1;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblLocation.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblLocation.Location = new System.Drawing.Point(460, 38);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(60, 17);
            this.lblLocation.TabIndex = 2;
            this.lblLocation.Text = "Location";
            // 
            // txtLocation
            // 
            this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocation.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtLocation.Location = new System.Drawing.Point(560, 35);
            this.txtLocation.MaxLength = 150;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(430, 25);
            this.txtLocation.TabIndex = 3;
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblCapacity.ForeColor = System.Drawing.Color.FromArgb(46, 42, 53);
            this.lblCapacity.Location = new System.Drawing.Point(20, 78);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(66, 17);
            this.lblCapacity.TabIndex = 4;
            this.lblCapacity.Text = "Capacity *";
            // 
            // txtCapacity
            // 
            this.txtCapacity.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCapacity.Location = new System.Drawing.Point(150, 75);
            this.txtCapacity.MaxLength = 6;
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(120, 25);
            this.txtCapacity.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(150, 125);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 34);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvVenues);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 237);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(16);
            this.pnlGrid.Size = new System.Drawing.Size(1024, 403);
            this.pnlGrid.TabIndex = 2;
            // 
            // dgvVenues
            // 
            this.dgvVenues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVenues.Location = new System.Drawing.Point(16, 16);
            this.dgvVenues.Name = "dgvVenues";
            this.dgvVenues.Size = new System.Drawing.Size(992, 371);
            this.dgvVenues.TabIndex = 0;
            this.dgvVenues.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVenues_CellClick);
            // 
            // VenueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 640);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.grpVenueDetails);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "VenueForm";
            this.Text = "Venue Management";
            this.Load += new System.EventHandler(this.VenueForm_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.grpVenueDetails.ResumeLayout(false);
            this.grpVenueDetails.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenues)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpVenueDetails;
        private System.Windows.Forms.Label lblVenueName;
        private System.Windows.Forms.TextBox txtVenueName;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvVenues;
    }
}
