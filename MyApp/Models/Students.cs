using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using static SQLite.SQLite3;

namespace MyApp.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public string RegNo { get; set; }
        public string Email { get; set; }

        public int TelNo { get; set; }

        public ICollection<Module> Modules { get; set; }
        public ICollection<Results> Results { get; set; }

        public double GPA { get; set; }

        public Students()
        {
            Modules = new List<Module>();
            Results = new List<Results>();

        }

        public Students(string fname, string lname, string regno, string email, int telNo)
        {
            FirstName = fname;
            LastName = lname;
            RegNo = regno;
            Email = email;
            TelNo = telNo;
            Modules = new List<Module>();
            Results = new List<Results>();
        }
    }
}
