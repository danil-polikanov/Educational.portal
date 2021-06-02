using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRefactoring.Entities
{
    public class ElectronicPublication
    {
        public string[] authors { get; set; }
        public uint NumberOfPages { get; set; }
        public string Format { get; set; }
        public DateTime YearOfPublishing { get; set; }
            }
}
