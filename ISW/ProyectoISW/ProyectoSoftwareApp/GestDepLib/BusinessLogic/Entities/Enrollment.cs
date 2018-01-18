using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDepLib.Entities
{
    public partial class Enrollment
    {
        public Enrollment()
        {
            Payments = new List<Payment>();
        }

        public Enrollment(DateTime? CancellationDate, DateTime EnrollmentDate, DateTime? ReturnedFirstCuotaIfCancelledCourse, Course Course, User User, Payment Payment)
        {
            this.CancellationDate = CancellationDate;
            this.EnrollmentDate = EnrollmentDate;
            this.Id = Id;
            this.ReturnedFirstCuotaIfCancelledCourse = ReturnedFirstCuotaIfCancelledCourse;
            this.Course = Course;
            this.User = User;
            Payments = new List<Payment>();
            Payments.Add(Payment);
        }
    }
}