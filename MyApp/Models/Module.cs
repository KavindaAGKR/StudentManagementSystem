using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class Module
    {
        [Key]
        public int Id { get; set; }
        public string ModuleId { get; set; }
        public string Name { get; set; }

        public int Credit { get; set; }

        public List<Students> Students { get; set; }
        public Module()
        {
            Students = new List<Students>();
        }
    }
}
