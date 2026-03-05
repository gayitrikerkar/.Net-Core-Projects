using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitTestingProject
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isIndian { get; set; }
        public Nationalities nationality { get; set; }
    }
}
