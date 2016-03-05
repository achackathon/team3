using System.Data.SqlClient;
using AvisaAi.Data.Entities;
using System.Data;
using System.Globalization;

namespace AvisaAi.DB
{
    public class NotificationDB
    {
        public bool Add(Notification notification)
        {
            const string SQL = @"INSERT INTO notification 
                    (Name, Location, Description, DateAdded, UserID, ExpiresOn, NotificationTypeId)
                    VALUES (@Name, geography::Point(@Lat,@Lng, 4326), @Description, @DateAdded, @UserID, @ExpiresOn, @NotificationTypeId)";

            SqlConnection conn = new SqlConnection("Server =tcp:avisai.database.windows.net,1433;Database=avisai_db;User ID=team12@avisai;Password=P@ssw0rd;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            try
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL;
                    //var location = DbGeography.PointFromText(string.Format("POINT({0} {1})", notification.Latitude.ToString(CultureInfo.InvariantCulture), notification.Longitude.ToString(CultureInfo.InvariantCulture)), 4326)

                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@Name", SqlDbType = SqlDbType.VarChar, Value = notification.Name });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@Lat", SqlDbType = SqlDbType.Decimal, Value = notification.Latitude });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@Lng", SqlDbType = SqlDbType.Decimal, Value = notification.Longitude });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@Description", SqlDbType = SqlDbType.VarChar, Value = notification.Description });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@DateAdded", SqlDbType = SqlDbType.DateTime, Value = notification.DateAdded });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@UserID", SqlDbType = SqlDbType.VarChar, Value = notification.UserID });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@ExpiresOn", SqlDbType = SqlDbType.DateTime, Value = notification.ExpiresOn });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@NotificationTypeId", SqlDbType = SqlDbType.Int, Value = notification.NotificationTypeId });

                    cmd.ExecuteNonQuery();

                    return true;

                }
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            }
        }
    }
}


