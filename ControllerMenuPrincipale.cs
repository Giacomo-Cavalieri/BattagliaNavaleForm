using System.Drawing;
using System.Windows.Forms;

namespace BattagliaNavale
{
    class ControllerMenuPrincipale
    {
        // 
        public MenuPrincipaleForm MenuPrincipale { get; set; }
        // variabile per il singleton
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
            // Inizializzo i click dei bottoni
            this.MenuPrincipale.IniziaPartitaBtn.MouseClick += new MouseEventHandler(this.InziaPartita_Click);
            this.MenuPrincipale.EsciDalGiocoBtn.MouseClick += new MouseEventHandler(this.EsciDalGioco_Click);
            // Stampo le informazioni riguardanti il titolo del gioco,
            // gli autori e il docente di riferimento
            MenuPrincipale.TitoloLabel.Text = "BATTAGLIA NAVALE";
            MenuPrincipale.Autore1.Text = "Pavel Bucsanu [Mat. 271426]";
            MenuPrincipale.Autore2.Text = "Giacomo Cavalieri [Mat. 272094]";
            MenuPrincipale.Docente.Text = "Docente: Saverio Delpriori";
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
            // Label titolo
            this.MenuPrincipale.TitoloLabel.Parent = this.MenuPrincipale.SfondoMenuPrincipale;
            this.MenuPrincipale.TitoloLabel.BackColor = Color.Transparent;
            // Label autore1
            this.MenuPrincipale.Autore1.Parent = this.MenuPrincipale.SfondoMenuPrincipale;
            this.MenuPrincipale.Autore1.BackColor = Color.Transparent;
            // Label autore2
            this.MenuPrincipale.Autore2.Parent = this.MenuPrincipale.SfondoMenuPrincipale;
            this.MenuPrincipale.Autore2.BackColor = Color.Transparent;
            // Label docente
            this.MenuPrincipale.Docente.Parent = this.MenuPrincipale.SfondoMenuPrincipale;
            this.MenuPrincipale.Docente.BackColor = Color.Transparent;
            // Carico l'immagine di sfondo del menu principale
            this.MenuPrincipale.SfondoMenuPrincipale.Image = (Image)Properties.Resources.sfondoMenuPrincipale;

            this.MenuPrincipale.ShowDialog();            
        }
    }    
}
