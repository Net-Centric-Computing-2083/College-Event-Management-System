using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CollegeEventManagementSystem.Data;
using CollegeEventManagementSystem.UI;

namespace CollegeEventManagementSystem.Forms
{
    /// <summary>
    /// Main window of the application.
    /// It shows the header, the left navigation sidebar and a content area.
    /// Every module form is opened inside the content area (pnlContent).
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ApplyTheme();
            LoadLogo();
        }

        private void ApplyTheme()
        {
            Theme.StyleNavButton(btnDashboard);
            Theme.StyleNavButton(btnEvents);
            Theme.StyleNavButton(btnCategories);
            Theme.StyleNavButton(btnVenues);
            Theme.StyleNavButton(btnStudents);
            Theme.StyleNavButton(btnParticipants);
            Theme.StyleNavButton(btnAttendance);
            Theme.StyleNavButton(btnCertificates);
            Theme.StyleNavButton(btnExit);

            pnlHeader.BackColor = Theme.PrimaryDark;
            pnlSidebar.BackColor = Theme.Primary;
            pnlContent.BackColor = Theme.Background;
            lblLogo.ForeColor = Theme.Primary;
        }

        /// <summary>
        /// Shows the college logo if an image file was supplied in the Assets folder.
        /// When no image is available the clean "ORCHID COLLEGE" text placeholder is used.
        /// </summary>
        private void LoadLogo()
        {
            try
            {
                string logoPath = Path.Combine(Application.StartupPath, "Assets", "logo.png");

                if (File.Exists(logoPath))
                {
                    picLogo.Image = Image.FromFile(logoPath);
                    picLogo.Visible = true;
                    lblLogo.Visible = false;
                }
            }
            catch (Exception)
            {
                // No logo file could be loaded, the text placeholder stays visible.
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!DatabaseHelper.CanConnect())
            {
                MessageBox.Show(
                    "Unable to connect to the CollegeEventDB database.\n\n" +
                    "Please check that:\n" +
                    "1. SQL Server is running.\n" +
                    "2. The script Database\\CollegeEventDB.sql has been executed.\n" +
                    "3. The connection string in App.config points to the correct server.",
                    "Database Connection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            OpenChildForm(new DashboardForm(), btnDashboard);
        }

        /// <summary>
        /// Opens a module form inside the content panel instead of a new window.
        /// </summary>
        private void OpenChildForm(Form childForm, Button activeButton)
        {
            while (pnlContent.Controls.Count > 0)
            {
                Control oldControl = pnlContent.Controls[0];
                pnlContent.Controls.Remove(oldControl);
                oldControl.Dispose();
            }

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(childForm);
            childForm.Show();

            HighlightActiveButton(activeButton);
        }

        private void HighlightActiveButton(Button activeButton)
        {
            foreach (Control control in pnlSidebar.Controls)
            {
                if (control is Button)
                {
                    control.BackColor = Theme.Primary;
                }
            }

            activeButton.BackColor = Theme.PrimaryDark;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DashboardForm(), btnDashboard);
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EventForm(), btnEvents);
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CategoryForm(), btnCategories);
        }

        private void btnVenues_Click(object sender, EventArgs e)
        {
            OpenChildForm(new VenueForm(), btnVenues);
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StudentForm(), btnStudents);
        }

        private void btnParticipants_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ParticipantForm(), btnParticipants);
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AttendanceForm(), btnAttendance);
        }

        private void btnCertificates_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CertificateForm(), btnCertificates);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show(
                "Do you want to close the application?",
                "Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
