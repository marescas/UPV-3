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
    public partial class AsignarMonitor : Form
    {
        private IGestDepService service;
        private IEnumerable<Monitor> monitores;
        private IEnumerable<Course> cursos;
        private Boolean monitorYaAsignado;

        public AsignarMonitor(IGestDepService service)
        {
            InitializeComponent();
            this.service = service;
        }

        public void AsignarMonitor_Load(object sender, EventArgs e)
        {
            // Llenar comboBox Courses
            comboBoxCursos.Text = "";
            comboBoxCursos.Items.Clear();
            cursos = service.getAllCourses();
            foreach (Course c in cursos)
            {
                comboBoxCursos.Items.Add(c);
            }
            textBoxInfoCurso.Text = "Información del curso seleccionado.";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        
        private void comboBoxMonitores_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBoxCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Course selectedCourse = (Course) comboBoxCursos.SelectedItem;
            String texto = selectedCourse.Description;
            // Llenar comboBox Monitors
            comboBoxMonitores.Text = "";
            comboBoxMonitores.Items.Clear();
            monitores = service.getAllMonitors();
            foreach (Monitor m in monitores)
            {
                if(selectedCourse.canSetMonitor(m))
                    comboBoxMonitores.Items.Add(m);
                Console.WriteLine("Para el monitor "+m.Name+", canSetMonitor: "+selectedCourse.canSetMonitor(m));
            }
            monitorYaAsignado = false;
            if(selectedCourse.Monitor != null)
            {
                texto += " - El monitor de este curso ya ha sido asignado.";
                monitorYaAsignado = true;
            }
            textBoxInfoCurso.Text = texto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String error = "";
            if (monitorYaAsignado)
            {
                error += "El curso seleccionado ya tiene un monitor asignado.\n";
                MessageBox.Show(error, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBoxCursos.SelectedItem == null)
            {
                error += "Selecciona un curso de la lista de cursos.\n";
                MessageBox.Show(error, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBoxMonitores.SelectedItem == null)
            {
                error += "Selecciona un monitor de la lista de monitores disponibles.\n";
                MessageBox.Show(error, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Ejecutar asignación.
                ((Course)comboBoxCursos.SelectedItem).setMonitor((Monitor) comboBoxMonitores.SelectedItem);
                service.saveChanges();
                Console.WriteLine("Asignación entre el monitor y el curso seleccionados.");
                this.Close();
            }
        }
    }
}
