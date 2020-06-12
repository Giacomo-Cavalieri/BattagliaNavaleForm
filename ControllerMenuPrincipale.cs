using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattagliaNavale
{
    class ControllerMenuPrincipale
    {
        private MenuPrincipaleForm menuPrincipale;        

        // Costruttore
        public ControllerMenuPrincipale()
        {
            this.menuPrincipale = new MenuPrincipaleForm();          
            InizializzaEventi();
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
            throw new NotImplementedException();
        }

        // Metodo che gestisce il click su bottone EsciDalGioco
        private void EsciDalGioco_Click(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        public void MostraMenuPrincipale()
        {
            this.menuPrincipale.ShowDialog();
        }
    }    
}
