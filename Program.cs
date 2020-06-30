using System;
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
            // Dichiaro il controller del menù Principale tramite il design pattern Singleton
            ControllerMenuPrincipale menuPrincipale = ControllerMenuPrincipale.getIstanza();
            // Mostro il form del menuPrincipale
            menuPrincipale.MostraMenuPrincipale();
        }
    }
}
