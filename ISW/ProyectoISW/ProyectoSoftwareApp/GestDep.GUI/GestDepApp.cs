using GestDepLib.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestDepLib.Persistence;
using GestDepLib.Entities;

namespace GestDep.GUI
{
    public partial class GestDepApp : Form
    {
        private IGestDepService service;
        private AnadirCurso cursoForm;
        private AsignarMonitor asignarMonitor;
        private MatricularUsuario matricularUsuario;
        private AnadirUsuario anadirUsuario;
        private ListarCallesLibres listarCallesLibres;
        public GestDepApp(IGestDepService s)
        {
            InitializeComponent();
            service = s;
            cursoForm = new AnadirCurso(service);
            asignarMonitor = new AsignarMonitor(service);
            matricularUsuario = new MatricularUsuario(service);
            anadirUsuario = new AnadirUsuario(service,null,new DateTime());
            listarCallesLibres = new ListarCallesLibres(service);
        }

        private void GestDepApp_Load(object sender, EventArgs e)
        {
            vaciarBDButton.Enabled = false;
            iniciarBDButton.Enabled = false;
            StatusLabel.Text = "Preparando la base de datos...";
            Cursor = Cursors.AppStarting;
            adminSelector.Select();

            var worker = new BackgroundWorker();
            worker.DoWork += delegate
            {
                service.removeAllData();
            };
            worker.RunWorkerCompleted += delegate
            {
                Cursor = Cursors.Default;
                iniciarBDButton.Enabled = true;
                StatusLabel.Text = "";
                Console.WriteLine("Base de datos vaciada con éxito.");
            };
            worker.RunWorkerAsync();
        }

        private void anadirCursoClick(object sender, EventArgs e)
        {
            cursoForm.Text = "Añadir curso";
            cursoForm.ShowDialog();
        }

        private void asignarMonitorClick(object sender, EventArgs e)
        {
            asignarMonitor.Text = "Asignar monitor";
            asignarMonitor.ShowDialog();
        }

        private void matricularUsuarioClick(object sender, EventArgs e)
        {
            matricularUsuario.Text = "Matricular usuario";
            matricularUsuario.ShowDialog();
        }

        private void asignarUsuarioClick(object sender, EventArgs e)
        {
            anadirUsuario.Text = "Añadir usuario";
            anadirUsuario.ShowDialog();
        }

        private void listarCallesLibresClick(object sender, EventArgs e)
        {
            listarCallesLibres.Text = "Listar calles libres";
            listarCallesLibres.ShowDialog();
        }

        private void iniciarBD(object sender, EventArgs e)
        {
            Console.WriteLine("Iniciando base de datos...");
            StatusLabel.Text = "Iniciando base de datos...";
            iniciarBDButton.Enabled = false;
            Cursor = Cursors.WaitCursor;

            var worker = new BackgroundWorker();
            worker.DoWork += delegate
            {
                // Adding Pool and Lanes
                addPoolAndLanes();
                // Adding Courses
                addCourses();
                // Adding Monitor
                addMonitor();
                // Adding Users and Enrollments
                addUsers();
                // Adding payments
                addPayments();
                // Testing Free Lanes
                testingFreeLanes();
            };
            worker.RunWorkerCompleted += delegate
            {
                Cursor = Cursors.Default;
                vaciarBDButton.Enabled = true;
                StatusLabel.Text = "";
                Console.WriteLine("Base de datos iniciada con éxito.");
            };
            worker.RunWorkerAsync();
        }

        private void vaciarBD(object sender, EventArgs e)
        {
            Console.WriteLine("Vaciando base de datos...");
            StatusLabel.Text = "Vaciando base de datos...";
            vaciarBDButton.Enabled = false;
            Cursor = Cursors.WaitCursor;

            var worker = new BackgroundWorker();
            worker.DoWork += delegate
            {
                service.removeAllData();
            };
            worker.RunWorkerCompleted += delegate
            {
                Cursor = Cursors.Default;
                iniciarBDButton.Enabled = true;
                StatusLabel.Text = "";
                Console.WriteLine("Base de datos vaciada con éxito.");
            };
            worker.RunWorkerAsync();
        }

        private void GestionarPermisos(object sender, EventArgs e)
        {
            if (adminSelector.Checked == true)
            {
                anadirCursoButton.Enabled = true;
                asignarMonitorButton.Enabled = true;
                matricularUsuarioButton.Enabled = false;
                anadirUsuarioButton.Enabled = false;
                listarCallesLibresButton.Enabled = false;
            } else if (employeeSelector.Checked == true) {
                anadirCursoButton.Enabled = false;
                asignarMonitorButton.Enabled = false;
                matricularUsuarioButton.Enabled = true;
                anadirUsuarioButton.Enabled = true;
                listarCallesLibresButton.Enabled = true;
            }
        }

