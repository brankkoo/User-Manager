using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1;

namespace Model
{
    public class User
    {
        private string username;
        private string password;
        private bool admin;
        private int id;

        public string UserName { get { return username; } set { username = value; } }

        public string Password { get { return password; } set { password = value; } }

        public bool Admin { get { return admin; } }

        public int Id { get { return id; } }

        public User()
        {
            
        }
        public User(string username,string password)
        {
            this.username = username;
            this.password = password;

        }

        public User (string username, string password, bool admin, int id)
        {
            this.username=username;
            this.password=password;
            this.admin = admin;
            this.id = id;   
        }


        public User Clone()
        {
            User clonedUser = new User();
            clonedUser.id = this.id;
            clonedUser.username = this.username;
            clonedUser.password = this.password;
            clonedUser.admin = this.admin;
            return clonedUser;
        }




        public void UpdateUser()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["masterDatabase"].ToString();
                connection.Open();
                SqlCommand cmd = new SqlCommand("Update Users Set UserName=@UserName,UserPass=@Password Where ID=@Id ",connection);

                SqlParameter userNameParam = new SqlParameter("@UserName",SqlDbType.NVarChar);
                userNameParam.Value = this.UserName;
                cmd.Parameters.Add(userNameParam);

                SqlParameter passwordParam = new SqlParameter("@Password", SqlDbType.NVarChar);
                passwordParam.Value = this.Password;
                cmd.Parameters.Add(passwordParam);

                SqlParameter idParam = new SqlParameter("@Id",SqlDbType.TinyInt);
                    idParam.Value = this.Id;
                cmd.Parameters.Add(idParam);

                cmd.ExecuteNonQuery();
            }
        }

        public void AddUser()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["masterDatabase"].ToString();
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("insert into Users(UserName,UserPass) Values(@username,@password)",connection);

                SqlParameter userParam = new SqlParameter("username",SqlDbType.NVarChar);
                userParam.Value = this.UserName;
                sqlCommand.Parameters.Add(userParam);

                SqlParameter passwordParam = new SqlParameter("password",SqlDbType.NVarChar);
                passwordParam.Value=this.Password;
                sqlCommand.Parameters.Add(passwordParam);
                sqlCommand.ExecuteNonQuery();
            }
        }


        public static bool Login(string connectionString, string username,string password)
        {
                using (SqlConnection connection =
                     new SqlConnection(connectionString))
                {
                    string query = "select * from Users";
                    SqlCommand command = new SqlCommand(query, connection);
                    
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["UserName"].ToString() == username && reader["UserPass"].ToString() == password)
                        {
                           return true;

    }
                        else
                        {
                           return false;
                        }
                    
                    }
                connection.Close();
                return false;
                    

                    
                }
            }
                 
                
            }
        }
    

