using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BattagliaNavale
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Dichiaro il controller del menù Principale
            ControllerMenuPrincipale menuPrincipale = new ControllerMenuPrincipale();
            // Mostro il form del menuPrincipale
            menuPrincipale.MostraMenuPrincipale();
        }
    }
}
