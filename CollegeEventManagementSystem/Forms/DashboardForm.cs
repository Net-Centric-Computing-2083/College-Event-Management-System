using System;
using System.Data;
using System.Windows.Forms;
using CollegeEventManagementSystem.Data;
using CollegeEventManagementSystem.UI;

namespace CollegeEventManagementSystem.Forms
{
    /// <summary>
    /// Dashboard screen. Shows four summary cards and the list of upcoming events.
    /// All numbers are read from SQL Server with COUNT(*) queries.
    /// </summary>
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            Theme.StyleForm(this);
            Theme.StyleSecondaryButton(btnRefresh);
            Theme.StyleGrid(dgvUpcomingEvents);
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadSummary();
            LoadUpcomingEvents();
        }

        private void LoadSummary()
        {
            try
            {
                lblEventsValue.Text = DatabaseHelper.GetCount("SELECT COUNT(*) FROM Events").ToString();
                lblStudentsValue.Text = DatabaseHelper.GetCount("SELECT COUNT(*) FROM Students").ToString();
                lblParticipantsValue.Text = DatabaseHelper.GetCount("SELECT COUNT(*) FROM Participants").ToString();
                lblCertificatesValue.Text = DatabaseHelper.GetCount("SELECT COUNT(*) FROM Certificates").ToString();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to load the dashboard summary. Please check the database connection.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadUpcomingEvents()
        {
            try
            {
                string sql =
                    "SELECT TOP 10 e.EventName, c.CategoryName, v.VenueName, e.EventDate " +
                    "FROM Events e " +
                    "LEFT JOIN Categories c ON e.CategoryID = c.CategoryID " +
                    "LEFT JOIN Venues v ON e.VenueID = v.VenueID " +
                    "WHERE e.EventDate >= CAST(GETDATE() AS DATE) " +
                    "ORDER BY e.EventDate";

                DataTable table = DatabaseHelper.GetDataTable(sql);
                dgvUpcomingEvents.DataSource = table;

                dgvUpcomingEvents.Columns["EventName"].HeaderText = "Event Name";
                dgvUpcomingEvents.Columns["CategoryName"].HeaderText = "Category";
                dgvUpcomingEvents.Columns["VenueName"].HeaderText = "Venue";
                dgvUpcomingEvents.Columns["EventDate"].HeaderText = "Event Date";
                dgvUpcomingEvents.Columns["EventDate"].DefaultCellStyle.Format = "dd MMM yyyy";
                dgvUpcomingEvents.ClearSelection();

                if (table.Rows.Count == 0)
                {
                    lblUpcoming.Text = "Upcoming Events  (no upcoming events found)";
                }
                else
                {
                    lblUpcoming.Text = "Upcoming Events";
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to load the upcoming events. Please check the database connection.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSummary();
            LoadUpcomingEvents();
        }
    }
}
