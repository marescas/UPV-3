using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDepLib.Entities
{
    public partial class Pool
    {
        public Pool()
        {
            Lanes = new List<Lane>();
        }

        public override string ToString()
        {
            return "Pool " + Id;
        }

        public Pool(int id, DateTime OpeningHour, DateTime ClosingHour, int ZipCode, int discountLocal, int discountRetired, double freeSwimPrice)
        {
            this.OpeningHour = OpeningHour;
            this.ClosingHour = ClosingHour;
            this.ZipCode = ZipCode;
            this.Id = id;
            DiscountRetired = discountRetired;
            DiscountLocal = discountLocal;
            FreeSwimPrice = freeSwimPrice;
            Lanes = new List<Lane>();
        }
        public void addLane(Lane lane)
        {
       
                Lanes.Add(lane);
            
        }
        public Lane findLane(int v)
        {
            foreach(Lane l in Lanes)
            {
                if (l.Number == v) return l;
            }
            return null;
        }
        public int getFreeLanes(DateTime dateTime, Days day)
        {
            int numLanes = this.Lanes.Count;
            foreach (Lane l in this.Lanes)
            {
                foreach (Course c in l.Courses)
                {
                    if ((c.CourseDays & day) != 0)
                    {
                        if (TimeOfDayIsBetween(dateTime, c.StartHour, c.StartHour + c.Duration)
                            && DayIsBetween(dateTime, c.StartDate, c.FinishDate))
                        {
                            numLanes--;
                        }
                    }
                }
            }
            return numLanes;
        }

        public ICollection<Lane> getLanesList()
        {
            ICollection<Lane> res = this.Lanes;
            return res;
        }
        public ICollection<Lane> getFreeLanesList(DateTime dateTime, Days day)
        {
            ICollection<Lane> res = new List<Lane>();
            bool ocupada;
            foreach (Lane l in this.Lanes)
            {
                ocupada = false;
                foreach (Course c in l.Courses)
                {
                    if ((c.CourseDays & day) != 0)
                    {
                        if (TimeOfDayIsBetween(dateTime, c.StartHour, c.StartHour + c.Duration)
                            && DayIsBetween(dateTime, c.StartDate, c.FinishDate))
                        {
                            ocupada = true;
                        }
                    }
                }
                if(!ocupada) res.Add(l);
            }
            return res;
        }

        public static bool TimeOfDayIsBetween(DateTime t, DateTime start, DateTime end)
        {
            var time_of_day = t.TimeOfDay;
            var start_time_of_day = start.TimeOfDay;
            var end_time_of_day = end.TimeOfDay;

            if (start_time_of_day <= end_time_of_day)
                return start_time_of_day <= time_of_day && time_of_day <= end_time_of_day;

            return start_time_of_day <= time_of_day || time_of_day <= end_time_of_day;
        }
        public static bool DayIsBetween(DateTime t, DateTime start, DateTime end)
        {
            return (t >= start && t <= end);
        }
    }
}
