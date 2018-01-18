
using GestDepLib.Persistence;
using GestDepLib.Entities;
using GestDepLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace GestDep.GUI
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IGestDepService service = new GestDepService(new EntityFrameworkDAL(new GestDepDbContext()));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GestDepApp(service));
        }
    }
}