        private void ClosingApp(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Cerrando aplicación...");
            /*if(vaciarBDButton.Enabled == true)
            {
                Console.WriteLine("Vaciando base de datos antes de cerrar...");
                System.Threading.Thread closeThread = new System.Threading.Thread(new System.Threading.ThreadStart(service.removeAllData));
                closeThread.Start();
            } else if (StatusLabel.Text != "") {
                Console.WriteLine("Aplicación cerrada mientras se modificaba la BD.");
            }*/
        }

        void addPoolAndLanes()
        {
            Console.WriteLine();
            Console.WriteLine("ADDING POOL AND LANES...");

            try
            {
                // Pool(int id, DateTime OpeningHour, DateTime ClosingHour, int ZipCode, int discountLocal, int discountRetired, double freeSwimPrice)
                // Id is not autogenerated
                Pool pool = new Pool(1, Convert.ToDateTime("08:00:00"), Convert.ToDateTime("14:00:00"), 46122, 5, 5, 2.00);
                for (int i = 1; i < 7; i++)
                {
                    pool.addLane(new Lane(i));
                }
                service.addPool(pool);

                foreach (Pool p in service.getAllPools())
                {
                    Console.WriteLine(" Pool " + p.Id);
                    foreach (Lane l in p.Lanes)
                        Console.WriteLine("   Lane " + l.Number);
                }

            }
            catch (Exception e)
            {
                printError(e);
            }
        }

        static void printError(Exception e)
        {
            while (e != null)
            {
                Console.WriteLine("ERROR: " + e.Message);
                e = e.InnerException;
            }
        }

        void addCourses()
        {
            Console.WriteLine();
            Console.WriteLine("ADDING COURSES AND ASSIGNING LANES...");

            try
            {
                // Course(String description, DateTime startDate, DateTime finishDate, DateTime startHour, TimeSpan duration, Days courseDays, int minimunEnrollments, int maximunEnrollments, bool cancelled, double price)
                Course c = new Course("Learning with M. Phelps", new DateTime(2017, 9, 4), new DateTime(2018, 6, 29), Convert.ToDateTime("09:30:00"), new TimeSpan(0, 45, 0),
                                  Days.Monday | Days.Wednesday | Days.Friday,
                                  6, 20, false, 100);
                service.addCourse(c);

                Console.WriteLine("  Course days: " + c.CourseDays);
                if ((c.CourseDays & Days.Friday) == Days.Friday)
                    Console.WriteLine("   Course on Friday");
                else
                    Console.WriteLine("   Course is NOT on Friday");
                //Console.WriteLine(c.ToString());
                // Adding lanes for a Course
                Pool p = service.findPoolById(1); // ¡¡¡¡¡¡¡ Assuming that Id is not autogenerated !!!!!!

                c.addLane(p.findLane(3));
                c.addLane(p.findLane(4));
                c.addLane(p.findLane(5));
                service.saveChanges();


                // Testing Lanes assigned
                Console.WriteLine("\n  Lanes assigned");
                foreach (Lane la in c.Lanes)
                    Console.WriteLine("   " + la.Number + " assigned");

                // Adding another Course
                c = new Course("201 - Swimming", new DateTime(2018, 1, 6), new DateTime(2018, 3, 30), Convert.ToDateTime("09:30:00"), new TimeSpan(0, 45, 0),
                  Days.Monday | Days.Wednesday | Days.Friday,
                  6, 20, false, 100);
                service.addCourse(c);

                // Adding lanes for a Course
                p = service.findPoolById(1); // ¡¡¡¡¡¡¡ Assuming that Id is not autogenerated !!!!!!
                c.addLane(p.findLane(1));
                c.addLane(p.findLane(6));
                service.saveChanges();

            }
            catch (Exception e)
            {
                printError(e);
            }

        }

