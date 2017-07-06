using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text;

namespace qcbadge.Helpers
{
    public class Sql
    {
        private static string DataSource = Startup.dburi;
        private static string UserID = Startup.dbuser;
        private static string Password = Startup.dbpass;
        private static string db = Startup.dbname;
        private static string table = "[qcbadge]";

        public bool[] selectGlobalView()
        {
            //System.Diagnostics.Debug.WriteLine("Got to selectGlobalView");
            bool[] rtn = new bool[50];

            for (int i = 0; i < 50; i++)
            {
                //System.Diagnostics.Debug.WriteLine("Into loop " + i);

                try
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.DataSource = DataSource;
                    builder.UserID = UserID;
                    builder.Password = Password;
                    builder.InitialCatalog = db;

                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();
                        StringBuilder sb = new StringBuilder();
                        sb.Append("SELECT COUNT([badgeid]) ");
                        sb.Append("FROM " + table);
                        sb.Append(" WHERE [" + i + "] = 1;");
                        String sql = sb.ToString();
                        //System.Diagnostics.Debug.WriteLine(sql);


                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int x = Convert.ToInt32(reader[0].ToString());
                                    if( x > 0 )
                                    {
                                        rtn[i] = true;
                                    }
                                    else
                                    {
                                        rtn[i] = false;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.ToString());
                }

            }

            return rtn;
        }

        public bool[] selectIndervidualView(int badgeid)
        {
            bool[] rtn = new bool[50];

            for (int i = 0; i < 50; i++)
            {
                //System.Diagnostics.Debug.WriteLine("Into loop " + i);

                try
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.DataSource = DataSource;
                    builder.UserID = UserID;
                    builder.Password = Password;
                    builder.InitialCatalog = db;

                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();
                        StringBuilder sb = new StringBuilder();
                        sb.Append("SELECT COUNT([badgeid]) ");
                        sb.Append("FROM " + table);
                        sb.Append(" WHERE [badgeid] = '" + badgeid + "' AND [" + i + "] = 1;");
                        String sql = sb.ToString();
                        //System.Diagnostics.Debug.WriteLine(sql);


                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int x = Convert.ToInt32(reader[0].ToString());
                                    if (x > 0)
                                    {
                                        rtn[i] = true;
                                    }
                                    else
                                    {
                                        rtn[i] = false;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.ToString());
                }

            }

            return rtn;
        }

    }
}
