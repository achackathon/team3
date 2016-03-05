using AvisaAi.Data.Entities;
using AvisaAi.DB.Constants;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AvisaAi.DB
{
    public class NotificationTypeDB
    {
        const string SQL_GET_ALL = @"SELECT [Id]
                                    ,[Name]
                                    ,[Description]
                                    ,[Critical]
                                FROM [avisai_db].[dbo].[notificationtype]";

        const string SQL_GET_BY_ID = @"SELECT [Id]
                                    ,[Name]
                                    ,[Description]
                                    ,[Critical]
                                FROM [avisai_db].[dbo].[notificationtype] WHERE [Id] = @Id";

        const string SQL_GET_BY_USER_ID = @"SELECT nt.[Id]
                                          ,nt.[Name]
                                          ,nt.[Description]
                                          ,nt.[Critical]
                                          ,us.[Id] as 'UserId'
                                          ,us.[name] as 'Username'
                                      FROM [avisai_db].[dbo].[notificationtype] nt
                                      INNER JOIN [dbo].[usersnotifications] usnt
                                      ON nt.Id = usnt.[notificationTypeId]
                                      INNER JOIN [dbo].[users] us
                                      ON usnt.UserId = us.Id
                                      WHERE us.[Id] = @UserId";

        public IEnumerable<NotificationType> GetAll()
        {
            var notif = new List<NotificationType>();
            SqlConnection conn = new SqlConnection(Connection.ConnectionString);

            try
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL_GET_ALL;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        ReadNotificationTypes(notif, dr);
                    }

                    return notif;
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private static void ReadNotificationTypes(List<NotificationType> not, SqlDataReader dr)
        {
            while (dr.Read())
            {
                not.Add(GetNotificationTypeObject(dr));
            }
        }

        private static NotificationType GetNotificationTypeObject(SqlDataReader dr)
        {
            return new NotificationType
            {
                Id = (int)dr["Id"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Critical = (bool)dr["Critical"],
            };
        }

        public NotificationType GetById(int id)
        {
            var notif = new List<NotificationType>();
            SqlConnection conn = new SqlConnection(Connection.ConnectionString);

            try
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL_GET_BY_ID;
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.VarChar, Value = id });

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        ReadNotificationTypes(notif, dr);
                    }

                    return notif.FirstOrDefault();
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        public IEnumerable<NotificationType> GetByUserId(int userId)
        {
            var notif = new List<NotificationType>();
            SqlConnection conn = new SqlConnection(Connection.ConnectionString);

            try
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL_GET_BY_USER_ID;
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@UserId", SqlDbType = SqlDbType.VarChar, Value = userId });

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        ReadNotificationTypes(notif, dr);
                    }

                    return notif;
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }
    }
}
