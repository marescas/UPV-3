using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDepLib.Entities
{
    public partial class Monitor
    {
        public Monitor()
        {
            Courses = new List<Course>();
        }

        public Monitor( string Id, string Name, string Address,  int ZipCode, string IBAN, string Ssn) : base(Address,IBAN,Id,Name,ZipCode)
        {
            this.Ssn = Ssn;
            Courses = new List<Course>();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}