using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLVL.Entity;

namespace QLVL.DAL
{
    public class UserDAL
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Quanlyvatlieu_doantichhop;Integrated Security=True"; // Thay bằng chuỗi kết nối của bạn

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        UserId = (int)reader["UserId"],
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"]?.ToString(),
                        Position = reader["Position"]?.ToString(),
                        CreatedAt = (DateTime)reader["CreatedAt"]
                    });
                }
            }
            return users;
        }

        public User GetUserById(int userId)
        {
            User user = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE UserId = @UserId", connection);
                command.Parameters.AddWithValue("@UserId", userId);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    user = new User
                    {
                        UserId = (int)reader["UserId"],
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"]?.ToString(),
                        Position = reader["Position"]?.ToString(),
                        CreatedAt = (DateTime)reader["CreatedAt"]
                    };
                }
            }
            return user;
        }

        public void AddUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Users (Name, Email, PhoneNumber, Username, Password, Position, CreatedAt) VALUES (@Name, @Email, @PhoneNumber, @Username, @Password, @Position, @CreatedAt)", connection);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Position", user.Position);
                command.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Users SET Name = @Name, Email = @Email, PhoneNumber = @PhoneNumber, Username = @Username, Password = @Password, Position = @Position WHERE UserId = @UserId", connection);
                command.Parameters.AddWithValue("@UserId", user.UserId);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Position", user.Position);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteUser(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Users WHERE UserId = @UserId", connection);
                command.Parameters.AddWithValue("@UserId", userId);
                command.ExecuteNonQuery();
            }
        }
    }
}
