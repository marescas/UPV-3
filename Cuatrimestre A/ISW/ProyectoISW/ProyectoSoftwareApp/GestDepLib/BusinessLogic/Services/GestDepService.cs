using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestDepLib.Entities;
using GestDepLib.Persistence;
using System.Windows.Forms;

namespace GestDepLib.Services
{
    public class GestDepService : IGestDepService
    {
        private readonly IDAL dal;
        public GestDepService(IDAL dal)
        {
            this.dal = dal;
        }
        public void addCourse(Course c)
        {
            if (c.StartDate > c.FinishDate) throw new ServiceException("El curso no puede acabar antes de empezar");
            if (c.MinimunEnrollments == 0) throw new ServiceException("El número mínimo de usuarios matriculados debe ser mayor que 0");
            int restantes = c.Lanes.Count;
            //List<Lane> freeLanes = new List<Lane>();
            foreach (Pool p in getAllPools())
            {
                ICollection<Lane> callesLibres = p.getFreeLanesList(c.StartDate, c.CourseDays);
                restantes = c.Lanes.Count;
                restantes -= c.Lanes.Intersect<Lane>(callesLibres).Count(); 
                //la unica "pega" que  tiene es que necesita el comparador de igualdad (equals) y el getHascode, supongo que utilizará tablas hash para hacer la intersección ¡implementado! 
                /* foreach (Lane l1 in c.Lanes)
                 {
                     if (callesLibres.Contains(l1)) { restantes--; }
                     c.Lanes.Intersect<Lane>(callesLibres).Count();
                     foreach (Lane l2 in callesLibres)
                     {

                         if (l1.Equals(l2))
                         {
                             restantes--;
                             break;
                         }
                     }

                 }
                 */
            }
            if (restantes == 0)
            {
                dal.Insert<Course>(c);
                saveChanges();
            } else {
                throw new ServiceException("No hay huecos disponibles para impartir el curso");
            }
        }

        public void addFreeSwimPayment(DateTime dateTime)
        {
            Pool primera = findPoolById(1);
            Payment p = new Payment(dateTime, "Free Swim", primera.FreeSwimPrice);
            dal.Insert<Payment>(p);
            saveChanges();
        }

        public void addMonitor(Monitor m)
        {
            if (getMonitorBySsn(m.Ssn) == null)
            {
                dal.Insert<Monitor>(m);
                saveChanges();
            }
            else {
                throw new ServiceException("El monitor ya existe.");
            }
        }

        public void addPayment(Enrollment e, DateTime dateTime)
        {
            
            Payment p = new Payment(dateTime, e.Course.Description, e.Course.Price-descuentoAplicable(e.User,e.Course));
            e.Payments.Add(p);
            saveChanges();
        }

        public void addPool(Pool pool)
        {
            if (findPoolById(pool.Id) == null) {
                dal.Insert<Pool>(pool);
                saveChanges();
            }
            else {
                throw new ServiceException("La piscina ya existe");
            }
        }

        public void enrollUserToCourse(DateTime dateTime, User u, Course c)
        {
            if (c.isFull()) throw new ServiceException("El curso está lleno.");
            double descuento = descuentoAplicable(u,c);
            Payment p = new Payment(dateTime,c.Description,c.Price-descuento);
            c.Enrollments.Add(new Enrollment(null,dateTime,null,c,u,p));
            //u.Enrollments.Add(new Enrollment(null, dateTime, null, c, u, p));
            saveChanges();
           
            
        }
        public void enrollMonitorToCourse(Monitor m, Course c)
        {
            if (c.Monitor == null)
                c.Monitor = m;
            else throw new ServiceException("El curso ya tiene un monitor agregado.");
        }

        public Course findCourseByName(string v)
        {
            IEnumerable<Course> listaCursos = dal.GetAll<Course>();
            foreach (Course curso in listaCursos) {
                if (curso.Description.Equals(v)) return curso;
            }
            return null; 
        }

        public Pool findPoolById(int i)
        {
            return dal.GetById<Pool>(i);
        }

        public IEnumerable<Enrollment> getAllEnrollments()
        {
            return dal.GetAll<Enrollment>();
        }

        public Enrollment findEnrollment(Course c, string id)
        {
            IEnumerable<Enrollment> enrollments = getAllEnrollments();
            foreach(Enrollment e in enrollments)
            {
                if(e.Course.Description.Equals(c.Description) && e.User.Id.Equals(id))
                {
                    return e;
                }
            }

            return null;
        }

