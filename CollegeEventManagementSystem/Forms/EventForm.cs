using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CollegeEventManagementSystem.Data;
using CollegeEventManagementSystem.UI;

namespace CollegeEventManagementSystem.Forms
{
    public partial class EventForm : Form
    {
        private int selectedEventId = 0;

        public EventForm()
        {
            InitializeComponent();

            Theme.StyleForm(this);
            Theme.StylePrimaryButton(btnAdd);
            Theme.StyleSecondaryButton(btnUpdate);
            Theme.StyleDangerButton(btnDelete);
            Theme.StyleSecondaryButton(btnClear);
            Theme.StyleGrid(dgvEvents);
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadVenues();
            LoadEvents();

            if (cmbCategory.Items.Count == 0)
            {
                MessageBox.Show(
                    "No categories are available. Please create a category first.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            if (cmbVenue.Items.Count == 0)
            {
                MessageBox.Show(
                    "No venues are available. Please create a venue first.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        // ============================================================
        // LOAD CATEGORIES
        // ============================================================

        private void LoadCategories()
        {
            try
            {
                string sql =
                    "SELECT CategoryID, CategoryName " +
                    "FROM Categories " +
                    "ORDER BY CategoryName";

                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";
                cmbCategory.DataSource = DatabaseHelper.GetDataTable(sql);
                cmbCategory.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to load the category list.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // LOAD VENUES
        // ============================================================

        private void LoadVenues()
        {
            try
            {
                string sql =
                    "SELECT VenueID, VenueName " +
                    "FROM Venues " +
                    "ORDER BY VenueName";

                cmbVenue.DisplayMember = "VenueName";
                cmbVenue.ValueMember = "VenueID";
                cmbVenue.DataSource = DatabaseHelper.GetDataTable(sql);
                cmbVenue.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to load the venue list.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // LOAD EVENTS
        // ============================================================

        private void LoadEvents()
        {
            try
            {
                string sql =
                    "SELECT " +
                    "e.EventID, " +
                    "e.EventName, " +
                    "c.CategoryName, " +
                    "v.VenueName, " +
                    "e.EventDate, " +
                    "e.Description, " +
                    "e.CategoryID, " +
                    "e.VenueID " +
                    "FROM Events e " +
                    "LEFT JOIN Categories c ON e.CategoryID = c.CategoryID " +
                    "LEFT JOIN Venues v ON e.VenueID = v.VenueID " +
                    "ORDER BY e.EventDate DESC";

                dgvEvents.DataSource = DatabaseHelper.GetDataTable(sql);

                if (dgvEvents.Columns.Count > 0)
                {
                    dgvEvents.Columns["EventID"].HeaderText = "Event ID";
                    dgvEvents.Columns["EventName"].HeaderText = "Event Name";
                    dgvEvents.Columns["CategoryName"].HeaderText = "Category";
                    dgvEvents.Columns["VenueName"].HeaderText = "Venue";
                    dgvEvents.Columns["EventDate"].HeaderText = "Event Date";
                    dgvEvents.Columns["Description"].HeaderText = "Description";

                    dgvEvents.Columns["EventDate"]
                        .DefaultCellStyle.Format = "dd MMM yyyy";

                    dgvEvents.Columns["EventID"].FillWeight = 55;
                    dgvEvents.Columns["EventName"].FillWeight = 130;
                    dgvEvents.Columns["CategoryName"].FillWeight = 90;
                    dgvEvents.Columns["VenueName"].FillWeight = 100;
                    dgvEvents.Columns["EventDate"].FillWeight = 85;
                    dgvEvents.Columns["Description"].FillWeight = 180;

                    // Hide foreign-key columns
                    dgvEvents.Columns["CategoryID"].Visible = false;
                    dgvEvents.Columns["VenueID"].Visible = false;
                }

                dgvEvents.ClearSelection();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to load the event records. Please check the database connection.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // VALIDATION
        // ============================================================

        private bool IsInputValid()
        {
            if (string.IsNullOrWhiteSpace(txtEventName.Text))
            {
                MessageBox.Show(
                    "Please enter the event name.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEventName.Focus();
                return false;
            }

            if (cmbCategory.SelectedIndex < 0 ||
                cmbCategory.SelectedValue == null)
            {
                MessageBox.Show(
                    "Please select a category.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbCategory.Focus();
                return false;
            }

            if (cmbVenue.SelectedIndex < 0 ||
                cmbVenue.SelectedValue == null)
            {
                MessageBox.Show(
                    "Please select a venue.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbVenue.Focus();
                return false;
            }

            return true;
        }

        // ============================================================
        // ADD EVENT
        // ============================================================

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsInputValid())
            {
                return;
            }

            try
            {
                string sql =
                    "INSERT INTO Events " +
                    "(EventName, CategoryID, VenueID, EventDate, Description) " +
                    "VALUES " +
                    "(@EventName, @CategoryID, @VenueID, @EventDate, @Description)";

                DatabaseHelper.ExecuteNonQuery(
                    sql,
                    DatabaseHelper.Param(
                        "@EventName",
                        txtEventName.Text.Trim()),

                    DatabaseHelper.Param(
                        "@CategoryID",
                        Convert.ToInt32(cmbCategory.SelectedValue)),

                    DatabaseHelper.Param(
                        "@VenueID",
                        Convert.ToInt32(cmbVenue.SelectedValue)),

                    DatabaseHelper.Param(
                        "@EventDate",
                        dtpEventDate.Value.Date),

                    DatabaseHelper.Param(
                        "@Description",
                        txtDescription.Text.Trim())
                );

                MessageBox.Show(
                    "Event added successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearForm();
                LoadEvents();
            }
            catch (SqlException)
            {
                MessageBox.Show(
                    "Unable to save the event. Please check the entered information and try again.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to save the event. Please try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // UPDATE EVENT
        // ============================================================

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedEventId == 0)
            {
                MessageBox.Show(
                    "Please select an event from the list first.",
                    "Update",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (!IsInputValid())
            {
                return;
            }

            try
            {
                string sql =
                    "UPDATE Events SET " +
                    "EventName = @EventName, " +
                    "CategoryID = @CategoryID, " +
                    "VenueID = @VenueID, " +
                    "EventDate = @EventDate, " +
                    "Description = @Description " +
                    "WHERE EventID = @EventID";

                DatabaseHelper.ExecuteNonQuery(
                    sql,

                    DatabaseHelper.Param(
                        "@EventName",
                        txtEventName.Text.Trim()),

                    DatabaseHelper.Param(
                        "@CategoryID",
                        Convert.ToInt32(cmbCategory.SelectedValue)),

                    DatabaseHelper.Param(
                        "@VenueID",
                        Convert.ToInt32(cmbVenue.SelectedValue)),

                    DatabaseHelper.Param(
                        "@EventDate",
                        dtpEventDate.Value.Date),

                    DatabaseHelper.Param(
                        "@Description",
                        txtDescription.Text.Trim()),

                    DatabaseHelper.Param(
                        "@EventID",
                        selectedEventId)
                );

                MessageBox.Show(
                    "Event updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearForm();
                LoadEvents();
            }
            catch (SqlException)
            {
                MessageBox.Show(
                    "Unable to update the event. Please try again.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to update the event. Please try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // DELETE EVENT
        // ============================================================

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedEventId == 0)
            {
                MessageBox.Show(
                    "Please select an event from the list first.",
                    "Delete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DialogResult answer = MessageBox.Show(
                "Do you really want to delete this event?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string sql =
                    "DELETE FROM Events WHERE EventID = @EventID";

                DatabaseHelper.ExecuteNonQuery(
                    sql,
                    DatabaseHelper.Param(
                        "@EventID",
                        selectedEventId)
                );

                MessageBox.Show(
                    "Event deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearForm();
                LoadEvents();
            }
            catch (SqlException ex)
            {
                if (DatabaseHelper.IsForeignKeyError(ex))
                {
                    MessageBox.Show(
                        "This event cannot be deleted because students are already registered in this event.\n\n" +
                        "Please remove the participant records of this event first.",
                        "Delete Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Unable to delete the event. Please try again.",
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to delete the event. Please try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // CLEAR BUTTON
        // ============================================================

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // ============================================================
        // CLEAR FORM
        // ============================================================

        private void ClearForm()
        {
            selectedEventId = 0;

            txtEventName.Clear();
            txtDescription.Clear();

            cmbCategory.SelectedIndex = -1;
            cmbVenue.SelectedIndex = -1;

            dtpEventDate.Value = DateTime.Today;

            dgvEvents.ClearSelection();

            txtEventName.Focus();
        }

        // ============================================================
        // GRID ROW CLICK
        // ============================================================

        private void dgvEvents_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvEvents.Rows[e.RowIndex];

            // Event ID
            if (row.Cells["EventID"].Value != DBNull.Value)
            {
                selectedEventId =
                    Convert.ToInt32(row.Cells["EventID"].Value);
            }

            // Event Name
            txtEventName.Text =
                Convert.ToString(row.Cells["EventName"].Value);

            // Description
            if (row.Cells["Description"].Value == DBNull.Value)
            {
                txtDescription.Clear();
            }
            else
            {
                txtDescription.Text =
                    Convert.ToString(row.Cells["Description"].Value);
            }

            // Category
            if (row.Cells["CategoryID"].Value != DBNull.Value)
            {
                cmbCategory.SelectedValue =
                    Convert.ToInt32(row.Cells["CategoryID"].Value);
            }
            else
            {
                cmbCategory.SelectedIndex = -1;
            }

            // Venue
            if (row.Cells["VenueID"].Value != DBNull.Value)
            {
                cmbVenue.SelectedValue =
                    Convert.ToInt32(row.Cells["VenueID"].Value);
            }
            else
            {
                cmbVenue.SelectedIndex = -1;
            }

            // Event Date
            if (row.Cells["EventDate"].Value != DBNull.Value)
            {
                dtpEventDate.Value =
                    Convert.ToDateTime(row.Cells["EventDate"].Value);
            }
            else
            {
                dtpEventDate.Value = DateTime.Today;
            }
        }
    }
}