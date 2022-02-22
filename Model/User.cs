using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     class User
    {
        private string username;
        private string password;
        public User(string username,string password)
        {
            this.username = username;
            this.password = password;

        }

        public string Username { get { return username; } }
        public string Password { get { return password; } }


        public static User GetUserFromResultSet(SqlDataReader reader)
        {
            User user = new User((string)reader["UserName"], (string)reader["UserPass"]);
            return user;
        }





        public  bool Login(string connectionString, string username,string password)
        {
            string query = "select UserName and UserPass from Users where UserName=='" + username +"' and UserPass=='" + password+"'";
            using (SqlConnection connection =
                 new SqlConnection(connectionString))
            {
                
               SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GetUserFromResultSet(reader);
                    
                }
                connection.Close();

                if (this.username == username && this.password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                
            }
        }
    }
}
