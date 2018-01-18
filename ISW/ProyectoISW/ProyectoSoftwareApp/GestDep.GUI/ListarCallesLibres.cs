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
using static System.Windows.Forms.ListViewItem;

namespace GestDep.GUI
{
    public partial class ListarCallesLibres : Form
    {
        private IGestDepService service;
        Pool selectedPool;
        DateTime selectedDate;
       
        public ListarCallesLibres(IGestDepService service)
        {
            InitializeComponent();
            this.service = service;
            selectedPool = null;
            // Fecha del DateTimePicker al lunes de la semana actual
            dateSelector.Value = DateTime.Today.AddDays(-(DateTime.Today.DayOfWeek - DayOfWeek.Monday));
        }

        private void ListarCallesLibres_Load(object sender, EventArgs e)
        {
            // Obtenemos la lista de piscinas
            IEnumerable<Pool> pools = null;
            try
            {
                pools = service.getAllPools();
            } catch
            {
                pools = new List<Pool>();
            }
            // Limpiar selector de piscina
            poolSelector.Text = "";
            poolSelector.Items.Clear();
            // Añadir piscinas al selector
            foreach (Pool p in pools)
            {
                poolSelector.Items.Add(p);
            }
            // Fecha seleccionada = Fecha del selector (lunes de la semana actual)
            selectedDate = dateSelector.Value;
            // Limpiar información de las calles libres
            CallesLibresTable.Clear();
        }

        private void updateSelectedPool(object sender, EventArgs e)
        {
            // Guardamos la piscina seleccionada y actualizamos la tabla
            selectedPool = (Pool) poolSelector.SelectedItem;
            updateCallesTable();
        }

        private void updateSelectedDate(object sender, EventArgs e)
        {
            // Si no hemos seleccionado un lunes
            if(dateSelector.Value.DayOfWeek != DayOfWeek.Monday)
            {
                // Restamos días hasta que el día seleccionado sea un lunes
                dateSelector.Value = dateSelector.Value.AddDays(-(dateSelector.Value.DayOfWeek - DayOfWeek.Monday));
            }
            // Guardamos la nueva fecha seleccionada
            selectedDate = dateSelector.Value;
            Console.WriteLine("Selected date: " + selectedDate);
            // Si no hay una piscina seleccionada, no mostramos nada
            if (selectedPool != null) updateCallesTable();
        }

        public void updateCallesTable()
        {
            Console.WriteLine("Información " + selectedPool.ToString() + ", fecha " + selectedDate.ToString());

            // Limpiar BD
            CallesLibresTable.Clear();
            
            // Añadir columnas
            CallesLibresTable.Columns.Add("HorarioKey", "Horario", 80);
            CallesLibresTable.Columns.Add("CallesLibresKey", "Calles libres", 80);

            // Inicializar grupos
            ListViewGroup lunes = new ListViewGroup("Lunes");
            ListViewGroup martes = new ListViewGroup("Martes");
            ListViewGroup miercoles = new ListViewGroup("Miércoles");
            ListViewGroup jueves = new ListViewGroup("Jueves");
            ListViewGroup viernes = new ListViewGroup("Viernes");
            ListViewGroup sabado = new ListViewGroup("Sábado");
            
            // Fechas de apertura y cierre de la piscina
            DateTime opening = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, selectedPool.OpeningHour.Hour, selectedPool.OpeningHour.Minute, 0);
            DateTime closing = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, selectedPool.ClosingHour.Hour, selectedPool.ClosingHour.Minute, 0);

            while (opening < closing)
            {
                ListViewItem[] lista = service.listarCallesLibres(selectedPool, opening); // GestDepService
                
                // Asignamos los grupos de la tabla a cada item de la lista
                lista[0].Group = lunes;
                lista[1].Group = martes;
                lista[2].Group = miercoles;
                lista[3].Group = jueves;
                lista[4].Group = viernes;
                lista[5].Group = sabado;

                CallesLibresTable.Items.AddRange(lista); // Añadimos los datos a la tabla
                opening += new TimeSpan(0, 45, 0); // Incrementamos 45min para la siguiente franja
            }

            // Agregar grupos a la tabla
            CallesLibresTable.Groups.Add(lunes);
            CallesLibresTable.Groups.Add(martes);
            CallesLibresTable.Groups.Add(miercoles);
            CallesLibresTable.Groups.Add(jueves);
            CallesLibresTable.Groups.Add(viernes);
            CallesLibresTable.Groups.Add(sabado);
        }
    }
}
