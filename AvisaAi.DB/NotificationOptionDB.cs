using System.Collections.Generic;
using AvisaAi.Data.Entities;
using System.Data.SqlClient;
using System.Data;
using System;

namespace AvisaAi.DB
{
    public class NotificationOptionDB
    {
        const string CONN_STR = "Server =tcp:avisai.database.windows.net,1433;Database=avisai_db;User ID=team12@avisai;Password=P@ssw0rd;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public List<NotificationOption> GetNotificationOptionsByNotificationType(int notificationID)
        {

            const string SQL = @"SELECT Id, Name, Description, NotificationTypeId
                                 FROM dbo.notificationoptions
                                 WHERE NotificationTypeId = @id";

            SqlConnection conn = new SqlConnection(CONN_STR);
            try
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@id", SqlDbType = SqlDbType.VarChar, Value = notificationID });
                    cmd.CommandText = SQL;

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<NotificationOption> listToReturn = new List<NotificationOption>();

                    while (reader.Read())
                    {
                        listToReturn.Add(new NotificationOption()
                        {
                            Name = Convert.ToString(reader["name"]),
                            Description = Convert.ToString(reader["description"]),
                            NotificationOptionID = Convert.ToInt32(reader["id"]),
                            NotificationTypeId = Convert.ToInt32(reader["NotificationTypeId"])
                        });
                    }

                    return listToReturn;
                }

            }
            
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            }
        }
    }
}