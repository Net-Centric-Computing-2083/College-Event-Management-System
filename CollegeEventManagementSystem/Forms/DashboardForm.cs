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
            Theme.StylePrimaryButton(btnShowRange);
            Theme.StyleSecondaryButton(btnResetRange);
            Theme.StyleGrid(dgvUpcomingEvents);
            StyleCards();

            // Thin border around the filter strip so it reads as one toolbar.
            Theme.AddBorder(pnlFilter, Theme.Border);
        }

        /// <summary>
        /// Gives every summary card a white background, a thin border and a coloured
        /// strip on the left, so the four numbers are easy to read at a glance.
        /// </summary>
        private void StyleCards()
        {
            Theme.StyleCard(pnlEventsCard);
            Theme.StyleCard(pnlStudentsCard);
            Theme.StyleCard(pnlParticipantsCard);
            Theme.StyleCard(pnlCertificatesCard);

            Theme.AddCardAccent(pnlEventsCard, Theme.Primary);
            Theme.AddCardAccent(pnlStudentsCard, Theme.PrimaryLight);
            Theme.AddCardAccent(pnlParticipantsCard, Theme.Success);
            Theme.AddCardAccent(pnlCertificatesCard, Theme.Danger);

            lblEventsCaption.ForeColor = Theme.TextMuted;
            lblStudentsCaption.ForeColor = Theme.TextMuted;
            lblParticipantsCaption.ForeColor = Theme.TextMuted;
            lblCertificatesCaption.ForeColor = Theme.TextMuted;

            lblEventsValue.ForeColor = Theme.Primary;
            lblStudentsValue.ForeColor = Theme.PrimaryLight;
            lblParticipantsValue.ForeColor = Theme.Success;
            lblCertificatesValue.ForeColor = Theme.Danger;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            SetDefaultDateRange();
            LoadSummary();
            LoadUpcomingEvents();
        }

        /// <summary>
        /// The upcoming events list starts with the timeline of the next 30 days.
        /// The user can select any other date range with the two date pickers.
        /// </summary>
        private void SetDefaultDateRange()
        {
            dtpFromDate.Value = DateTime.Today;
            dtpToDate.Value = DateTime.Today.AddDays(30);
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

        /// <summary>
        /// Loads the events of the selected date range (the timeline chosen with
        /// the two date pickers). The dates are passed as parameters, so the query
        /// stays parameterized.
        /// </summary>
        private void LoadUpcomingEvents()
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;

            if (fromDate > toDate)
            {
                MessageBox.Show(
                    "The 'from' date cannot be later than the 'to' date.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                string sql =
                    "SELECT e.EventName, c.CategoryName, v.VenueName, e.EventDate " +
                    "FROM Events e " +
                    "LEFT JOIN Categories c ON e.CategoryID = c.CategoryID " +
                    "LEFT JOIN Venues v ON e.VenueID = v.VenueID " +
                    "WHERE e.EventDate BETWEEN @FromDate AND @ToDate " +
                    "ORDER BY e.EventDate";

                DataTable table = DatabaseHelper.GetDataTable(sql,
                    DatabaseHelper.Param("@FromDate", fromDate),
                    DatabaseHelper.Param("@ToDate", toDate));

                dgvUpcomingEvents.DataSource = table;

                dgvUpcomingEvents.Columns["EventName"].HeaderText = "Event Name";
                dgvUpcomingEvents.Columns["CategoryName"].HeaderText = "Category";
                dgvUpcomingEvents.Columns["VenueName"].HeaderText = "Venue";
                dgvUpcomingEvents.Columns["EventDate"].HeaderText = "Event Date";
                dgvUpcomingEvents.Columns["EventDate"].DefaultCellStyle.Format = "dd MMM yyyy";
                dgvUpcomingEvents.ClearSelection();

                string period = fromDate.ToString("dd MMM yyyy") + " to " + toDate.ToString("dd MMM yyyy");

                if (table.Rows.Count == 0)
                {
                    lblUpcoming.Text = "Upcoming Events: " + period + "  (no events found in this date range)";
                }
                else
                {
                    lblUpcoming.Text = "Upcoming Events: " + period;
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

        private void btnShowRange_Click(object sender, EventArgs e)
        {
            LoadUpcomingEvents();
        }

        private void btnResetRange_Click(object sender, EventArgs e)
        {
            SetDefaultDateRange();
            LoadUpcomingEvents();
        }
    }
}

// Reviewed by Samir Khatri: dashboard summary counts and upcoming events query verified.
