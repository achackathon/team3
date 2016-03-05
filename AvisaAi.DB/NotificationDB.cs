using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AvisaAi.Data.Entities;
using System.Data;

namespace AvisaAi.DB
{
    public class NotificationDB
    {
        public bool Add(Notification notification)
        {
            const string SQL = @"INSERT INTO notification 
                    (Id, Name, Location, Description, DateAdded, UserID, ExpiresOn, NotificationTypeId)
                    VALUES (@Id, @Name, @Location, @Description, @DateAdded, @UserID, @ExpiresOn, @NotificationTypeId)";

            SqlConnection conn = new SqlConnection("Server =tcp:avisai.database.windows.net,1433;Database=avisai_db;User ID=team12@avisai;Password=P@ssw0rd;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQL;

                

                return true;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            }
        }
    }
}


