using System.Drawing;
using System.Windows.Forms;

namespace BattagliaNavale
{
    class ControllerMenuPrincipale
    {
        public MenuPrincipaleForm MenuPrincipale { get; set; }
        private static ControllerMenuPrincipale istanza;
        

        // Costruttore
        private ControllerMenuPrincipale()
        {
            this.MenuPrincipale = new MenuPrincipaleForm();
            this.MenuPrincipale.FormBorderStyle = FormBorderStyle.FixedDialog;
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
            this.MenuPrincipale.IniziaPartitaBtn.MouseClick += new MouseEventHandler(this.InziaPartita_Click);
            this.MenuPrincipale.EsciDalGiocoBtn.MouseClick += new MouseEventHandler(this.EsciDalGioco_Click);            
        }
        

        // Metodo che gestisce il click sul bottone IniziaPartita
        private void InziaPartita_Click(object sender, MouseEventArgs e)
        {
            // Nascondo il menu principale
            MenuPrincipale.Visible = false;
            // Dichiaro il controllerPartita utilizzando il metodo getIstanza()
            ControllerPartita controllerPartita = new ControllerPartita();
            controllerPartita.MostraPartitaForm();               
        }

        // Metodo che gestisce il click su bottone EsciDalGioco
        private void EsciDalGioco_Click(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        public void MostraMenuPrincipale()
        {
            // Carico l'immagine di sfondo del menu principale
            this.MenuPrincipale.SfondoMenuPrincipale.Image = (Image)Properties.Resources.sfondoMenuPrincipale;
            this.MenuPrincipale.ShowDialog();
        }
    }    
}
