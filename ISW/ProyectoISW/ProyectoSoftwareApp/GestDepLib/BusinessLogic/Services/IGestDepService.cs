using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestDepLib.Entities;

namespace GestDepLib.Services
{
    public interface IGestDepService
    {
        void addCourse(Course c);
        void removeAllData();
        void addPool(Pool pool);
        IEnumerable<Pool> getAllPools();
        Pool findPoolById(int i);
        void saveChanges();
        void addMonitor(Monitor m);
        Course findCourseByName(string v);
        void enrollUserToCourse(DateTime dateTime, User u, Course c);
        void enrollMonitorToCourse(Monitor m, Course c);
        void addFreeSwimPayment(DateTime dateTime);
        void addPayment(Enrollment e, DateTime dateTime);
        IEnumerable<Enrollment> getAllEnrollments();
        IEnumerable<Payment> getAllFreeSwimPayments();
        IEnumerable<Monitor> getAllMonitors();
        IEnumerable<Course> getAllCourses();
        IEnumerable<User> getAllUsers();
        Monitor getMonitorBySsn(String Ssn);
        double descuentoAplicable(User u, Course curso);
        Pool encontrarPiscina(Course c);
        void addUser(User u);
        System.Windows.Forms.ListViewItem[] listarCallesLibres(Pool p, DateTime d);
        Enrollment findEnrollment(Course c, string id);
    }
}
