using System;
using System.Collections.Generic;
using System.Text;

namespace Ado.Net_EF.Models
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Group { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname} {Group}";
        }
    }
}
