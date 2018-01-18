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

namespace GestDep.GUI
{
    public partial class AnadirUsuario : Form
    {
        private IGestDepService service;
        Course c;
        DateTime time;

        public AnadirUsuario(IGestDepService service, Course curso, DateTime t)
        {
            InitializeComponent();
            this.service = service;
            c = curso;
            time = t; 
        }

        private void AnadirUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                User u = new User(textBoxDni.Text, textBoxNombre.Text, textBoxDireccion.Text, Convert.ToInt32(textBoxCodigoPostal.Text), textBoxIban.Text,
                    Convert.ToDateTime(dateTimeNacimiento.Text), checkBoxJubilado.Checked);
                if (c == null)
                {
                    service.addUser(u);
                    MessageBox.Show("Guardado correctamente");
                }
                else
                {
                    Enrollment enroll2 = service.findEnrollment(c, u.Id);
                    if (enroll2 == null)
                    {
                        service.enrollUserToCourse(DateTime.Today, u, c);
                        Enrollment enroll = service.findEnrollment(c, u.Id);
                        MessageBox.Show("Usuario " + u.Name + " matriculado con éxito. Precio: " + enroll.Payments.First().Quantity);
                    }
                    else
                    {
                        MessageBox.Show("El usuario ya estaba matriculado en el curso.");
                    }
                }
            }catch(ServiceException error) {
                MessageBox.Show(error.Message);
            } catch
            {
                MessageBox.Show("Hay campos vacios o erróneos.");
            }
           
           
            
            // Parece que no se puede agregar un usuario sin matricularlo a un curso.
            // Método correcto: service.enrollUserToCourse(DateTime, User, Course);
            // Cuando se le de a OK en la ventana "Añadir usuario", esta deberá enviar el objeto User
            // a la ventana anterior "Matricular usuario" y así utilizarlo.
            // Posiblemente haya que eliminar la opción "Añadir usuario" de la ventana principal.

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            /**
            if (checkBoxJubilado.Checked)
            {
                labelIban.Visible = false;
                textBoxIban.Visible = false;
            } else
            {
                labelIban.Visible = true;
                textBoxIban.Visible = true;
            }
            **/
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBoxIban_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
