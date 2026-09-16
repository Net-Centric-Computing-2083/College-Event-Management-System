using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CollegeEventManagementSystem.Data;
using CollegeEventManagementSystem.UI;

namespace CollegeEventManagementSystem.Forms
{
    /// <summary>
    /// Student Registration module.
    /// Full CRUD on the Students table plus the student search feature.
    /// </summary>
    public partial class StudentForm : Form
    {
        private int selectedStudentId = 0;

        public StudentForm()
        {
            InitializeComponent();
            Theme.StyleForm(this);
            Theme.StylePrimaryButton(btnAdd);
            Theme.StyleSecondaryButton(btnUpdate);
            Theme.StyleDangerButton(btnDelete);
            Theme.StyleSecondaryButton(btnClear);
            Theme.StylePrimaryButton(btnSearch);
            Theme.StyleSecondaryButton(btnShowAll);
            Theme.StyleGrid(dgvStudents);
            Theme.StyleGrid(dgvStudentEvents);
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        /// <summary>Loads every student record.</summary>
        private void LoadStudents()
        {
            try
            {
                string sql = "SELECT StudentID, FullName AS StudentName, Email, Phone, Program, Semester " +
                             "FROM Students ORDER BY FullName";

                ShowStudents(DatabaseHelper.GetDataTable(sql));
            }
            catch (Exception ex)
            {
                // Show the original error message to help diagnose connection/config issues.
                MessageBox.Show(
                    "Unable to load the student records. Please check the database connection.\n\n" +
                    "Error: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Student search. A parameterized LIKE query is used so the typed text
        /// can never change the meaning of the SQL statement (no SQL injection).
        /// </summary>
        private void SearchStudents(string searchText)
        {
            try
            {
                // Select FullName but expose it as StudentName to keep UI field names consistent
                string sql = "SELECT StudentID, FullName AS StudentName, Email, Phone, Program, Semester " +
                             "FROM Students " +
                             "WHERE FullName LIKE @Search OR Email LIKE @Search " +
                             "ORDER BY FullName";

                DataTable table = DatabaseHelper.GetDataTable(sql,
                    DatabaseHelper.Param("@Search", "%" + searchText + "%"));

                ShowStudents(table);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("No student matched your search.", "Search",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to search the student records. Please try again.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Shows a student DataTable in the DataGridView with readable headings.</summary>
        private void ShowStudents(DataTable table)
        {
            dgvStudents.DataSource = table;

            dgvStudents.Columns["StudentID"].HeaderText = "Student ID";
            dgvStudents.Columns["StudentName"].HeaderText = "Student Name";
            dgvStudents.Columns["Email"].HeaderText = "Email";
            dgvStudents.Columns["Phone"].HeaderText = "Phone";
            dgvStudents.Columns["Program"].HeaderText = "Program";
            dgvStudents.Columns["Semester"].HeaderText = "Semester";
            dgvStudents.Columns["StudentID"].FillWeight = 60;
            dgvStudents.Columns["StudentName"].FillWeight = 130;
            dgvStudents.Columns["Email"].FillWeight = 160;
            dgvStudents.Columns["Phone"].FillWeight = 90;
            dgvStudents.Columns["Program"].FillWeight = 110;
            dgvStudents.Columns["Semester"].FillWeight = 70;
            dgvStudents.ClearSelection();
        }

        /// <summary>
        /// Shows the list of events the selected student has participated in.
        /// Participants is joined with Events, and the attendance status of that
        /// participation is read with a small sub query.
        /// </summary>
        private void LoadStudentEvents(int studentId, string studentName)
        {
            try
            {
                string sql =
                    "SELECT e.EventName, e.EventDate, p.RegistrationDate, " +
                    "ISNULL((SELECT TOP 1 a.Status FROM Attendance a " +
                    "WHERE a.ParticipantID = p.ParticipantID " +
                    "ORDER BY a.AttendanceDate DESC), 'Not recorded') AS Status " +
                    "FROM Participants p " +
                    "INNER JOIN Events e ON p.EventID = e.EventID " +
                    "WHERE p.StudentID = @StudentID " +
                    "ORDER BY e.EventDate DESC";

                DataTable table = DatabaseHelper.GetDataTable(sql,
                    DatabaseHelper.Param("@StudentID", studentId));

                dgvStudentEvents.DataSource = table;

                dgvStudentEvents.Columns["EventName"].HeaderText = "Event Name";
                dgvStudentEvents.Columns["EventDate"].HeaderText = "Event Date";
                dgvStudentEvents.Columns["RegistrationDate"].HeaderText = "Registered On";
                dgvStudentEvents.Columns["Status"].HeaderText = "Attendance";
                dgvStudentEvents.Columns["EventDate"].DefaultCellStyle.Format = "dd MMM yyyy";
                dgvStudentEvents.Columns["RegistrationDate"].DefaultCellStyle.Format = "dd MMM yyyy";
                dgvStudentEvents.Columns["EventName"].FillWeight = 150;
                dgvStudentEvents.Columns["EventDate"].FillWeight = 95;
                dgvStudentEvents.Columns["RegistrationDate"].FillWeight = 95;
                dgvStudentEvents.Columns["Status"].FillWeight = 90;
                dgvStudentEvents.ClearSelection();

                if (table.Rows.Count == 0)
                {
                    lblStudentEvents.Text = "Events Participated - " + studentName + " (none)";
                }
                else
                {
                    lblStudentEvents.Text = "Events Participated - " + studentName +
                        " (" + table.Rows.Count.ToString() + ")";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load the events of this student. Please try again.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Empties the participated events list when no student is selected.</summary>
        private void ClearStudentEvents()
        {
            dgvStudentEvents.DataSource = null;
            lblStudentEvents.Text = "Events Participated (select a student)";
        }

        /// <summary>Validates the student details before they are saved.</summary>
        private bool IsInputValid()
        {
            if (txtStudentName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the student name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentName.Focus();
                return false;
            }

            string email = txtEmail.Text.Trim();

            // Email is required
            if (email.Length == 0)
            {
                MessageBox.Show("Please enter the student email.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Please enter a valid email address, for example student@example.com.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            string semesterText = txtSemester.Text.Trim();

            if (semesterText.Length > 0)
            {
                int semester;

                if (!int.TryParse(semesterText, out semester))
                {
                    MessageBox.Show("Please enter the semester as a number.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSemester.Focus();
                    return false;
                }

                if (semester < 1 || semester > 8)
                {
                    MessageBox.Show("Semester must be between 1 and 8.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSemester.Focus();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Prevents the same student from being registered twice. A student is treated
        /// as a duplicate when the email address is already used by somebody else, or
        /// when the same full name is already registered in the same program.
        /// </summary>
        private bool IsDuplicateStudent(int ignoreStudentId)
        {
            string email = txtEmail.Text.Trim();

            if (email.Length > 0)
            {
                string emailSql = "SELECT COUNT(*) FROM Students " +
                                  "WHERE Email = @Email AND StudentID <> @StudentID";

                int emailCount = DatabaseHelper.GetCount(emailSql,
                    DatabaseHelper.Param("@Email", email),
                    DatabaseHelper.Param("@StudentID", ignoreStudentId));

                if (emailCount > 0)
                {
                    MessageBox.Show("This email address is already registered for another student.",
                        "Duplicate Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return true;
                }
            }

            string nameSql = "SELECT COUNT(*) FROM Students " +
                             "WHERE FullName = @FullName " +
                             "AND ISNULL(Program, '') = ISNULL(@Program, '') " +
                             "AND StudentID <> @StudentID";

            int nameCount = DatabaseHelper.GetCount(nameSql,
                DatabaseHelper.Param("@FullName", txtStudentName.Text.Trim()),
                DatabaseHelper.Param("@Program", txtProgram.Text.Trim()),
                DatabaseHelper.Param("@StudentID", ignoreStudentId));

            if (nameCount > 0)
            {
                MessageBox.Show("This student is already registered in the same program.",
                    "Duplicate Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentName.Focus();
                return true;
            }

            return false;
        }

        /// <summary>Returns the semester as a number, or null when the box is empty.</summary>
        private object GetSemesterValue()
        {
            string semesterText = txtSemester.Text.Trim();

            if (semesterText.Length == 0)
            {
                return null;
            }

            return int.Parse(semesterText);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsInputValid())
            {
                return;
            }

            if (IsDuplicateStudent(0))
            {
                return;
            }

            try
            {
                // Students table uses FullName column in the database
                string sql = "INSERT INTO Students (FullName, Email, Phone, Program, Semester) " +
                             "VALUES (@StudentName, @Email, @Phone, @Program, @Semester)";

                DatabaseHelper.ExecuteNonQuery(sql,
                    DatabaseHelper.Param("@StudentName", txtStudentName.Text.Trim()),
                    DatabaseHelper.Param("@Email", txtEmail.Text.Trim()),
                    DatabaseHelper.Param("@Phone", txtPhone.Text.Trim()),
                    DatabaseHelper.Param("@Program", txtProgram.Text.Trim()),
                    DatabaseHelper.Param("@Semester", GetSemesterValue()));

                MessageBox.Show("Student registered successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadStudents();
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
            if (selectedStudentId == 0)
            {
                MessageBox.Show("Please select a student from the list first.", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!IsInputValid())
            {
                return;
            }

            if (IsDuplicateStudent(selectedStudentId))
            {
                return;
            }

            try
            {
                string sql = "UPDATE Students SET FullName = @StudentName, Email = @Email, " +
                             "Phone = @Phone, Program = @Program, Semester = @Semester " +
                             "WHERE StudentID = @StudentID";

                DatabaseHelper.ExecuteNonQuery(sql,
                    DatabaseHelper.Param("@StudentName", txtStudentName.Text.Trim()),
                    DatabaseHelper.Param("@Email", txtEmail.Text.Trim()),
                    DatabaseHelper.Param("@Phone", txtPhone.Text.Trim()),
                    DatabaseHelper.Param("@Program", txtProgram.Text.Trim()),
                    DatabaseHelper.Param("@Semester", GetSemesterValue()),
                    DatabaseHelper.Param("@StudentID", selectedStudentId));

                MessageBox.Show("Student updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadStudents();
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
            if (selectedStudentId == 0)
            {
                MessageBox.Show("Please select a student from the list first.", "Delete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult answer = MessageBox.Show("Do you really want to delete this student?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string sql = "DELETE FROM Students WHERE StudentID = @StudentID";

                DatabaseHelper.ExecuteNonQuery(sql,
                    DatabaseHelper.Param("@StudentID", selectedStudentId));

                MessageBox.Show("Student deleted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadStudents();
            }
            catch (SqlException ex)
            {
                if (DatabaseHelper.IsForeignKeyError(ex))
                {
                    MessageBox.Show(
                        "This student cannot be deleted because the student is registered in one or more events.\n" +
                        "Please remove those participant records first.",
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (searchText.Length == 0)
            {
                MessageBox.Show("Please enter a student name or email to search.", "Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearch.Focus();
                return;
            }

            SearchStudents(searchText);
        }

        /// <summary>Pressing Enter inside the search box works like the Search button.</summary>
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch_Click(sender, e);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadStudents();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            selectedStudentId = 0;
            txtStudentName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtProgram.Clear();
            txtSemester.Clear();
            dgvStudents.ClearSelection();
            ClearStudentEvents();
            txtStudentName.Focus();
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvStudents.Rows[e.RowIndex];

            selectedStudentId = Convert.ToInt32(row.Cells["StudentID"].Value);
            txtStudentName.Text = Convert.ToString(row.Cells["StudentName"].Value);
            txtEmail.Text = Convert.ToString(row.Cells["Email"].Value);
            txtPhone.Text = Convert.ToString(row.Cells["Phone"].Value);
            txtProgram.Text = Convert.ToString(row.Cells["Program"].Value);
            txtSemester.Text = Convert.ToString(row.Cells["Semester"].Value);

            LoadStudentEvents(selectedStudentId, txtStudentName.Text);
        }
    }
}