        public IEnumerable<Payment> getAllFreeSwimPayments()
        {
            IEnumerable<Payment> listaPagos = dal.GetAll<Payment>();
            ICollection<Payment> listaPagosBañoLibre = new List<Payment>();
            foreach (Payment pago in listaPagos) {
                if (pago.Description.Equals("Free Swim")) listaPagosBañoLibre.Add(pago);
            }
            return listaPagosBañoLibre;


        }

        public IEnumerable<Pool> getAllPools()
        {
            return dal.GetAll<Pool>();
        }

        public IEnumerable<Monitor> getAllMonitors()
        {
            return dal.GetAll<Monitor>();
        }
        public IEnumerable<Course> getAllCourses()
        {
            return dal.GetAll<Course>();
        }
        public IEnumerable<User> getAllUsers()
        {
            return dal.GetAll<User>();
        }

        public void removeAllData()
        {
            dal.Clear<Course>();
            dal.Clear<Enrollment>();
            dal.Clear<Lane>();
            dal.Clear<Monitor>();
            dal.Clear<Payment>();
            dal.Clear<Person>();
            dal.Clear<Pool>();
            dal.Clear<User>();
            saveChanges();
        }

        public void saveChanges()
        {
            dal.Commit();
        }
        public Monitor getMonitorBySsn(String Ssn) {
            IEnumerable<Monitor> monitores = dal.GetAll<Monitor>();
            foreach (Monitor m in monitores) {
                if (m.Ssn.Equals(Ssn)) return m;
            }
            return null;
        }

        public double descuentoAplicable(User u,Course curso) {
            Pool primera = findPoolById(1);
            Pool pool = encontrarPiscina(curso);
            int discount = 0;
           
            if (u.ZipCode == pool.ZipCode) discount+= primera.DiscountLocal;
            if (u.Retired) discount+= primera.DiscountRetired;
            return discount;
        }
        public Pool encontrarPiscina(Course c) {
            foreach (Pool p in getAllPools()) {
                foreach (Lane l in p.Lanes) {
                    if (l.Courses.Contains(c)) return p;
                }
            }
            return null;
        }

        public void addUser(User u)
        {
            IEnumerable<User> usuarios = dal.GetAll<User>();
            Boolean encontrado = false;
            foreach (User u2 in usuarios)
            {
                if (u2.Id.Equals(u.Id)) encontrado = true;
            }
            if (encontrado)
            {
                throw new ServiceException("El usuario ya existe");
            }
            else
            {
                dal.Insert<User>(u);
                saveChanges();
            }
        }

        public ListViewItem[] listarCallesLibres(Pool p, DateTime d) {
            ListViewItem[] lista = new ListViewItem[6]; // 6 días
            
            DateTime fin = d + new TimeSpan(0, 45, 0); // Hora de fin del curso

            // Lunes
            ListViewItem item = new ListViewItem();
            int callesLibres = p.getFreeLanes(d, Days.Monday);
            item.Text = String.Format("{0:t} - {1:t}", d, fin);
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, callesLibres.ToString()));
            lista[0] = item;

            // Martes
            item = new ListViewItem();
            callesLibres = p.getFreeLanes(d, Days.Tuesday);
            item.Text = String.Format("{0:t} - {1:t}", d, fin);
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, callesLibres.ToString()));
            lista[1] = item;

            // Miércoles
            item = new ListViewItem();
            callesLibres = p.getFreeLanes(d, Days.Wednesday);
            item.Text = String.Format("{0:t} - {1:t}", d, fin);
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, callesLibres.ToString()));
            lista[2] = item;

            // Jueves
            item = new ListViewItem();
            callesLibres = p.getFreeLanes(d, Days.Thursday);
            item.Text = String.Format("{0:t} - {1:t}", d, fin);
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, callesLibres.ToString()));
            lista[3] = item;

            // Viernes
            item = new ListViewItem();
            callesLibres = p.getFreeLanes(d, Days.Friday);
            item.Text = String.Format("{0:t} - {1:t}", d, fin);
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, callesLibres.ToString()));
            lista[4] = item;

            // Sábado
            item = new ListViewItem();
            callesLibres = p.getFreeLanes(d, Days.Saturday);
            item.Text = String.Format("{0:t} - {1:t}", d, fin);
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, callesLibres.ToString()));
            lista[5] = item;

            return lista;
        }
    }

}
