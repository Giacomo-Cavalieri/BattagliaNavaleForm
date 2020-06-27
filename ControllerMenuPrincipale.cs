using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattagliaNavale
{
    class ControllerMenuPrincipale
    {
        private MenuPrincipaleForm menuPrincipale;
        private static ControllerMenuPrincipale istanza;
        

        // Costruttore
        private ControllerMenuPrincipale()
        {
            this.menuPrincipale = new MenuPrincipaleForm();
            this.menuPrincipale.FormBorderStyle = FormBorderStyle.FixedDialog;
            InizializzaEventi();
        }

        // Metodo per l'implementazione del Design Pattern Singleton
        public static ControllerMenuPrincipale getIstanza()
        {
            if (istanza == null)
            {
                istanza = new ControllerMenuPrincipale();
            }

            return istanza;
        }


        // Inizializzo gli eventi del form
        public void InizializzaEventi()
        {
            this.menuPrincipale.IniziaPartitaBtn.MouseClick += new MouseEventHandler(this.InziaPartita_Click);
            this.menuPrincipale.EsciDalGiocoBtn.MouseClick += new MouseEventHandler(this.EsciDalGioco_Click);            
        }
        

        // Metodo che gestisce il click sul bottone IniziaPartita
        private void InziaPartita_Click(object sender, MouseEventArgs e)
        {
            // Dichiaro il controllerPartita utilizzando il metodo getIstanza()
            ControllerPartita controllerPartita = new ControllerPartita();
            controllerPartita.MostraPartitaForm();
            // Nascondo il menu principale
            menuPrincipale.Visible = false;
            menuPrincipale.Close();   
        }

        // Metodo che gestisce il click su bottone EsciDalGioco
        private void EsciDalGioco_Click(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        public void MostraMenuPrincipale()
        {
            // Carico l'immagine di sfondo del menu principale
            this.menuPrincipale.SfondoMenuPrincipale.Image = (Image)Properties.Resources.sfondoMenuPrincipale;
            this.menuPrincipale.ShowDialog();
        }
    }    
}
