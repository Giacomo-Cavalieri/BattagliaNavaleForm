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
        public PictureBox Sottomarino_1
        {
            get { return this.sottomarino_1Pic; }
            set { this.sottomarino_1Pic = value; }
        }

        public PictureBox Sottomarino_2
        {
            get { return this.sottomarino_2Pic; }
            set { this.sottomarino_2Pic = value; }
        }

        public PictureBox Sottomarino_3
        {
            get { return this.sottomarino_3Pic; }
            set { this.sottomarino_3Pic = value; }
        }

        public PictureBox Sottomarino_4
        {
            get { return this.sottomarino_4Pic; }
            set { this.sottomarino_4Pic = value; }
        }
    }
}
