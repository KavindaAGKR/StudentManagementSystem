using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    
        public string Username { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }

        public Users()
        {

        }

        public Users( string username, string password, string type, string email)
        {

            Username = username;
            Password = password;
            Type = type;
            Email = email;
        }
    }
   
}
