using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestDepLib.Services;
using GestDepLib.Entities;
using GestDep.GUI;

namespace GestDep.GUI
{
    public partial class MatricularUsuario : Form
    {
        private IGestDepService service;
        

        public MatricularUsuario(IGestDepService service)
        {
            InitializeComponent();
            this.service = service;

           
        }

        private void MatricularUsuario_Load(object sender, EventArgs e)
        {
            comboBoxCursos.Items.Clear();
            comboBoxUsuarios.Items.Clear();
            // Llenar los dos comboBox
            foreach (User u in service.getAllUsers())
            {
                comboBoxUsuarios.Items.Add(u);
            }
            foreach (Course c in service.getAllCourses())
            {
                if (c.StartDate >= DateTime.Today || c.FinishDate>= DateTime.Today)
                    comboBoxCursos.Items.Add(c);
            }
        }

        private void comboBoxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            comprobarTextoBoton();
            comprobarDisponibilidadBoton();
        }

        private void checkBoxNuevoUsuario_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNuevoUsuario.Checked)
            {
                comboBoxUsuarios.Enabled = false;
            }
            else
            {
                comboBoxUsuarios.Enabled = true;
            }
            comprobarTextoBoton();
            comprobarDisponibilidadBoton();
        }

        private void comboBoxCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            comprobarTextoBoton();
            comprobarDisponibilidadBoton();
        }

        
      

        private void button1_Click(object sender, EventArgs e)
        {
            Course c =(Course) comboBoxCursos.SelectedItem;
            if (button1.Text.Equals("Siguiente"))
            {
                AnadirUsuario siguiente = new AnadirUsuario(service,c,new DateTime());
                siguiente.Show();
            }
            else {
                User u = (User)comboBoxUsuarios.SelectedItem;
               
                try
                {
                    Enrollment enroll2 = service.findEnrollment(c, u.Id);
                    if (enroll2 == null)
                    {
                        service.enrollUserToCourse(DateTime.Today, u, c);
                        Enrollment enroll = service.findEnrollment(c, u.Id);
                        MessageBox.Show("Usuario " + u.Name + " matriculado con éxito. Precio: " + enroll.Payments.First().Quantity);
                    } else
                    {
                        MessageBox.Show("El usuario ya estaba matriculado en el curso.");
                    }
                }
                catch (ServiceException excp) {
                    MessageBox.Show(excp.Message);
                }
            }
        }

        private void comprobarTextoBoton()
        {
            if (checkBoxNuevoUsuario.Checked)
            {
                button1.Text = "Siguiente";
            }
            else
            {
                button1.Text = "Asignar";
            }
        }

        private void comprobarDisponibilidadBoton()
        {
            if ((comboBoxCursos.SelectedItem != null ) &&
                (comboBoxUsuarios.SelectedItem != null || checkBoxNuevoUsuario.Checked))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}
