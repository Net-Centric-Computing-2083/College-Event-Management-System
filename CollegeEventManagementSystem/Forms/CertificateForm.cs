using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CollegeEventManagementSystem.Data;
using CollegeEventManagementSystem.UI;

namespace CollegeEventManagementSystem.Forms
{
    /// <summary>
    /// Certificate Records module.
    /// A certificate always belongs to a participant, so the participant ComboBox
    /// shows the student name together with the event name.
    /// </summary>
    public partial class CertificateForm : Form
    {
        private int selectedCertificateId = 0;

        public CertificateForm()
        {
            InitializeComponent();
            Theme.StyleForm(this);
            Theme.StylePrimaryButton(btnAdd);
            Theme.StyleSecondaryButton(btnUpdate);
            Theme.StyleDangerButton(btnDelete);
            Theme.StyleSecondaryButton(btnClear);
            Theme.StyleGrid(dgvCertificates);
        }

        private void CertificateForm_Load(object sender, EventArgs e)
        {
            dtpIssueDate.Value = DateTime.Today;

            LoadParticipants();
            LoadCertificates();

            if (cmbParticipant.Items.Count == 0)
            {
                MessageBox.Show("No participants are available. Please register participants first.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>Fills the participant ComboBox with "Student Name - Event Name".</summary>
        private void LoadParticipants()
        {
            try
            {
                string sql =
                    "SELECT p.ParticipantID, s.FullName + ' - ' + e.EventName AS ParticipantName " +
                    "FROM Participants p " +
                    "INNER JOIN Students s ON p.StudentID = s.StudentID " +
                    "INNER JOIN Events e ON p.EventID = e.EventID " +
                    "ORDER BY s.FullName";

                cmbParticipant.DisplayMember = "ParticipantName";
                cmbParticipant.ValueMember = "ParticipantID";
                cmbParticipant.DataSource = DatabaseHelper.GetDataTable(sql);
                cmbParticipant.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load the participant list.\n\nError: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Loads all certificate records using JOIN queries.</summary>
        private void LoadCertificates()
        {
            try
            {
                string sql =
                    "SELECT c.CertificateID, s.FullName AS StudentName, e.EventName, c.CertificateNo, " +
                    "c.CertificateType, c.IssueDate, c.ParticipantID " +
                    "FROM Certificates c " +
                    "INNER JOIN Participants p ON c.ParticipantID = p.ParticipantID " +
                    "INNER JOIN Students s ON p.StudentID = s.StudentID " +
                    "INNER JOIN Events e ON p.EventID = e.EventID " +
                    "ORDER BY c.CertificateID";

                dgvCertificates.DataSource = DatabaseHelper.GetDataTable(sql);

                dgvCertificates.Columns["CertificateID"].HeaderText = "Certificate ID";
                dgvCertificates.Columns["StudentName"].HeaderText = "Student Name";
                dgvCertificates.Columns["EventName"].HeaderText = "Event Name";
                dgvCertificates.Columns["CertificateNo"].HeaderText = "Certificate No";
                dgvCertificates.Columns["CertificateType"].HeaderText = "Certificate Type";
                dgvCertificates.Columns["IssueDate"].HeaderText = "Issue Date";
                dgvCertificates.Columns["IssueDate"].DefaultCellStyle.Format = "dd MMM yyyy";
                dgvCertificates.Columns["CertificateID"].FillWeight = 80;
                dgvCertificates.Columns["StudentName"].FillWeight = 120;
                dgvCertificates.Columns["EventName"].FillWeight = 120;
                dgvCertificates.Columns["CertificateNo"].FillWeight = 110;
                dgvCertificates.Columns["CertificateType"].FillWeight = 110;
                dgvCertificates.Columns["IssueDate"].FillWeight = 90;
                dgvCertificates.Columns["ParticipantID"].Visible = false;
                dgvCertificates.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load the certificate records. Please check the database connection.\n\nError: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsInputValid()
        {
            if (cmbParticipant.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a participant.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbParticipant.Focus();
                return false;
            }

            if (txtCertificateNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the certificate number.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCertificateNo.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks whether the certificate number is already used.
        /// The Certificates table also has a UNIQUE constraint on CertificateNo.
        /// </summary>
        private bool IsDuplicateCertificateNo(string certificateNo, int ignoreCertificateId)
        {
            string sql = "SELECT COUNT(*) FROM Certificates " +
                         "WHERE CertificateNo = @CertificateNo AND CertificateID <> @CertificateID";

            int count = DatabaseHelper.GetCount(sql,
                DatabaseHelper.Param("@CertificateNo", certificateNo),
                DatabaseHelper.Param("@CertificateID", ignoreCertificateId));

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
                if (IsDuplicateCertificateNo(txtCertificateNo.Text.Trim(), 0))
                {
                    MessageBox.Show("This certificate number is already used. Please enter a different number.",
                        "Duplicate Certificate Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = "INSERT INTO Certificates (ParticipantID, CertificateNo, CertificateType, IssueDate) " +
                             "VALUES (@ParticipantID, @CertificateNo, @CertificateType, @IssueDate)";

                DatabaseHelper.ExecuteNonQuery(sql,
                    DatabaseHelper.Param("@ParticipantID", Convert.ToInt32(cmbParticipant.SelectedValue)),
                    DatabaseHelper.Param("@CertificateNo", txtCertificateNo.Text.Trim()),
                    DatabaseHelper.Param("@CertificateType", cmbCertificateType.Text.Trim()),
                    DatabaseHelper.Param("@IssueDate", dtpIssueDate.Value.Date));

                MessageBox.Show("Certificate record added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadCertificates();
            }
            catch (SqlException ex)
            {
                if (DatabaseHelper.IsDuplicateError(ex))
                {
                    MessageBox.Show("This certificate number is already used. Please enter a different number.",
                        "Duplicate Certificate Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Unable to save the record. Please check the entered information and try again.",
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to save the record. Please try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCertificateId == 0)
            {
                MessageBox.Show("Please select a certificate record from the list first.", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!IsInputValid())
            {
                return;
            }

            try
            {
                if (IsDuplicateCertificateNo(txtCertificateNo.Text.Trim(), selectedCertificateId))
                {
                    MessageBox.Show("This certificate number is already used. Please enter a different number.",
                        "Duplicate Certificate Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = "UPDATE Certificates SET ParticipantID = @ParticipantID, " +
                             "CertificateNo = @CertificateNo, CertificateType = @CertificateType, " +
                             "IssueDate = @IssueDate WHERE CertificateID = @CertificateID";

                DatabaseHelper.ExecuteNonQuery(sql,
                    DatabaseHelper.Param("@ParticipantID", Convert.ToInt32(cmbParticipant.SelectedValue)),
                    DatabaseHelper.Param("@CertificateNo", txtCertificateNo.Text.Trim()),
                    DatabaseHelper.Param("@CertificateType", cmbCertificateType.Text.Trim()),
                    DatabaseHelper.Param("@IssueDate", dtpIssueDate.Value.Date),
                    DatabaseHelper.Param("@CertificateID", selectedCertificateId));

                MessageBox.Show("Certificate record updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadCertificates();
            }
            catch (SqlException ex)
            {
                if (DatabaseHelper.IsDuplicateError(ex))
                {
                    MessageBox.Show("This certificate number is already used. Please enter a different number.",
                        "Duplicate Certificate Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (selectedCertificateId == 0)
            {
                MessageBox.Show("Please select a certificate record from the list first.", "Delete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult answer = MessageBox.Show("Do you really want to delete this certificate record?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string sql = "DELETE FROM Certificates WHERE CertificateID = @CertificateID";

                DatabaseHelper.ExecuteNonQuery(sql,
                    DatabaseHelper.Param("@CertificateID", selectedCertificateId));

                MessageBox.Show("Certificate record deleted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadCertificates();
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
            selectedCertificateId = 0;
            cmbParticipant.SelectedIndex = -1;
            txtCertificateNo.Clear();
            cmbCertificateType.Text = string.Empty;
            dtpIssueDate.Value = DateTime.Today;
            dgvCertificates.ClearSelection();
            txtCertificateNo.Focus();
        }

        private void dgvCertificates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvCertificates.Rows[e.RowIndex];

            selectedCertificateId = Convert.ToInt32(row.Cells["CertificateID"].Value);
            cmbParticipant.SelectedValue = Convert.ToInt32(row.Cells["ParticipantID"].Value);
            txtCertificateNo.Text = Convert.ToString(row.Cells["CertificateNo"].Value);
            cmbCertificateType.Text = Convert.ToString(row.Cells["CertificateType"].Value);

            if (row.Cells["IssueDate"].Value != DBNull.Value)
            {
                dtpIssueDate.Value = Convert.ToDateTime(row.Cells["IssueDate"].Value);
            }
            else
            {
                dtpIssueDate.Value = DateTime.Today;
            }
        }
    }
}

// Reviewed by Samir Khatri: certificate CRUD and unique certificate number check verified.
