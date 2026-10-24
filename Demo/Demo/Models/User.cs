using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    internal class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public DateTime DateCreated { get; set; }
        public User(int userId, string name, string displayName, DateTime dateCreated)
        {
            UserId = userId;
            Name = name;
            DisplayName = displayName;
            DateCreated = dateCreated;
        }
    }
}
