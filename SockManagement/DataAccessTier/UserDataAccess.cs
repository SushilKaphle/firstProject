using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTier
{
    public class UserDataAccess
    {
        public List<User> GetUsers()
        {
            List<User> listUser = new List<User>();
            SqlConnection conn = new SqlConnection(GetDbConnection.Connecton());
            conn.Open();
            SqlCommand cmd = new SqlCommand("GetUsers", conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while(rd.Read())
            {
                listUser.Add(new User()
                {
                    Id=Convert.ToInt32(rd["Id"]),
                    FirstName = rd["FirstName"].ToString(),
                    LastName = rd["LastName"].ToString(), 
                    UserName = rd["UserName"].ToString(),
                    Password = rd["PassWord"].ToString(),
                    UserType = Convert.ToInt32(rd["Usertype"]),
                });

            }

            return listUser;
        }

        public void AddUser(User user )
        {
            SqlConnection conn = new SqlConnection(GetDbConnection.Connecton());
            SqlCommand cmd = new SqlCommand("AddUsers", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UN", SqlDbType.VarChar,50).Value = user.UserName;
            cmd.Parameters.Add("@PW", SqlDbType.VarChar,50).Value = user.Password;
            cmd.Parameters.Add("@FN", SqlDbType.VarChar,50).Value = user.FirstName;
            cmd.Parameters.Add("@LN", SqlDbType.VarChar,50).Value = user.LastName;
            cmd.Parameters.Add("@UT", SqlDbType.Int).Value = user.UserType;

            cmd.ExecuteNonQuery();
        }

        public List<User> GetIds()
        {
            List<User> listUser = new List<User>();
            SqlConnection conn = new SqlConnection(GetDbConnection.Connecton());
            conn.Open();
            SqlCommand cmd = new SqlCommand("GetIDs", conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                listUser.Add(new User()
                {
                    Id =Convert.ToInt32(rd["Id"])
                });

            }

            return listUser;
        }

        public void UpdateUser(User user)
        {
            SqlConnection conn = new SqlConnection(GetDbConnection.Connecton());
            SqlCommand cmd = new SqlCommand("UpdateUser", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = user.Id;
            cmd.Parameters.Add("@UN", SqlDbType.VarChar, 50).Value = user.UserName;
            cmd.Parameters.Add("@PW", SqlDbType.VarChar, 50).Value = user.Password;
            cmd.Parameters.Add("@FN", SqlDbType.VarChar, 50).Value = user.FirstName;
            cmd.Parameters.Add("@LN", SqlDbType.VarChar, 50).Value = user.LastName;
            cmd.Parameters.Add("@UT", SqlDbType.Int).Value = user.UserType;
           
            cmd.ExecuteNonQuery();
        }
        public void DeleteUsers(int id)
        {
            SqlConnection conn = new SqlConnection(GetDbConnection.Connecton());
            SqlCommand cmd = new SqlCommand("DeleteUsers", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            

            cmd.ExecuteNonQuery();
        }

    }
}
