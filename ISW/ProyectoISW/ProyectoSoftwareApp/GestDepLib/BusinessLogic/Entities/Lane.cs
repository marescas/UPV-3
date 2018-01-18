using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDepLib.Entities
{
    public partial class Lane
    {
        public Lane()
        {
            Courses = new List<Course>();
        }

        public Lane(int Number)
        {
            this.Number = Number;
            Courses = new List<Course>();
        }
        public override bool Equals(Object obj)
        {
            Lane laneObj = obj as Lane;
            if (laneObj == null)
                return false;
            else
                return Number.Equals(laneObj.Number);
        }
        public override int GetHashCode()
        {
            return this.Id;
        }
        public override string ToString()
        {
            return "Lane " + Number;
        }
    }
}
