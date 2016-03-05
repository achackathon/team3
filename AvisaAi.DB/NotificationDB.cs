using AvisaAi.Data.Entities;
using AvisaAi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AvisaAi.DB
{
    public class NotificationDB: INotificationRepository
    {
        const string CONN_STR = "Server =tcp:avisai.database.windows.net,1433;Database=avisai_db;User ID=team12@avisai;Password=P@ssw0rd;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public override bool Add(Notification notification)
        {
            const string SQL = @"INSERT INTO notification 
                    (Name, Location, Description, DateAdded, UserID, ExpiresOn, NotificationTypeId)
                    VALUES (@Name, geography::Point(@Lng, @Lat, 4326), @Description, @DateAdded, @UserID, @ExpiresOn, @NotificationTypeId)";

            SqlConnection conn = new SqlConnection(CONN_STR);
            try
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL;
                    //var location = DbGeography.PointFromText(string.Format("POINT({0} {1})", notification.Latitude.ToString(CultureInfo.InvariantCulture), notification.Longitude.ToString(CultureInfo.InvariantCulture)), 4326)

                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@Name", SqlDbType = SqlDbType.VarChar, Value = notification.Name });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@Lng", SqlDbType = SqlDbType.Decimal, Value = notification.Longitude });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@Lat", SqlDbType = SqlDbType.Decimal, Value = notification.Latitude });
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

        public override List<Notification> Get()
        {
            const string SQL = @"SELECT Location.Lat as Lat, Location.Long as Long, * FROM notification";
            var ret = new List<Notification>();

            SqlConnection conn = new SqlConnection(CONN_STR);
            try
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ret.Add(new Notification
                            {
                                Id = (int)dr["Id"],
                                Name = dr["Name"].ToString(),
                                Latitude = (double)dr["Lat"],
                                Longitude = (double)dr["Long"],
                                Description = dr["Description"].ToString(),
                                DateAdded = DateTime.Parse(dr["DateAdded"].ToString()),
                                UserID = (int)dr["UserID"],
                                ExpiresOn = DateTime.Parse(dr["ExpiresOn"].ToString()),
                                NotificationTypeId = (int)dr["NotificationTypeId"]
                            });
                        }
                    }
           
                    return ret;
                }
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            }
        }

        public override List<Notification> GetNearby(double Latitude, double Longitude)
        {
            const string SQL = @"select Location.Lat as Lat, Location.Long as Long, * from notification n
                        where n.Location.STDistance(geography::Point(@Lng,@Lat, 4326)) IS NOT NULL
                        and n.Location.STDistance(geography::Point(@Lng,@Lat, 4326)) < 500
                        order by n.Location.STDistance(geography::Point(@Lng,@Lat, 4326))";
            var ret = new List<Notification>();

            SqlConnection conn = new SqlConnection(CONN_STR);
            try
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL;
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@Lng", SqlDbType = SqlDbType.Decimal, Value = Longitude });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@Lat", SqlDbType = SqlDbType.Decimal, Value = Latitude });

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ret.Add(new Notification
                            {
                                Id = (int)dr["Id"],
                                Name = dr["Name"].ToString(),
                                Latitude = (double)dr["Lat"],
                                Longitude = (double)dr["Long"],
                                Description = dr["Description"].ToString(),
                                DateAdded = DateTime.Parse(dr["DateAdded"].ToString()),
                                UserID = (int)dr["UserID"],
                                ExpiresOn = DateTime.Parse(dr["ExpiresOn"].ToString()),
                                NotificationTypeId = (int)dr["NotificationTypeId"]
                            });
                        }
                    }

                    return ret;
                }
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            }
        }
    }
}


