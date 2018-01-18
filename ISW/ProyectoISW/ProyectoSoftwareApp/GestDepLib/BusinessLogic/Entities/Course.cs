using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestDepLib.Services;

namespace GestDepLib.Entities
{
    public partial class Course
    {
        public Course()
        {
            Lanes = new List<Lane>();
            Enrollments = new List<Enrollment>();
        }

        public Course(String description, DateTime startDate, DateTime finishDate, DateTime startHour, TimeSpan duration, Days courseDays, int minimunEnrollments, int maximunEnrollments, bool cancelled, double price)
        {
            Cancelled = cancelled;
            CourseDays = courseDays;
            Description = description;
            Duration = duration;
            FinishDate = finishDate;
            Id = Id;
            MaximunEnrollments = maximunEnrollments;
            MinimunEnrollments = minimunEnrollments;
            Price = price;
            StartDate = startDate;
            StartHour = startHour;
            Lanes = new List<Lane>();
            Enrollments = new List<Enrollment>();
        }
        public void addLane(Lane lane)
        {
                Lanes.Add(lane);
            
        }
        public Lane findLane(int v)
        {
            foreach (Lane l in Lanes)
            {
                if (l.Number == v) return l;
            }
            return null;
        }
        public Boolean isFull()
        {
            return Enrollments.Count == MaximunEnrollments;
        }
        public void setMonitor(Monitor m)
        {
            if (this.Monitor != null)
            {
                throw new ServiceException("Ya hay un monitor asignado a este curso.");
            }
            bool disponible = true;
            foreach (Course c in m.Courses)
            {
                // Si alguno de los días coincide, es cuando se hará la comprobación de fecha y hora.
                if ((c.CourseDays & this.CourseDays) != 0)
                {
                    if (TimeOfDayIsBetween(this.StartHour, c.StartHour, c.StartHour + c.Duration)
                        && DayIsBetween(this.StartDate, c.StartDate, c.FinishDate))
                    {
                        disponible = false;
                    }
                }
            }
            if (disponible) this.Monitor = m;
            else throw new ServiceException("Este monitor no está disponible en ese horario.");
        }
        public Boolean canSetMonitor(Monitor m)
        {
            bool disponible = true;
            foreach (Course c in m.Courses)
            {
                // Si alguno de los días coincide, es cuando se hará la comprobación de fecha y hora.
                if ((c.CourseDays & this.CourseDays) != 0)
                {
                    if (TimeOfDayIsBetween(this.StartHour, c.StartHour, c.StartHour + c.Duration)
                        && DayIsBetween(this.StartDate, c.StartDate, c.FinishDate))
                    {
                        disponible = false;
                    }
                }
            }
            if (disponible) return true;
            else return false;
        }
        public Enrollment findEnrollment(string v)
        {
            foreach (Enrollment e in Enrollments) {
                //Console.WriteLine(e.User.Id);
                if (e.User.Id.Equals(v)) return e;
            }
            return null;
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

        public override string ToString()
        {
            return this.Description;
        }
    }
}