        void addMonitor()
        {
            Console.WriteLine();
            Console.WriteLine("ADDING MONITOR...");

            try
            {
                // Monitor(string id, string Name, string Address, int ZipCode, string IBAN, string Ssn)
                Monitor m = new Monitor("X-00000001", "Michael Phelps", " Michael Phelps'address", 46001, "ES891234121234567890", "SSN01010101");
                service.addMonitor(m);

                Course c = service.findCourseByName("Learning with M. Phelps");
                c.setMonitor(m);
                service.saveChanges();
                Console.WriteLine("   " + c.Monitor.Name + " assigned to " + c.Description + " course");

                // Add the same monitor to another course with collision dates
                // Must fails by collision dates
                c = service.findCourseByName("201 - Swimming");
                c.setMonitor(m);
                service.saveChanges();
                Console.WriteLine("   " + c.Monitor.Name + " assigned to " + c.Description + " course");
            }
            catch (Exception e)
            {
                printError(e);
            }
        }

        void addUsers()
        {
            Console.WriteLine();
            Console.WriteLine("ADDING USERS...");

            try
            {
                Course c = service.findCourseByName("Learning with M. Phelps");

                // User(string id, string name, string address, int zipCode, string IBAN, DateTime birthDate, bool retired)
                User u = new User("1234567890", "Ona Carbonell", "Ona Carbonell's address", 46002, "ES891234121234567890", new DateTime(1990, 6, 5), false);
                service.enrollUserToCourse(new DateTime(2017, 08, 16), u, c);

                u = new User("2345678901", "Gemma Mengual", "Gemma Mengual's address", 46002, "ES891234121234567890", new DateTime(1977, 4, 12), false);
                service.enrollUserToCourse(new DateTime(2017, 07, 26), u, c);

                u = new User("3456789012", "Mireia Belmonte", "Mireia Belmonte's address", 46003, "ES891234121234567890", new DateTime(1990, 11, 10), false);
                service.enrollUserToCourse(new DateTime(2017, 08, 28), u, c);

                u = new User("4567890123", "Rigoberto", "Rigoberto's address", 46122, "ES891234121234567890", new DateTime(1995, 2, 28), false);
                service.enrollUserToCourse(new DateTime(2017, 08, 28), u, c);

                u = new User("5678901234", "Lázaro", "Lázaro's address", 46122, "ES891234121234567890", new DateTime(1900, 1, 1), true);
                service.enrollUserToCourse(new DateTime(2017, 08, 29), u, c);

                // Checking Users enrolled
                Console.WriteLine("  Users enrolled in course with monitor " + c.Monitor.Name);
                foreach (Enrollment en in c.Enrollments)
                    Console.WriteLine("   " + en.User.Name + " enrolled");

            }
            catch (Exception e)
            {
                printError(e);
            }
        }

        void addPayments()
        {
            Console.WriteLine();
            Console.WriteLine("ADDING PAYMENTS...");

            try
            {

                service.addFreeSwimPayment(new DateTime(2017, 8, 10, 18, 12, 5));

                service.addFreeSwimPayment(new DateTime(2017, 8, 20, 18, 12, 5));

                service.addFreeSwimPayment(new DateTime(2017, 8, 20, 18, 13, 5));

                // Adding Payments
                Course c = service.findCourseByName("Learning with M. Phelps");

                Enrollment e = c.findEnrollment("1234567890");
                service.addPayment(e, new DateTime(2017, 8, 16, 12, 30, 0));

                service.addPayment(e, new DateTime(2017, 8, 17, 13, 30, 1));


                e = c.findEnrollment("5678901234");
                service.addPayment(e, new DateTime(2017, 09, 29));



                // Testing Payments
                foreach (Enrollment en in service.getAllEnrollments())
                {
                    Console.WriteLine("\n  Payments attached to " + en.User.Name);
                    foreach (Payment moO in en.Payments)
                        Console.WriteLine("   " + moO.Description + " " + moO.Quantity);
                }

                Console.WriteLine("\n  Free Swim payments");
                foreach (Payment p in service.getAllFreeSwimPayments())
                    Console.WriteLine("   " + p.Quantity + " " + p.Date);

            }
            catch (Exception e)
            {
                printError(e);
            }
        }

        void testingFreeLanes()
        {
            Console.WriteLine();
            Console.WriteLine("TESTING FREE LANES");

            try
            {
                // Test free lanes week 2018, 1, 29
                Pool p = service.findPoolById(1);

                int freeLanes = p.getFreeLanes(new DateTime(2018, 1, 29, 8, 00, 0), Days.Monday);
                Console.WriteLine("   Free lanes at 8:00 - " + freeLanes);

                freeLanes = p.getFreeLanes(new DateTime(2018, 1, 29, 9, 30, 0), Days.Monday);
                Console.WriteLine("   Free lanes at 9:30 - " + freeLanes);

            }
            catch (Exception e)
            {
                printError(e);
            }
        }

        private void TitleLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
