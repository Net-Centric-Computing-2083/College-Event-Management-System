using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CollegeEventManagementSystem.Data;
using CollegeEventManagementSystem.UI;

namespace CollegeEventManagementSystem.Forms
{
    /// <summary>
    /// Attendance module.
    /// The user first selects an event, then the participants of that event are
    /// loaded into the participant ComboBox and their attendance can be recorded.
    /// </summary>
    public partial class AttendanceForm : Form
    {
        private int selectedAttendanceId = 0;
        private bool isLoadingCombos = false;

        public AttendanceForm()
        {
            InitializeComponent();
            Theme.StyleForm(this);
            Theme.StylePrimaryButton(btnSave);
            Theme.StyleSecondaryButton(btnUpdate);
            Theme.StyleDangerButton(btnDelete);
            Theme.StyleSecondaryButton(btnClear);
            Theme.StyleGrid(dgvAttendance);
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            dtpAttendanceDate.Value = DateTime.Today;
            cmbStatus.SelectedIndex = 0;

            LoadEvents();

            if (cmbEvent.Items.Count == 0)
            {
                MessageBox.Show("No events are available. Please create an event first.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Show the first event when the form opens. Changing the selection
            // fires cmbEvent_SelectedIndexChanged, which loads the participants
            // and the attendance records of that event.
            cmbEvent.SelectedIndex = 0;
        }

        private void LoadEvents()
        {
            try
            {
                isLoadingCombos = true;

                string sql = "SELECT EventID, EventName FROM Events ORDER BY EventName";

                cmbEvent.DisplayMember = "EventName";
                cmbEvent.ValueMember = "EventID";
                cmbEvent.DataSource = DatabaseHelper.GetDataTable(sql);
                cmbEvent.SelectedIndex = -1;
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

        /// <summary>Returns the EventID chosen in the event ComboBox, or 0 when nothing is chosen.</summary>
        private int GetSelectedEventId()
        {
            if (cmbEvent.SelectedValue == null)
            {
                return 0;
            }

            int eventId;

            if (int.TryParse(cmbEvent.SelectedValue.ToString(), out eventId))
            {
                return eventId;
            }

            return 0;
        }

        /// <summary>
        /// Loads the students registered in the selected event and also refreshes
        /// the attendance grid of that event.
        /// </summary>
        private void LoadParticipantsOfSelectedEvent()
        {
            int eventId = GetSelectedEventId();

            if (eventId == 0)
            {
                return;
            }

            try
            {
                string sql = "SELECT p.ParticipantID, s.StudentName " +
                             "FROM Participants p " +
                             "INNER JOIN Students s ON p.StudentID = s.StudentID " +
                             "WHERE p.EventID = @EventID " +
                             "ORDER BY s.StudentName";

                DataTable participants = DatabaseHelper.GetDataTable(sql,
                    DatabaseHelper.Param("@EventID", eventId));

                cmbParticipant.DisplayMember = "StudentName";
                cmbParticipant.ValueMember = "ParticipantID";
                cmbParticipant.DataSource = participants;
                cmbParticipant.SelectedIndex = -1;

                LoadAttendance(eventId);

                if (participants.Rows.Count == 0)
                {
                    MessageBox.Show("No students are registered for this event. Please register participants first.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load the participants of this event.", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Loads the attendance records of one event using JOIN queries.</summary>
        private void LoadAttendance(int eventId)
        {
            try
            {
                string sql =
                    "SELECT a.AttendanceID, s.StudentName, e.EventName, a.AttendanceDate, a.Status, a.ParticipantID " +
                    "FROM Attendance a " +
                    "INNER JOIN Participants p ON a.ParticipantID = p.ParticipantID " +
                    "INNER JOIN Students s ON p.StudentID = s.StudentID " +
                    "INNER JOIN Events e ON p.EventID = e.EventID " +
                    "WHERE p.EventID = @EventID " +
                    "ORDER BY s.StudentName";

                dgvAttendance.DataSource = DatabaseHelper.GetDataTable(sql,
                    DatabaseHelper.Param("@EventID", eventId));

                dgvAttendance.Columns["AttendanceID"].HeaderText = "Attendance ID";
                dgvAttendance.Columns["StudentName"].HeaderText = "Student Name";
                dgvAttendance.Columns["EventName"].HeaderText = "Event Name";
                dgvAttendance.Columns["AttendanceDate"].HeaderText = "Attendance Date";
                dgvAttendance.Columns["Status"].HeaderText = "Status";
                dgvAttendance.Columns["AttendanceDate"].DefaultCellStyle.Format = "dd MMM yyyy";
                dgvAttendance.Columns["AttendanceID"].FillWeight = 80;
                dgvAttendance.Columns["StudentName"].FillWeight = 130;
                dgvAttendance.Columns["EventName"].FillWeight = 130;
                dgvAttendance.Columns["AttendanceDate"].FillWeight = 100;
                dgvAttendance.Columns["Status"].FillWeight = 70;
                dgvAttendance.Columns["ParticipantID"].Visible = false;
                dgvAttendance.ClearSelection();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load the attendance records.", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (cmbParticipant.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a participant.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbParticipant.Focus();
                return false;
            }

            if (cmbStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Please select the attendance status.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsInputValid())
            {
                return;
            }

            try
            {
                string sql = "INSERT INTO Attendance (ParticipantID, AttendanceDate, Status) " +
                             "VALUES (@ParticipantID, @AttendanceDate, @Status)";

                DatabaseHelper.ExecuteNonQuery(sql,
                    DatabaseHelper.Param("@ParticipantID", Convert.ToInt32(cmbParticipant.SelectedValue)),
                    DatabaseHelper.Param("@AttendanceDate", dtpAttendanceDate.Value.Date),
                    DatabaseHelper.Param("@Status", cmbStatus.SelectedItem.ToString()));

                MessageBox.Show("Attendance saved successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                selectedAttendanceId = 0;
                LoadAttendance(GetSelectedEventId());
            }
            catch (SqlException ex)
            {
                if (DatabaseHelper.IsDuplicateError(ex))
                {
                    MessageBox.Show("Attendance of this participant is already recorded for the selected date.",
                        "Duplicate Attendance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Unable to save the attendance. Please try again.",
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to save the attendance. Please try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedAttendanceId == 0)
            {
                MessageBox.Show("Please select an attendance record from the list first.", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!IsInputValid())
            {
                return;
            }

            try
            {
                string sql = "UPDATE Attendance SET ParticipantID = @ParticipantID, " +
                             "AttendanceDate = @AttendanceDate, Status = @Status " +
                             "WHERE AttendanceID = @AttendanceID";

                DatabaseHelper.ExecuteNonQuery(sql,
                    DatabaseHelper.Param("@ParticipantID", Convert.ToInt32(cmbParticipant.SelectedValue)),
                    DatabaseHelper.Param("@AttendanceDate", dtpAttendanceDate.Value.Date),
                    DatabaseHelper.Param("@Status", cmbStatus.SelectedItem.ToString()),
                    DatabaseHelper.Param("@AttendanceID", selectedAttendanceId));

                MessageBox.Show("Attendance updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                selectedAttendanceId = 0;
                LoadAttendance(GetSelectedEventId());
            }
            catch (SqlException ex)
            {
                if (DatabaseHelper.IsDuplicateError(ex))
                {
                    MessageBox.Show("Attendance of this participant is already recorded for the selected date.",
                        "Duplicate Attendance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Unable to update the attendance. Please try again.",
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to update the attendance. Please try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedAttendanceId == 0)
            {
                MessageBox.Show("Please select an attendance record from the list first.", "Delete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult answer = MessageBox.Show("Do you really want to delete this attendance record?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string sql = "DELETE FROM Attendance WHERE AttendanceID = @AttendanceID";

                DatabaseHelper.ExecuteNonQuery(sql,
                    DatabaseHelper.Param("@AttendanceID", selectedAttendanceId));

                MessageBox.Show("Attendance record deleted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadAttendance(GetSelectedEventId());
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to delete the attendance record. Please try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            selectedAttendanceId = 0;
            cmbParticipant.SelectedIndex = -1;
            cmbStatus.SelectedIndex = 0;
            dtpAttendanceDate.Value = DateTime.Today;
            dgvAttendance.ClearSelection();
        }

        private void cmbEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoadingCombos)
            {
                return;
            }

            selectedAttendanceId = 0;
            LoadParticipantsOfSelectedEvent();
        }

        private void dgvAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvAttendance.Rows[e.RowIndex];

            selectedAttendanceId = Convert.ToInt32(row.Cells["AttendanceID"].Value);
            cmbParticipant.SelectedValue = Convert.ToInt32(row.Cells["ParticipantID"].Value);
            cmbStatus.SelectedItem = Convert.ToString(row.Cells["Status"].Value);

            if (row.Cells["AttendanceDate"].Value != DBNull.Value)
            {
                dtpAttendanceDate.Value = Convert.ToDateTime(row.Cells["AttendanceDate"].Value);
            }
            else
            {
                dtpAttendanceDate.Value = DateTime.Today;
            }
        }
    }
}
