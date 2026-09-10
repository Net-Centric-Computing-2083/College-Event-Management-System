using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CollegeEventManagementSystem.Data
{
    /// <summary>
    /// Central ADO.NET helper class.
    /// Provides common database connection and query methods.
    /// </summary>
    public static class DatabaseHelper
    {
        /// <summary>
        /// Gets the database connection string from App.config.
        /// </summary>
        public static string GetConnectionString()
        {
            return ConfigurationManager
                .ConnectionStrings["CollegeEventDB"]
                .ConnectionString;
        }

        /// <summary>
        /// Creates a new SQL connection.
        /// The connection is not opened here.
        /// </summary>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        /// <summary>
        /// Executes a SELECT query and returns the result as a DataTable.
        /// </summary>
        public static DataTable GetDataTable(
            string sql,
            params SqlParameter[] parameters)
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
        /// Executes an INSERT, UPDATE, or DELETE query.
        /// Returns the number of affected rows.
        /// </summary>
        public static int ExecuteNonQuery(
            string sql,
            params SqlParameter[] parameters)
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

        /// <summary>
        /// Executes a query that returns a single value.
        /// Example: SELECT COUNT(*) FROM Events
        /// </summary>
        public static object ExecuteScalar(
            string sql,
            params SqlParameter[] parameters)
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

        /// <summary>
        /// Executes a COUNT query and returns the result as an integer.
        /// </summary>
        public static int GetCount(
            string sql,
            params SqlParameter[] parameters)
        {
            object result = ExecuteScalar(sql, parameters);

            if (result == null || result == DBNull.Value)
            {
                return 0;
            }

            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Creates a SQL parameter.
        /// Empty strings are converted to DBNull.Value.
        /// </summary>
        public static SqlParameter Param(
            string name,
            object value)
        {
            if (value == null)
            {
                return new SqlParameter(name, DBNull.Value);
            }

            if (value is string &&
                ((string)value).Trim().Length == 0)
            {
                return new SqlParameter(name, DBNull.Value);
            }

            return new SqlParameter(name, value);
        }

        /// <summary>
        /// Checks whether a SQL exception was caused by
        /// a foreign key constraint.
        /// SQL Server error number: 547.
        /// </summary>
        public static bool IsForeignKeyError(SqlException ex)
        {
            return ex.Number == 547;
        }

        /// <summary>
        /// Checks whether a SQL exception was caused by
        /// a duplicate value.
        /// SQL Server error numbers: 2627 and 2601.
        /// </summary>
        public static bool IsDuplicateError(SqlException ex)
        {
            return ex.Number == 2627 || ex.Number == 2601;
        }

        /// <summary>
        /// Tests whether the application can connect to the database.
        /// </summary>
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

// Reviewed by Samriddha Poudel:
// ADO.NET helper methods verified.