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
            Theme.StyleSecondaryButton(btnClearFilter);
            Theme.StyleGrid(dgvParticipants);
        }

        private void ParticipantForm_Load(object sender, EventArgs e)
        {
            dtpRegistrationDate.Value = DateTime.Today;

            LoadEvents();
            LoadStudents();
            LoadParticipants(0, 0);

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
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load the event list.\n\nError: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoadingCombos = false;
            }
        }

        /// <summary>Fills the student ComboBox and the student filter ComboBox.</summary>
        private void LoadStudents()
        {
            try
            {
                isLoadingCombos = true;

                // Select FullName from DB but alias to StudentName to keep UI code unchanged
                string sql = "SELECT StudentID, FullName AS StudentName FROM Students ORDER BY FullName";
                DataTable students = DatabaseHelper.GetDataTable(sql);

                cmbStudent.DisplayMember = "StudentName";
                cmbStudent.ValueMember = "StudentID";
                cmbStudent.DataSource = students;
                cmbStudent.SelectedIndex = -1;

                // A copy of the same list with one extra row is used for the filter,
                // so the user can also choose to see the participants of every student.
                DataTable filterStudents = students.Copy();
                DataRow allRow = filterStudents.NewRow();
                allRow["StudentID"] = 0;
                allRow["StudentName"] = "All Students";
                filterStudents.Rows.InsertAt(allRow, 0);

                cmbFilterStudent.DisplayMember = "StudentName";
                cmbFilterStudent.ValueMember = "StudentID";
                cmbFilterStudent.DataSource = filterStudents;
                cmbFilterStudent.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load the student list.\n\nError: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoadingCombos = false;
            }
        }

        /// <summary>
        /// Loads the participant records with a JOIN query.
        /// The list can be filtered by event, by student, or by both at the same time.
        /// A value of 0 means "all", so one single parameterized query is enough.
        /// </summary>
        private void LoadParticipants(int eventId, int studentId)
        {
            try
            {
                string sql =
                    "SELECT p.ParticipantID, s.FullName AS StudentName, e.EventName, p.RegistrationDate, " +
                    "p.EventID, p.StudentID " +
                    "FROM Participants p " +
                    "INNER JOIN Students s ON p.StudentID = s.StudentID " +
                    "INNER JOIN Events e ON p.EventID = e.EventID " +
                    "WHERE (@EventID = 0 OR p.EventID = @EventID) " +
                    "AND (@StudentID = 0 OR p.StudentID = @StudentID) " +
                    "ORDER BY e.EventName, s.FullName";

                DataTable table = DatabaseHelper.GetDataTable(sql,
                    DatabaseHelper.Param("@EventID", eventId),
                    DatabaseHelper.Param("@StudentID", studentId));

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

                grpFilter.Text = "Filter Participants  (" + table.Rows.Count.ToString() + " records)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load the participant records. Please check the database connection.\n\nError: " + ex.Message,
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

        /// <summary>Reads the date of one event from the database.</summary>
        private DateTime? GetEventDate(int eventId)
        {
            object value = DatabaseHelper.ExecuteScalar(
                "SELECT EventDate FROM Events WHERE EventID = @EventID",
                DatabaseHelper.Param("@EventID", eventId));

            if (value == null || value == DBNull.Value)
            {
                return null;
            }

            return Convert.ToDateTime(value);
        }

        /// <summary>
        /// Keeps the participant data consistent with the event: registering a student
        /// after the event is already over is unusual, so the user has to confirm it.
        /// </summary>
        private bool IsRegistrationDateAccepted(int eventId)
        {
            DateTime? eventDate = GetEventDate(eventId);

            if (eventDate == null || dtpRegistrationDate.Value.Date <= eventDate.Value.Date)
            {
                return true;
            }

            DialogResult answer = MessageBox.Show(
                "This event took place on " + eventDate.Value.ToString("dd MMM yyyy") +
                ", which is before the selected registration date.\n\n" +
                "Do you still want to save this registration?",
                "Check the Dates", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return answer == DialogResult.Yes;
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

                if (!IsRegistrationDateAccepted(eventId))
                {
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

                if (!IsRegistrationDateAccepted(eventId))
                {
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

        private void cmbFilterStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoadingCombos)
            {
                return;
            }

            RefreshGrid();
        }

        /// <summary>Removes both filters and shows every participant record again.</summary>
        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            isLoadingCombos = true;

            if (cmbFilterEvent.Items.Count > 0)
            {
                cmbFilterEvent.SelectedIndex = 0;
            }

            if (cmbFilterStudent.Items.Count > 0)
            {
                cmbFilterStudent.SelectedIndex = 0;
            }

            isLoadingCombos = false;

            RefreshGrid();
        }

        /// <summary>Reloads the grid using the event and the student chosen in the filters.</summary>
        private void RefreshGrid()
        {
            LoadParticipants(GetFilterValue(cmbFilterEvent), GetFilterValue(cmbFilterStudent));
        }

        /// <summary>Reads the ID selected in a filter ComboBox (0 means "show all").</summary>
        private int GetFilterValue(ComboBox filterCombo)
        {
            if (filterCombo.SelectedValue == null)
            {
                return 0;
            }

            int parsedId;

            if (int.TryParse(filterCombo.SelectedValue.ToString(), out parsedId))
            {
                return parsedId;
            }

            return 0;
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
