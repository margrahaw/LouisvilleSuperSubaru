using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LouisvilleSuperSubaru.Data.Interfaces;
using LouisvilleSuperSubaru.Models.Queries;
using LouisvilleSuperSubaru.Models.Tables;

namespace LouisvilleSuperSubaru.Data.ADO
{
    public class UserRepositoryADO : IUserRepository
    {
        public List<UserListing> GetAll()
        {
            List<UserListing> users = new List<UserListing>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UsersSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        UserListing currentRow = new UserListing();
                        currentRow.UserId = dr["Id"].ToString();
                        currentRow.LastName = dr["LastName"].ToString();
                        currentRow.FirstName = dr["FirstName"].ToString();
                        currentRow.Email = dr["Email"].ToString();
                        currentRow.UserRoleName = dr["UserRoleName"].ToString();

                        users.Add(currentRow);

                    }
                }
            }
            return users;
        }

        public void Insert(User user)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UserInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Id", SqlDbType.Text);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@EmailConfirmed", user.EmailConfirmed);
                cmd.Parameters.AddWithValue("@PhoneNumberConfirmed", user.PhoneNumberConfirmed);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@TwoFactorEnabled", user.TwoFactorEnabled);
                cmd.Parameters.AddWithValue("@LockoutEnabled", user.LockoutEnabled);
                cmd.Parameters.AddWithValue("@AccessFailedCount", user.AccessFailedCount);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@UserRoleID", user.UserRoleID);

                cn.Open();

                cmd.ExecuteNonQuery();

                user.Id = param.Value.ToString();
            }
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
