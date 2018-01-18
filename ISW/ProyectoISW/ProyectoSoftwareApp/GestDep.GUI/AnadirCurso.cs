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
    public partial class AnadirCurso : Form
    {
        private IGestDepService service;
        

        public AnadirCurso(IGestDepService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void AnadirCurso_Load(object sender, EventArgs e)
        {
            HoraInicioPicker.Format = DateTimePickerFormat.Time;
            checkedListBoxCalles.Items.Clear();
            ICollection<Lane> lanestotal = service.getAllPools().First().Lanes;
            foreach (Lane l in lanestotal)
            {
                Console.WriteLine("[DEBUG] Linea añadida: " + l.ToString());
                checkedListBoxCalles.Items.Add(l);
                checkedListBoxCalles.SelectedItems.Add(l);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void saveButtonClick(object sender, EventArgs e)
        {
            try
            {
                String descripcion = DescriptionBox.Text;
                DateTime inicio = Convert.ToDateTime(fechaInicioPicker.Text);
                DateTime fin = Convert.ToDateTime(FinDatePicker.Text);
                DateTime horaInicioAux = Convert.ToDateTime(HoraInicioPicker.Text);
                DateTime horaInicio = new DateTime(inicio.Year, inicio.Month, inicio.Day, horaInicioAux.Hour, horaInicioAux.Minute, horaInicioAux.Second);
                double precio = Convert.ToDouble(PriceText.Text);
                int maxEnrollment = Convert.ToInt32(matriculaMax.Text);
                int minEnrollment = Convert.ToInt32(matriculaMin.Text);
                Boolean cancelado = cancelCheck.Checked;
                TimeSpan duracion = new TimeSpan(0, Convert.ToInt32(duracionText.Text), 00);
                Days dias = new Days();
                for (int i = 0; i < 7; i++) {
                    if (checkDays.GetItemChecked(0)) {
                        switch (checkDays.SelectedIndex)
                        {
                            case 0:
                                dias = dias | Days.Monday;
                                break;
                            case 1:
                                dias = dias | Days.Tuesday;
                                break;
                            case 2:
                                dias = dias | Days.Wednesday;
                                break;
                            case 3:
                                dias = dias | Days.Thursday;
                                break;
                            case 4:
                                dias = dias | Days.Friday;
                                break;
                            case 5:
                                dias = dias | Days.Saturday;
                                break;

                            case 6:
                                dias = dias | Days.Sunday;
                                break;

                        }
                    }
                }
               
                
                Course c = new Course(descripcion, inicio, fin, horaInicio, duracion, dias, minEnrollment, maxEnrollment, cancelado, precio);
                
                ICollection<Lane> lanes =  service.getAllPools().First().getFreeLanesList(horaInicio,dias);
                Console.WriteLine("Horario: " + inicio.ToString());
                int contador = checkedListBoxCalles.CheckedItems.Count;
                Console.WriteLine(contador + " calles seleccionadas.");
                foreach (Lane lin in lanes) {
                    Console.WriteLine("[DEBUG] Linea libre: " + lin);
                    if (checkedListBoxCalles.CheckedItems.Contains(lin))
                    {
                        Console.WriteLine("[DEBUG] Está libre");
                        contador--;
                        c.addLane(lin);
                    }
                }
                if (contador ==0)
                {
                    Console.WriteLine("Hora inicio del curso: " + c.StartHour.ToString());
                    foreach(Lane l in c.Lanes)
                    {
                        Console.WriteLine("[CURSO] Linea: " + l.ToString());
                    }
                    Console.WriteLine("[DEBUG] Contador == 0");
                    service.addCourse(c);
                    service.saveChanges();
                    MessageBox.Show("Curso guardado con éxito.");
                } else
                {
                    throw new ServiceException("comprueba las lineas.");
                }
            }
            catch (ServiceException error)
            {
                MessageBox.Show(error.Message);
            }
            
    

        }

        private void Numberpress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        

        private void PriceText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}