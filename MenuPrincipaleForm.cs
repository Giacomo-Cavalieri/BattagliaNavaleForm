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

        // Property per il titolo del gioco
        public Label TitoloLabel
        {
            get { return this.titoloLabel; }
            set { this.titoloLabel = value; }
        }

        // Property per l'autore 1 del gioco
        public Label Autore1
        {
            get { return this.autore1; }
            set { this.autore1 = value; }
        }

        // Property per l'autore 2 del gioco        
        public Label Autore2
        {
            get { return this.autore2; }
            set { this.autore2 = value; }
        }

        // Property per il docente del progetto        
        public Label Docente
        {
            get { return this.docente; }
            set { this.docente = value; }
        }

    }
}
