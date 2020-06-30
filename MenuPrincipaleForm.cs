using System.Windows.Forms;

namespace BattagliaNavale
{
    public partial class MenuPrincipaleForm : Form
    {


        public MenuPrincipaleForm()
        {
            InitializeComponent();
        }

        // Property per ottenere il bottone per iniziare la partita
        public Button IniziaPartitaBtn
        {
            get { return this.iniziaBtn; }
        }

        // Property per ottenere il bottone per uscire dal gioco

        public Button EsciDalGiocoBtn
        {
            get { return this.esciBtn; }
        }


        // Property per lo sfondo del menu principale
        public PictureBox SfondoMenuPrincipale
        {
            get { return this.sfondoMenuPic; }
            set { this.sfondoMenuPic = value; }
        }

    }
}
