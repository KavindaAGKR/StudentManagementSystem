using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class Results
    {
        public int ID { get; set; }

        public int ModuleID { get; set; }
        public Module Module { get; set; }
        public string Grade { get; set; }

        public Results()
        {
            Grade = "-";
        }

        public Results(Module module)
        {
            Module = module;
            Grade = "-";
        }

        public double GPV
        {
            get
            {
                if (Grade == "A") return 4.0;
                else if (Grade == "B") return 3.5;
                else if (Grade == "C") return 2.5;
                else if (Grade == "E") return 0;
                else return -1;
            }


        }
    }
}
