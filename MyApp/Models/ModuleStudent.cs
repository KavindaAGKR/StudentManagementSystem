using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class ModuleStudent
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Students Student { get; set; }

        public int ModuleId { get; set; }
        public Module Module { get; set; }
   
    }
}
