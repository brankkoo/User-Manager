using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Model
{
    public class UserCollection : ObservableCollection<User>
    {
        public static UserCollection GetAllUsers()
        {
            UserCollection users = new UserCollection();
            

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["masterDatabase"].ToString();
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Users", conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User((string)reader["UserName"], (string)reader["UserPass"],(bool)reader["IsAdmin"],(int)reader["ID"]);
                        users.Add(user);    
                    }
                }
            }
                return users;
        }
    }
}
