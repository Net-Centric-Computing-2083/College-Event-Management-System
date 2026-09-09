using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CollegeEventManagementSystem.Data;
using CollegeEventManagementSystem.UI;

namespace CollegeEventManagementSystem.Forms
{
    /// <summary>
    /// Participant Registration and Participant Management module.
    /// A participant is one student registered in one event, so this form joins
    /// the Students table and the Events table to show readable names.
    /// </summary>
    public partial class ParticipantForm : Form
    {
        private int selectedParticipantId = 0;

        // While the ComboBoxes are being filled the SelectedIndexChanged event fires.
        // This flag stops the grid from being reloaded during that first filling.
        private bool isLoadingCombos = false;

        public ParticipantForm()
        {
            InitializeComponent();
            Theme.StyleForm(this);
            Theme.StylePrimaryButton(btnRegister);
            Theme.StyleSecondaryButton(btnUpdate);
            Theme.StyleDangerButton(btnDelete);
            Theme.StyleSecondaryButton(btnClear);
            Theme.StyleSecondaryButton(btnRefresh);
            Theme.StyleGrid(dgvParticipants);
        }

        private void ParticipantForm_Load(object sender, EventArgs e)
        {
            dtpRegistrationDate.Value = DateTime.Today;

            LoadEvents();
            LoadStudents();
            LoadParticipants(0);

            if (cmbEvent.Items.Count == 0)
            {
                MessageBox.Show("No events are available. Please create an event first.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cmbStudent.Items.Count == 0)
            {
                MessageBox.Show("No students are available. Please register a student first.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>Fills the event ComboBox and the filter ComboBox.</summary>
        private void LoadEvents()
        {
            try
            {
                isLoadingCombos = true;

                string sql = "SELECT EventID, EventName FROM Events ORDER BY EventName";
                DataTable events = DatabaseHelper.GetDataTable(sql);

                cmbEvent.DisplayMember = "EventName";
                cmbEvent.ValueMember = "EventID";
                cmbEvent.DataSource = events;
                cmbEvent.SelectedIndex = -1;

                // A copy of the same list with one extra row is used for the filter,
                // so the user can also choose to see all participants.
                DataTable filterEvents = events.Copy();
                DataRow allRow = filterEvents.NewRow();
                allRow["EventID"] = 0;
                allRow["EventName"] = "All Events";
                filterEvents.Rows.InsertAt(allRow, 0);

                cmbFilterEvent.DisplayMember = "EventName";
                cmbFilterEvent.ValueMember = "EventID";
                cmbFilterEvent.DataSource = filterEvents;
                cmbFilterEvent.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load the event list.", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoadingCombos = false;
            }
        }

        /// <summary>Fills the student ComboBox.</summary>
        private void LoadStudents()
        {
            try
            {
                string sql = "SELECT StudentID, StudentName FROM Students ORDER BY StudentName";

                cmbStudent.DisplayMember = "StudentName";
                cmbStudent.ValueMember = "StudentID";
                cmbStudent.DataSource = DatabaseHelper.GetDataTable(sql);
                cmbStudent.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load the student list.", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads the participant records with a JOIN query.
        /// When eventId is 0 all participants are shown, otherwise only the
        /// participants of the selected event.
        /// </summary>
        private void LoadParticipants(int eventId)
        {
            try
            {
                string sql =
                    "SELECT p.ParticipantID, s.StudentName, e.EventName, p.RegistrationDate, " +
                    "p.EventID, p.StudentID " +
                    "FROM Participants p " +
                    "INNER JOIN Students s ON p.StudentID = s.StudentID " +
                    "INNER JOIN Events e ON p.EventID = e.EventID ";

                DataTable table;

                if (eventId > 0)
                {
                    sql = sql + "WHERE p.EventID = @EventID ORDER BY s.StudentName";
                    table = DatabaseHelper.GetDataTable(sql, DatabaseHelper.Param("@EventID", eventId));
                }
                else
                {
                    sql = sql + "ORDER BY e.EventName, s.StudentName";
                    table = DatabaseHelper.GetDataTable(sql);
                }

                dgvParticipants.DataSource = table;

                dgvParticipants.Columns["ParticipantID"].HeaderText = "Participant ID";
                dgvParticipants.Columns["StudentName"].HeaderText = "Student Name";
                dgvParticipants.Columns["EventName"].HeaderText = "Event Name";
                dgvParticipants.Columns["RegistrationDate"].HeaderText = "Registration Date";
                dgvParticipants.Columns["RegistrationDate"].DefaultCellStyle.Format = "dd MMM yyyy";
                dgvParticipants.Columns["ParticipantID"].FillWeight = 80;
                dgvParticipants.Columns["StudentName"].FillWeight = 130;
                dgvParticipants.Columns["EventName"].FillWeight = 130;
                dgvParticipants.Columns["RegistrationDate"].FillWeight = 100;
                dgvParticipants.Columns["EventID"].Visible = false;
                dgvParticipants.Columns["StudentID"].Visible = false;
                dgvParticipants.ClearSelection();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load the participant records. Please check the database connection.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsInputValid()
        {
            if (cmbEvent.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an event.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEvent.Focus();
                return false;
            }

            if (cmbStudent.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a student.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStudent.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks whether the student is already registered in the same event.
        /// The database also has a UNIQUE constraint on (EventID, StudentID),
        /// so duplicates are blocked in the application and in the database.
        /// </summary>
        private bool IsDuplicateRegistration(int eventId, int studentId, int ignoreParticipantId)
        {
            string sql = "SELECT COUNT(*) FROM Participants " +
                         "WHERE EventID = @EventID AND StudentID = @StudentID AND ParticipantID <> @ParticipantID";

            int count = DatabaseHelper.GetCount(sql,
                DatabaseHelper.Param("@EventID", eventId),
                DatabaseHelper.Param("@StudentID", studentId),
                DatabaseHelper.Param("@ParticipantID", ignoreParticipantId));

            return count > 0;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!IsInputValid())
            {
                return;
            }

            try
            {
                int eventId = Convert.ToInt32(cmbEvent.SelectedValue);
                int studentId = Convert.ToInt32(cmbStudent.SelectedValue);

                if (IsDuplicateRegistration(eventId, studentId, 0))
                {
                    MessageBox.Show("This student is already registered for the selected event.",
                        "Duplicate Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = "INSERT INTO Participants (EventID, StudentID, RegistrationDate) " +
                             "VALUES (@EventID, @StudentID, @RegistrationDate)";

                DatabaseHelper.ExecuteNonQuery(sql,
                    DatabaseHelper.Param("@EventID", eventId),
                    DatabaseHelper.Param("@StudentID", studentId),
                    DatabaseHelper.Param("@RegistrationDate", dtpRegistrationDate.Value.Date));

                MessageBox.Show("Participant registered successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                RefreshGrid();
            }
            catch (SqlException ex)
            {
                if (DatabaseHelper.IsDuplicateError(ex))
                {
                    MessageBox.Show("This student is already registered for the selected event.",
                        "Duplicate Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Unable to save the registration. Please try again.",
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to save the registration. Please try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedParticipantId == 0)
            {
                MessageBox.Show("Please select a participant from the list first.", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!IsInputValid())
            {
                return;
            }

            try
            {
                int eventId = Convert.ToInt32(cmbEvent.SelectedValue);
                int studentId = Convert.ToInt32(cmbStudent.SelectedValue);

                if (IsDuplicateRegistration(eventId, studentId, selectedParticipantId))
                {
                    MessageBox.Show("This student is already registered for the selected event.",
                        "Duplicate Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = "UPDATE Participants SET EventID = @EventID, StudentID = @StudentID, " +
                             "RegistrationDate = @RegistrationDate WHERE ParticipantID = @ParticipantID";

                DatabaseHelper.ExecuteNonQuery(sql,
                    DatabaseHelper.Param("@EventID", eventId),
                    DatabaseHelper.Param("@StudentID", studentId),
                    DatabaseHelper.Param("@RegistrationDate", dtpRegistrationDate.Value.Date),
                    DatabaseHelper.Param("@ParticipantID", selectedParticipantId));

                MessageBox.Show("Participant updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                RefreshGrid();
            }
            catch (SqlException ex)
            {
                if (DatabaseHelper.IsDuplicateError(ex))
                {
                    MessageBox.Show("This student is already registered for the selected event.",
                        "Duplicate Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Unable to update the record. Please try again.",
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to update the record. Please try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedParticipantId == 0)
            {
                MessageBox.Show("Please select a participant from the list first.", "Delete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult answer = MessageBox.Show("Do you really want to delete this participant record?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string sql = "DELETE FROM Participants WHERE ParticipantID = @ParticipantID";

                DatabaseHelper.ExecuteNonQuery(sql,
                    DatabaseHelper.Param("@ParticipantID", selectedParticipantId));

                MessageBox.Show("Participant deleted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                RefreshGrid();
            }
            catch (SqlException ex)
            {
                if (DatabaseHelper.IsForeignKeyError(ex))
                {
                    MessageBox.Show(
                        "This participant cannot be deleted because attendance or certificate records exist.\n" +
                        "Please delete those records first.",
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void cmbFilterEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoadingCombos)
            {
                return;
            }

            RefreshGrid();
        }

        /// <summary>Reloads the grid using the event chosen in the filter ComboBox.</summary>
        private void RefreshGrid()
        {
            int filterEventId = 0;

            if (cmbFilterEvent.SelectedValue != null)
            {
                int parsedId;

                if (int.TryParse(cmbFilterEvent.SelectedValue.ToString(), out parsedId))
                {
                    filterEventId = parsedId;
                }
            }

            LoadParticipants(filterEventId);
        }

        private void ClearForm()
        {
            selectedParticipantId = 0;
            cmbEvent.SelectedIndex = -1;
            cmbStudent.SelectedIndex = -1;
            dtpRegistrationDate.Value = DateTime.Today;
            dgvParticipants.ClearSelection();
        }

        private void dgvParticipants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvParticipants.Rows[e.RowIndex];

            selectedParticipantId = Convert.ToInt32(row.Cells["ParticipantID"].Value);
            cmbEvent.SelectedValue = Convert.ToInt32(row.Cells["EventID"].Value);
            cmbStudent.SelectedValue = Convert.ToInt32(row.Cells["StudentID"].Value);

            if (row.Cells["RegistrationDate"].Value != DBNull.Value)
            {
                dtpRegistrationDate.Value = Convert.ToDateTime(row.Cells["RegistrationDate"].Value);
            }
            else
            {
                dtpRegistrationDate.Value = DateTime.Today;
            }
        }
    }
}
