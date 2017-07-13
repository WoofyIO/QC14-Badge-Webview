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
            bool[] rtn = new bool[48];

            for (int i = 0; i < 48; i++)
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
            bool[] rtn = new bool[48];

            for (int i = 0; i < 48; i++)
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

        public void updateBadge(String code, string email, string custcode, string paycode, string qrcode)
        {

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
                    sb.Append("UPDATE " + table + " SET codeused = 1, email = '" + email + "', custcode = '" + custcode + "', paycode = '" + paycode + "', qrcode = '" + qrcode + "', datepayed = CURRENT_TIMESTAMP WHERE [requestcode] = '" + code + "';");
                    String sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        int rowsAffected = command.ExecuteNonQuery();

                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }



        }

    }
}
