namespace CollegeEventManagementSystem.Forms
{
    partial class DashboardForm
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.pnlEventsCard = new System.Windows.Forms.Panel();
            this.lblEventsValue = new System.Windows.Forms.Label();
            this.lblEventsCaption = new System.Windows.Forms.Label();
            this.pnlStudentsCard = new System.Windows.Forms.Panel();
            this.lblStudentsValue = new System.Windows.Forms.Label();
            this.lblStudentsCaption = new System.Windows.Forms.Label();
            this.pnlParticipantsCard = new System.Windows.Forms.Panel();
            this.lblParticipantsValue = new System.Windows.Forms.Label();
            this.lblParticipantsCaption = new System.Windows.Forms.Label();
            this.pnlCertificatesCard = new System.Windows.Forms.Panel();
            this.lblCertificatesValue = new System.Windows.Forms.Label();
            this.lblCertificatesCaption = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvUpcomingEvents = new System.Windows.Forms.DataGridView();
            this.lblUpcoming = new System.Windows.Forms.Label();
            this.pnlTitle.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.pnlEventsCard.SuspendLayout();
            this.pnlStudentsCard.SuspendLayout();
            this.pnlParticipantsCard.SuspendLayout();
            this.pnlCertificatesCard.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpcomingEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.White;
            this.pnlTitle.Controls.Add(this.btnRefresh);
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
            this.lblTitle.Size = new System.Drawing.Size(110, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dashboard";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(884, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(124, 32);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlCards
            // 
            this.pnlCards.Controls.Add(this.pnlCertificatesCard);
            this.pnlCards.Controls.Add(this.pnlParticipantsCard);
            this.pnlCards.Controls.Add(this.pnlStudentsCard);
            this.pnlCards.Controls.Add(this.pnlEventsCard);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 52);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1024, 132);
            this.pnlCards.TabIndex = 1;
            // 
            // pnlEventsCard
            // 
            this.pnlEventsCard.BackColor = System.Drawing.Color.White;
            this.pnlEventsCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEventsCard.Controls.Add(this.lblEventsValue);
            this.pnlEventsCard.Controls.Add(this.lblEventsCaption);
            this.pnlEventsCard.Location = new System.Drawing.Point(16, 16);
            this.pnlEventsCard.Name = "pnlEventsCard";
            this.pnlEventsCard.Size = new System.Drawing.Size(236, 100);
            this.pnlEventsCard.TabIndex = 0;
            // 
            // lblEventsCaption
            // 
            this.lblEventsCaption.AutoSize = true;
            this.lblEventsCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEventsCaption.ForeColor = System.Drawing.Color.FromArgb(110, 100, 125);
            this.lblEventsCaption.Location = new System.Drawing.Point(16, 14);
            this.lblEventsCaption.Name = "lblEventsCaption";
            this.lblEventsCaption.Size = new System.Drawing.Size(84, 19);
            this.lblEventsCaption.TabIndex = 0;
            this.lblEventsCaption.Text = "Total Events";
            // 
            // lblEventsValue
            // 
            this.lblEventsValue.AutoSize = true;
            this.lblEventsValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblEventsValue.ForeColor = System.Drawing.Color.FromArgb(106, 27, 154);
            this.lblEventsValue.Location = new System.Drawing.Point(14, 40);
            this.lblEventsValue.Name = "lblEventsValue";
            this.lblEventsValue.Size = new System.Drawing.Size(32, 41);
            this.lblEventsValue.TabIndex = 1;
            this.lblEventsValue.Text = "0";
            // 
            // pnlStudentsCard
            // 
            this.pnlStudentsCard.BackColor = System.Drawing.Color.White;
            this.pnlStudentsCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStudentsCard.Controls.Add(this.lblStudentsValue);
            this.pnlStudentsCard.Controls.Add(this.lblStudentsCaption);
            this.pnlStudentsCard.Location = new System.Drawing.Point(268, 16);
            this.pnlStudentsCard.Name = "pnlStudentsCard";
            this.pnlStudentsCard.Size = new System.Drawing.Size(236, 100);
            this.pnlStudentsCard.TabIndex = 1;
            // 
            // lblStudentsCaption
            // 
            this.lblStudentsCaption.AutoSize = true;
            this.lblStudentsCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStudentsCaption.ForeColor = System.Drawing.Color.FromArgb(110, 100, 125);
            this.lblStudentsCaption.Location = new System.Drawing.Point(16, 14);
            this.lblStudentsCaption.Name = "lblStudentsCaption";
            this.lblStudentsCaption.Size = new System.Drawing.Size(94, 19);
            this.lblStudentsCaption.TabIndex = 0;
            this.lblStudentsCaption.Text = "Total Students";
            // 
            // lblStudentsValue
            // 
            this.lblStudentsValue.AutoSize = true;
            this.lblStudentsValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblStudentsValue.ForeColor = System.Drawing.Color.FromArgb(106, 27, 154);
            this.lblStudentsValue.Location = new System.Drawing.Point(14, 40);
            this.lblStudentsValue.Name = "lblStudentsValue";
            this.lblStudentsValue.Size = new System.Drawing.Size(32, 41);
            this.lblStudentsValue.TabIndex = 1;
            this.lblStudentsValue.Text = "0";
            // 
            // pnlParticipantsCard
            // 
            this.pnlParticipantsCard.BackColor = System.Drawing.Color.White;
            this.pnlParticipantsCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlParticipantsCard.Controls.Add(this.lblParticipantsValue);
            this.pnlParticipantsCard.Controls.Add(this.lblParticipantsCaption);
            this.pnlParticipantsCard.Location = new System.Drawing.Point(520, 16);
            this.pnlParticipantsCard.Name = "pnlParticipantsCard";
            this.pnlParticipantsCard.Size = new System.Drawing.Size(236, 100);
            this.pnlParticipantsCard.TabIndex = 2;
            // 
            // lblParticipantsCaption
            // 
            this.lblParticipantsCaption.AutoSize = true;
            this.lblParticipantsCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblParticipantsCaption.ForeColor = System.Drawing.Color.FromArgb(110, 100, 125);
            this.lblParticipantsCaption.Location = new System.Drawing.Point(16, 14);
            this.lblParticipantsCaption.Name = "lblParticipantsCaption";
            this.lblParticipantsCaption.Size = new System.Drawing.Size(112, 19);
            this.lblParticipantsCaption.TabIndex = 0;
            this.lblParticipantsCaption.Text = "Total Participants";
            // 
            // lblParticipantsValue
            // 
            this.lblParticipantsValue.AutoSize = true;
            this.lblParticipantsValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblParticipantsValue.ForeColor = System.Drawing.Color.FromArgb(106, 27, 154);
            this.lblParticipantsValue.Location = new System.Drawing.Point(14, 40);
            this.lblParticipantsValue.Name = "lblParticipantsValue";
            this.lblParticipantsValue.Size = new System.Drawing.Size(32, 41);
            this.lblParticipantsValue.TabIndex = 1;
            this.lblParticipantsValue.Text = "0";
            // 
            // pnlCertificatesCard
            // 
            this.pnlCertificatesCard.BackColor = System.Drawing.Color.White;
            this.pnlCertificatesCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCertificatesCard.Controls.Add(this.lblCertificatesValue);
            this.pnlCertificatesCard.Controls.Add(this.lblCertificatesCaption);
            this.pnlCertificatesCard.Location = new System.Drawing.Point(772, 16);
            this.pnlCertificatesCard.Name = "pnlCertificatesCard";
            this.pnlCertificatesCard.Size = new System.Drawing.Size(236, 100);
            this.pnlCertificatesCard.TabIndex = 3;
            // 
            // lblCertificatesCaption
            // 
            this.lblCertificatesCaption.AutoSize = true;
            this.lblCertificatesCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCertificatesCaption.ForeColor = System.Drawing.Color.FromArgb(110, 100, 125);
            this.lblCertificatesCaption.Location = new System.Drawing.Point(16, 14);
            this.lblCertificatesCaption.Name = "lblCertificatesCaption";
            this.lblCertificatesCaption.Size = new System.Drawing.Size(112, 19);
            this.lblCertificatesCaption.TabIndex = 0;
            this.lblCertificatesCaption.Text = "Total Certificates";
            // 
            // lblCertificatesValue
            // 
            this.lblCertificatesValue.AutoSize = true;
            this.lblCertificatesValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCertificatesValue.ForeColor = System.Drawing.Color.FromArgb(106, 27, 154);
            this.lblCertificatesValue.Location = new System.Drawing.Point(14, 40);
            this.lblCertificatesValue.Name = "lblCertificatesValue";
            this.lblCertificatesValue.Size = new System.Drawing.Size(32, 41);
            this.lblCertificatesValue.TabIndex = 1;
            this.lblCertificatesValue.Text = "0";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvUpcomingEvents);
            this.pnlGrid.Controls.Add(this.lblUpcoming);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 184);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(16, 0, 16, 16);
            this.pnlGrid.Size = new System.Drawing.Size(1024, 456);
            this.pnlGrid.TabIndex = 2;
            // 
            // lblUpcoming
            // 
            this.lblUpcoming.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUpcoming.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblUpcoming.ForeColor = System.Drawing.Color.FromArgb(74, 20, 140);
            this.lblUpcoming.Location = new System.Drawing.Point(16, 0);
            this.lblUpcoming.Name = "lblUpcoming";
            this.lblUpcoming.Size = new System.Drawing.Size(992, 30);
            this.lblUpcoming.TabIndex = 0;
            this.lblUpcoming.Text = "Upcoming Events";
            this.lblUpcoming.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvUpcomingEvents
            // 
            this.dgvUpcomingEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUpcomingEvents.Location = new System.Drawing.Point(16, 30);
            this.dgvUpcomingEvents.Name = "dgvUpcomingEvents";
            this.dgvUpcomingEvents.Size = new System.Drawing.Size(992, 410);
            this.dgvUpcomingEvents.TabIndex = 1;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 640);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "DashboardForm";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.pnlCards.ResumeLayout(false);
            this.pnlEventsCard.ResumeLayout(false);
            this.pnlEventsCard.PerformLayout();
            this.pnlStudentsCard.ResumeLayout(false);
            this.pnlStudentsCard.PerformLayout();
            this.pnlParticipantsCard.ResumeLayout(false);
            this.pnlParticipantsCard.PerformLayout();
            this.pnlCertificatesCard.ResumeLayout(false);
            this.pnlCertificatesCard.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpcomingEvents)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.Panel pnlEventsCard;
        private System.Windows.Forms.Label lblEventsCaption;
        private System.Windows.Forms.Label lblEventsValue;
        private System.Windows.Forms.Panel pnlStudentsCard;
        private System.Windows.Forms.Label lblStudentsCaption;
        private System.Windows.Forms.Label lblStudentsValue;
        private System.Windows.Forms.Panel pnlParticipantsCard;
        private System.Windows.Forms.Label lblParticipantsCaption;
        private System.Windows.Forms.Label lblParticipantsValue;
        private System.Windows.Forms.Panel pnlCertificatesCard;
        private System.Windows.Forms.Label lblCertificatesCaption;
        private System.Windows.Forms.Label lblCertificatesValue;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblUpcoming;
        private System.Windows.Forms.DataGridView dgvUpcomingEvents;
    }
}
