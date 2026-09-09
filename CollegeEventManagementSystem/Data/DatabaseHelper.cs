using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CollegeEventManagementSystem.Data
{
    /// <summary>
    /// Central ADO.NET helper class.
    ///
    /// Every form uses these methods instead of writing its own connection code,
    /// so the connection logic is written only once. The connection string itself
    /// is stored in App.config (see the comment inside that file).
    /// </summary>
    public static class DatabaseHelper
    {
        /// <summary>Reads the connection string from App.config.</summary>
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CollegeEventDB"].ConnectionString;
        }

        /// <summary>Creates a new SqlConnection object (not opened yet).</summary>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        /// <summary>
        /// Runs a SELECT query and returns the result inside a DataTable.
        /// SqlDataAdapter fills the DataTable, which is then used as the
        /// DataSource of a DataGridView or a ComboBox.
        /// </summary>
        public static DataTable GetDataTable(string sql, params SqlParameter[] parameters)
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                }
            }

            return table;
        }

        /// <summary>
        /// Runs an INSERT, UPDATE or DELETE statement.
        /// Returns the number of rows that were affected.
        /// </summary>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        /// <summary>Runs a query that returns one single value (for example COUNT(*)).</summary>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }

                connection.Open();
                return command.ExecuteScalar();
            }
        }

        /// <summary>Convenience method for COUNT(*) queries used by the dashboard.</summary>
        public static int GetCount(string sql, params SqlParameter[] parameters)
        {
            object result = ExecuteScalar(sql, parameters);

            if (result == null || result == DBNull.Value)
            {
                return 0;
            }

            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Creates a parameter for a parameterized query.
        /// Empty text boxes are stored as NULL instead of an empty string.
        /// </summary>
        public static SqlParameter Param(string name, object value)
        {
            if (value == null)
            {
                return new SqlParameter(name, DBNull.Value);
            }

            if (value is string && ((string)value).Trim().Length == 0)
            {
                return new SqlParameter(name, DBNull.Value);
            }

            return new SqlParameter(name, value);
        }

        /// <summary>
        /// True when SQL Server refused the operation because of a foreign key
        /// relationship (error number 547), for example deleting a category that
        /// is still used by an event.
        /// </summary>
        public static bool IsForeignKeyError(SqlException ex)
        {
            return ex.Number == 547;
        }

        /// <summary>
        /// True when SQL Server refused the operation because a UNIQUE constraint
        /// was broken (error numbers 2627 and 2601), for example a duplicate
        /// certificate number.
        /// </summary>
        public static bool IsDuplicateError(SqlException ex)
        {
            return ex.Number == 2627 || ex.Number == 2601;
        }

        /// <summary>Checks that the database can actually be reached (used on start-up).</summary>
        public static bool CanConnect()
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
