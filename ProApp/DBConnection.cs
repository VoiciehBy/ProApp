using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using Microsoft.Data.SqlClient;

namespace ProApp
{
    public static class DBConnection
    {
        private static SqlConnection sqlConnection;

        public static SqlConnection getConnection(String DBName = "proapptest")
        {
            string dataSource = "(LocalDB)\\MSSQLLocalDB";

            string baseDirectory = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory);

            string attachDBFilename = "C:\\Users\\geral\\source\\repos\\ProApp\\ProApp\\ProApp\\proapptest.mdf";
            string integrateSecurity = "True";

            string connectionString =
                "Data Source=" + dataSource + ';'
                + "AttachDbFilename=" + attachDBFilename + ';'
                + "Integrated Security=" + integrateSecurity;
            sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }

        public static ArrayList getData(String query = "SELECT * FROM products;")
        {
            SqlCommand sqlCommand = null;
            ArrayList result = new ArrayList();
            try
            {
                sqlConnection = getConnection();
                sqlCommand = new SqlCommand(query, sqlConnection);

                SqlDataReader sqlDataReader = null;

                sqlConnection.Open();
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    String row = "";
                    for (int i = 0; i < sqlDataReader.FieldCount; i++)
                        row += sqlDataReader[i].ToString() + " ";
                    result.Add(row);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.StackTrace);
            }
            return result;
        }

        public static void executeDML(String query)
        {
            SqlCommand sqlCommand = null;
            try
            {
                sqlConnection = getConnection();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.StackTrace);
            }
        }
    }
}