using GestDepLib.Persistence;
using GestDepLib.Entities;
using System.Linq;
using GestDepLib;
using System;
using System.Data.Entity;
using System.Text;
using System.Collections.Generic;

namespace GestDep.Testing
{
    class DBTest
    {
        static void Main(string[] args)
        {
            IDAL dal = new EntityFrameworkDAL(new GestDepDbContext());
            populateDB(dal);
            displayData(dal);
        }

        private static void populateDB(IDAL dal)
        {
            // Remove all data from DB
            dal.Clear<Course>();
            dal.Clear<Enrollment>();
            dal.Clear<Lane>();
            dal.Clear<Monitor>();
            dal.Clear<Payment>();
            dal.Clear<Person>();
            dal.Clear<Pool>();
            dal.Clear<User>();


            Pool pool = new Pool(1, Convert.ToDateTime("08:00:00"), Convert.ToDateTime("14:00:00"), 46122, 5, 5, 2.00);
            List<Lane> lanes = new List<Lane>();

            for (int i = 1; i <= 6; i++)
            {
                lanes.Add(new Lane(i));
            }

            pool.Lanes = lanes;
            dal.Insert(pool);



            User person1 = new User("Ona Carbonell address", "Ona Carbonell", "1234567890", 46002, "ES891234121234567890", new DateTime(1990, 06, 05), false);
            User person2 = new User("Gemma Mengual adress", "Gemma Mengual", "2345678901", 46002, "ES891234121234567890", new DateTime(1997, 04, 12), false);
            User person3 = new User("Mirella Belmonte's adress", "Mirella Belmonte", "3456789012", 46003, "ES891234121234567890", new DateTime(1990, 11, 10), false);
            User person4 = new User("Rigoberto's adress", "Rigoberto", "4567890123", 46122, "ES891234121234567890", new DateTime(1995, 02, 28), false);
            User person5 = new User("Lázaro's adress", "Lázaro", "5678901234", 46122, "ES891234121234567890", new DateTime(1992, 01, 01), false);

            Monitor person6 = new Monitor("X-00000001", "Michael Phelps", " Michael Phelps' adress" , 46001, "ES891234121234567890", "SSN01010101");
            dal.Insert(person6);

            dal.Insert(person1);
            dal.Insert(person2);
            dal.Insert(person3);
            dal.Insert(person4);
            dal.Insert(person5);

            dal.Insert(person6);

            TimeSpan timeCourse = new TimeSpan(0, 45, 0);
            TimeSpan timeCourse2 = new TimeSpan(1, 0, 0);

            Course course = new Course("Learning with M. Phelps", new DateTime(2017,11, 6), new DateTime(2018, 6, 29), Convert.ToDateTime("09:30:00"), new TimeSpan(0, 45, 0),
                                  Days.Monday | Days.Wednesday | Days.Friday,
                                  6, 20, false, 100);

            course.Monitor = person6;

            Course course1 = new Course("Swimming for Dummys", new DateTime(2017, 11, 07), new DateTime(2018, 06, 29), Convert.ToDateTime("19:00"), new TimeSpan(1, 0, 0),
                                    Days.Tuesday | Days.Thursday, 8, 16, true, 75);

            

            course.Lanes.Add(pool.Lanes.ElementAt(0));
            course.Lanes.Add(pool.Lanes.ElementAt(1));
            course1.Lanes.Add(pool.Lanes.ElementAt(2));

            dal.Insert(course);
            dal.Insert(course1);

            Payment payment1 = new Payment(new DateTime(2017, 08, 10), "Free Swim", 3);
            Payment payment2 = new Payment(new DateTime(2017, 08, 20), "Free Swim", 3);
            Payment payment3 = new Payment(new DateTime(2017, 08, 20), "Free Swim", 3);
            Payment payment4 = new Payment(new DateTime(2017, 08, 16), "First monthly quota - Learning with M. Phelps", 100);
            Payment payment5 = new Payment(new DateTime(2017, 08, 26), "First monthly quota - Learning with M. Phelps", 100);
            Payment payment6 = new Payment(new DateTime(2017, 08, 28), "First monthly quota - Learning with M. Phelps", 100);
            Payment payment7 = new Payment(new DateTime(2017, 08, 28), "Swimming for Dummys", 75);
            Payment payment8 = new Payment(new DateTime(2017, 09, 04), "Swimming for Dummys", 75);

            dal.Insert(payment1);
            dal.Insert(payment2);
            dal.Insert(payment3);
            dal.Insert(payment4);
            dal.Insert(payment5);
            dal.Insert(payment6);
            dal.Insert(payment7);
            dal.Insert(payment8);
            
            Enrollment enrollment1 = new Enrollment(null, new DateTime(2017, 08, 16), null, course, person1, payment4);
            Enrollment enrollment2 = new Enrollment(null, new DateTime(2017, 08, 26), null, course, person2, payment5);
            Enrollment enrollment3 = new Enrollment(null, new DateTime(2017, 08, 28), null, course, person3, payment6);
            Enrollment enrollment4 = new Enrollment(new DateTime(2017, 10, 20), new DateTime(2017, 08, 28), null, course1, person4, payment7);
            Enrollment enrollment5 = new Enrollment(new DateTime(2017, 10, 20), new DateTime(2017, 09, 04), null, course1, person5, payment8);

            dal.Insert(enrollment1);
            dal.Insert(enrollment2);
            dal.Insert(enrollment3);
            dal.Insert(enrollment4);
            dal.Insert(enrollment5);



            dal.Commit();

        }

