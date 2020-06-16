using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattagliaNavale
{
    public partial class PartitaForm : Form
    {
        public PartitaForm()
        {
            InitializeComponent();
        }

        // Property per ottenere il bottone che dà inizio alla partita
        public Button NaviPosizionateBtn
        {
            get { return this.naviPosizionateBtn; }
            set { this.naviPosizionateBtn = value; }
        }


        // Property per ottenere il panel per il campo del giocatore 1
        public Panel PanelGiocatore_1
        {
            get { return this.panelCampoGiocatore_1; }
        }

        // Property per ottenere il panel per il campo del giocatore 2
        public Panel PanelGiocatore_2
        {
            get { return this.panelCampoGiocatore_2; }
        }


        // picturebox per stampare il sottomarino
        public PictureBox Sottomarino_1Pic
        {
            get { return this.sottomarino_1Pic; }
            set { this.sottomarino_1Pic = value; }
        }

        public PictureBox Sottomarino_2Pic
        {
            get { return this.sottomarino_2Pic; }
            set { this.sottomarino_2Pic = value; }
        }

        public PictureBox Sottomarino_3Pic
        {
            get { return this.sottomarino_3Pic; }
            set { this.sottomarino_3Pic = value; }
        }

        public PictureBox Sottomarino_4Pic
        {
            get { return this.sottomarino_4Pic; }
            set { this.sottomarino_4Pic = value; }
        }

        public PictureBox Portaerei_Pic
        {
            get { return this.portaerei_Pic; }
            set { this.portaerei_Pic = value; }
        }

        public PictureBox Incrociatore_1Pic
        {
            get { return this.incrociatore_1Pic; }
            set { this.incrociatore_1Pic = value; }
        }

        public PictureBox Incrociatore_2Pic
        {
            get { return this.incrociatore_2Pic; }
            set { this.incrociatore_2Pic = value; }
        }

        public PictureBox Torpediniere_1Pic
        {
            get { return this.torpediniere_1Pic; }
            set { this.torpediniere_1Pic = value; }
        }

        public PictureBox Torpediniere_2Pic
        {
            get { return this.torpediniere_2Pic; }
            set { this.torpediniere_2Pic = value; }
        }
        public PictureBox Torpediniere_3Pic
        {
            get { return this.torpediniere_3Pic; }
            set { this.torpediniere_3Pic = value; }
        }


        public Label ConsoleLabel
        {
            get { return this.consoleLabel; }
            set { this.consoleLabel = value; }
        }

        public PictureBox SfondoPartita
        {
            get { return this.sfondoPartitaPic; }
            set { this.sfondoPartitaPic = value; }
        }
    }
}
