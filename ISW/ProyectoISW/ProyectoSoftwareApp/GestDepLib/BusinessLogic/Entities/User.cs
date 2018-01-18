using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDepLib.Entities
{
    public partial class User
    {
        public User()
        {
            Enrollments = new List<Enrollment>();
        }
        public User(string id, string Name, string Adress, int ZipCode, string IBAN, DateTime BirthDate, Boolean Retired) : base(Adress, IBAN, id,Name,ZipCode)
        {
            this.BirthDate = BirthDate;
            this.Retired = Retired;
            Enrollments = new List<Enrollment>();
        }
        public override string ToString()
        {
            return this.Id;
        }
    }
}