        private static void displayData(IDAL dal)
        {
            Pool pool = dal.GetAll<Pool>().First();
            foreach (Course course in dal.GetAll<Course>())
            {
                Console.WriteLine("===================================");
                Console.WriteLine("         Course details         ");
                Console.WriteLine("===================================");
                Console.WriteLine(CourseToString(course));
                //foreach (Days day in Enum.GetValues(typeof(Days)))
                //{
                //    if ((course.CourseDays & day) == day)
                //        Console.WriteLine("Course on " + day.ToString());
                //}
            }
            Console.WriteLine("Payments:");
            foreach (Payment pay in dal.GetAll<Payment>())
                Console.Write(PaymentToString(pay));
            Console.WriteLine("Pres Key to exit...");
            Console.ReadKey();
        }

        public static String PersonToString(Person person)
        {
            return person.Name + " (" + person.Id + ")";
        }

        public static String CourseToString(Course course)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("StartDate: " + course.StartDate);
            sb.AppendLine("FinishDate: " + course.FinishDate);
            sb.AppendLine("Days : " + course.CourseDays);
            sb.AppendLine("Price: " + course.Price);
            sb.AppendLine("Lanes assigned: ");
            foreach (Lane lane in course.Lanes)
                sb.AppendLine(" Lane " + lane.Number);
            if (course.Monitor != null)
                sb.AppendLine("\nUsers enrolled in course " + course.Description + ", with monitor " + PersonToString(course.Monitor));
            else sb.AppendLine("\nUsers enrolled in course " + course.Description + ", with no monitor yet");
            foreach (Enrollment en in course.Enrollments)
            {
                sb.Append(" " + EnrollmentToString(en));
            }
            //sb.AppendLine("");
            return sb.ToString();
        }

        public static String EnrollmentToString(Enrollment en)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(PersonToString(en.User) + " enrolled on " + en.EnrollmentDate);
            return sb.ToString();
        }

        public static String PaymentToString(Payment pay)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" " + pay.Date + " -> " + pay.Description + ": " + pay.Quantity);
            return sb.ToString();
        }


        private static DateTime createTime(int hours, int minutes, int seconds)
        {
            DateTime now = DateTime.Now;
            return new DateTime(now.Year, now.Month, now.Day, hours, minutes, seconds);
        }

    }
}