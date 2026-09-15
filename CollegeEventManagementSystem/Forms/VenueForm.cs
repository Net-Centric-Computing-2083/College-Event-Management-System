using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CollegeEventManagementSystem.Data;
using CollegeEventManagementSystem.UI;

namespace CollegeEventManagementSystem.Forms
{
    /// <summary>
    /// Venue Management module. Full CRUD on the Venues table.
    /// </summary>
    public partial class VenueForm : Form
    {
        private int selectedVenueId = 0;

        public VenueForm()
        {
            InitializeComponent();
            Theme.StyleForm(this);
            Theme.StylePrimaryButton(btnAdd);
            Theme.StyleSecondaryButton(btnUpdate);
            Theme.StyleDangerButton(btnDelete);
            Theme.StyleSecondaryButton(btnClear);
            Theme.StyleGrid(dgvVenues);
        }

        private void VenueForm_Load(object sender, EventArgs e)
        {
            LoadVenues();
        }

        private void LoadVenues()
        {
            try
            {
                string sql = "SELECT VenueID, VenueName, Location, Capacity FROM Venues ORDER BY VenueName";

                dgvVenues.DataSource = DatabaseHelper.GetDataTable(sql);

                dgvVenues.Columns["VenueID"].HeaderText = "Venue ID";
                dgvVenues.Columns["VenueName"].HeaderText = "Venue Name";
                dgvVenues.Columns["Location"].HeaderText = "Location";
                dgvVenues.Columns["Capacity"].HeaderText = "Capacity";
                dgvVenues.Columns["VenueID"].FillWeight = 60;
                dgvVenues.Columns["VenueName"].FillWeight = 120;
                dgvVenues.Columns["Location"].FillWeight = 150;
                dgvVenues.Columns["Capacity"].FillWeight = 70;
                dgvVenues.ClearSelection();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load the venue records. Please check the database connection.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Validates the venue name and the capacity value.</summary>
        private bool IsInputValid()
        {
            if (txtVenueName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the venue name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVenueName.Focus();
                return false;
            }

            int capacity;

            if (!int.TryParse(txtCapacity.Text.Trim(), out capacity))
            {
                MessageBox.Show("Please enter the capacity as a number.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCapacity.Focus();
                return false;
            }

            if (capacity <= 0)
            {
                MessageBox.Show("Capacity must be greater than zero.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCapacity.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks whether another venue with the same name already exists, so the same
        /// venue can never be saved twice.
        /// </summary>
        private bool IsDuplicateVenue(string venueName, int ignoreVenueId)
        {
            string sql = "SELECT COUNT(*) FROM Venues " +
                         "WHERE VenueName = @VenueName AND VenueID <> @VenueID";

            int count = DatabaseHelper.GetCount(sql,
                DatabaseHelper.Param("@VenueName", venueName),
                DatabaseHelper.Param("@VenueID", ignoreVenueId));

            return count > 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsInputValid())
            {
                return;
            }

            try
            {
                if (IsDuplicateVenue(txtVenueName.Text.Trim(), 0))
                {
                    MessageBox.Show("A venue with this name already exists. Please use a different name.",
                        "Duplicate Venue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVenueName.Focus();
                    return;
                }

                string sql = "INSERT INTO Venues (VenueName, Location, Capacity) " +
                             "VALUES (@VenueName, @Location, @Capacity)";

                DatabaseHelper.ExecuteNonQuery(sql,
                    DatabaseHelper.Param("@VenueName", txtVenueName.Text.Trim()),
                    DatabaseHelper.Param("@Location", txtLocation.Text.Trim()),
                    DatabaseHelper.Param("@Capacity", int.Parse(txtCapacity.Text.Trim())));

                MessageBox.Show("Venue added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadVenues();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unable to save the record. Please check the entered information and try again.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to save the record. Please try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedVenueId == 0)
            {
                MessageBox.Show("Please select a venue from the list first.", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!IsInputValid())
            {
                return;
            }

            try
            {
                if (IsDuplicateVenue(txtVenueName.Text.Trim(), selectedVenueId))
                {
                    MessageBox.Show("A venue with this name already exists. Please use a different name.",
                        "Duplicate Venue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVenueName.Focus();
                    return;
                }

                string sql = "UPDATE Venues SET VenueName = @VenueName, Location = @Location, " +
                             "Capacity = @Capacity WHERE VenueID = @VenueID";

                DatabaseHelper.ExecuteNonQuery(sql,
                    DatabaseHelper.Param("@VenueName", txtVenueName.Text.Trim()),
                    DatabaseHelper.Param("@Location", txtLocation.Text.Trim()),
                    DatabaseHelper.Param("@Capacity", int.Parse(txtCapacity.Text.Trim())),
                    DatabaseHelper.Param("@VenueID", selectedVenueId));

                MessageBox.Show("Venue updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadVenues();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unable to update the record. Please try again.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to update the record. Please try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedVenueId == 0)
            {
                MessageBox.Show("Please select a venue from the list first.", "Delete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult answer = MessageBox.Show("Do you really want to delete this venue?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string sql = "DELETE FROM Venues WHERE VenueID = @VenueID";

                DatabaseHelper.ExecuteNonQuery(sql,
                    DatabaseHelper.Param("@VenueID", selectedVenueId));

                MessageBox.Show("Venue deleted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadVenues();
            }
            catch (SqlException ex)
            {
                if (DatabaseHelper.IsForeignKeyError(ex))
                {
                    MessageBox.Show(
                        "This venue cannot be deleted because one or more events are using it.\n" +
                        "Please delete or change those events first.",
                        "Delete Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Unable to delete the record. Please try again.",
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to delete the record. Please try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            selectedVenueId = 0;
            txtVenueName.Clear();
            txtLocation.Clear();
            txtCapacity.Clear();
            dgvVenues.ClearSelection();
            txtVenueName.Focus();
        }

        private void dgvVenues_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvVenues.Rows[e.RowIndex];

            selectedVenueId = Convert.ToInt32(row.Cells["VenueID"].Value);
            txtVenueName.Text = Convert.ToString(row.Cells["VenueName"].Value);
            txtLocation.Text = Convert.ToString(row.Cells["Location"].Value);
            txtCapacity.Text = Convert.ToString(row.Cells["Capacity"].Value);
        }
    }
}
