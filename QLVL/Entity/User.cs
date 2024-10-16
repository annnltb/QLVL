using System;

namespace QLVL.Entity
{
    public class User
    {
        // Auto-implemented properties
        public int UserId { get; set; } // PK
        public string Name { get; set; }
        public string Email { get; set; } // Unique
        public string PhoneNumber { get; set; }
        public string Username { get; set; } // Unique
        public string Password { get; set; }
        public string Position { get; set; }
        public DateTime CreatedAt { get; set; }

        // Constructor mặc định
        public User()
        {
            CreatedAt = DateTime.Now; // Gán giá trị mặc định cho CreatedAt
        }

        // Constructor đầy đủ
        public User(int userId, string name, string email, string phoneNumber, string username, string password, string position, DateTime createdAt)
        {
            UserId = userId;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Username = username;
            Password = password;
            Position = position;
            CreatedAt = createdAt;
        }
    }
}
