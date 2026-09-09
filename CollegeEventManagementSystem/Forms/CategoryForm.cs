using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CollegeEventManagementSystem.Data;
using CollegeEventManagementSystem.UI;

namespace CollegeEventManagementSystem.Forms
{
    /// <summary>
    /// Category Management module. Full CRUD on the Categories table.
    /// </summary>
    public partial class CategoryForm : Form
    {
        // Stores the CategoryID of the row that the user selected in the DataGridView.
        private int selectedCategoryId = 0;

        public CategoryForm()
        {
            InitializeComponent();
            Theme.StyleForm(this);
            Theme.StylePrimaryButton(btnAdd);
            Theme.StyleSecondaryButton(btnUpdate);
            Theme.StyleDangerButton(btnDelete);
            Theme.StyleSecondaryButton(btnClear);
            Theme.StyleGrid(dgvCategories);
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        /// <summary>Reads all categories and shows them in the DataGridView.</summary>
        private void LoadCategories()
        {
            try
            {
                string sql = "SELECT CategoryID, CategoryName, Description FROM Categories ORDER BY CategoryName";

                dgvCategories.DataSource = DatabaseHelper.GetDataTable(sql);

                dgvCategories.Columns["CategoryID"].HeaderText = "Category ID";
                dgvCategories.Columns["CategoryName"].HeaderText = "Category Name";
                dgvCategories.Columns["Description"].HeaderText = "Description";
                dgvCategories.Columns["CategoryID"].FillWeight = 60;
                dgvCategories.Columns["CategoryName"].FillWeight = 110;
                dgvCategories.Columns["Description"].FillWeight = 200;
                dgvCategories.ClearSelection();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to load the category records. Please check the database connection.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>Checks the values typed by the user before they are saved.</summary>
        private bool IsInputValid()
        {
            if (txtCategoryName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the category name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsInputValid())
            {
                return;
            }

            try
            {
                string sql = "INSERT INTO Categories (CategoryName, Description) VALUES (@CategoryName, @Description)";

                DatabaseHelper.ExecuteNonQuery(sql,
                    DatabaseHelper.Param("@CategoryName", txtCategoryName.Text.Trim()),
                    DatabaseHelper.Param("@Description", txtDescription.Text.Trim()));

                MessageBox.Show("Category added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadCategories();
            }
            catch (SqlException ex)
            {
                // ex.Message holds the original SQL Server message (useful while debugging).
                if (DatabaseHelper.IsDuplicateError(ex))
                {
                    MessageBox.Show("This category name already exists. Please use a different name.",
                        "Duplicate Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (selectedCategoryId == 0)
            {
                MessageBox.Show("Please select a category from the list first.", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!IsInputValid())
            {
                return;
            }

            try
            {
                string sql = "UPDATE Categories SET CategoryName = @CategoryName, Description = @Description " +
                             "WHERE CategoryID = @CategoryID";

                DatabaseHelper.ExecuteNonQuery(sql,
                    DatabaseHelper.Param("@CategoryName", txtCategoryName.Text.Trim()),
                    DatabaseHelper.Param("@Description", txtDescription.Text.Trim()),
                    DatabaseHelper.Param("@CategoryID", selectedCategoryId));

                MessageBox.Show("Category updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadCategories();
            }
            catch (SqlException ex)
            {
                if (DatabaseHelper.IsDuplicateError(ex))
                {
                    MessageBox.Show("This category name already exists. Please use a different name.",
                        "Duplicate Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (selectedCategoryId == 0)
            {
                MessageBox.Show("Please select a category from the list first.", "Delete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult answer = MessageBox.Show(
                "Do you really want to delete this category?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string sql = "DELETE FROM Categories WHERE CategoryID = @CategoryID";

                DatabaseHelper.ExecuteNonQuery(sql,
                    DatabaseHelper.Param("@CategoryID", selectedCategoryId));

                MessageBox.Show("Category deleted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadCategories();
            }
            catch (SqlException ex)
            {
                if (DatabaseHelper.IsForeignKeyError(ex))
                {
                    MessageBox.Show(
                        "This category cannot be deleted because one or more events are using it.\n" +
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
            selectedCategoryId = 0;
            txtCategoryName.Clear();
            txtDescription.Clear();
            dgvCategories.ClearSelection();
            txtCategoryName.Focus();
        }

        /// <summary>Copies the selected row into the text boxes so it can be edited or deleted.</summary>
        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvCategories.Rows[e.RowIndex];

            selectedCategoryId = Convert.ToInt32(row.Cells["CategoryID"].Value);
            txtCategoryName.Text = Convert.ToString(row.Cells["CategoryName"].Value);
            txtDescription.Text = Convert.ToString(row.Cells["Description"].Value);
        }
    }
}
