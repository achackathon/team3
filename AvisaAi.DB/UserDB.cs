using AvisaAi.Data.Entities;
using AvisaAi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisaAi.DB
{
    public class UserDB : IUserRepository
    {
        public override User Get(int Id)
        {
            const string SQL = @"SELECT * FROM users WHERE Id = @Id";
            var result = new User();

            SqlConnection conn = new SqlConnection(Constants.Connection.ConnectionString);
            try
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL;
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = Id });

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            result.UserId = (int)dr["id"];
                            result.Name = dr["name"].ToString();
                            result.Email = dr["email"].ToString();
                            result.ReceiveEmail = DBNull.Value.Equals(dr["notifiedbyemail"]) ? false : ((bool)dr["notifiedbyemail"] ? true : false);
                        }
                    }

                    return result;
                }
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            }
        }
    }
}
