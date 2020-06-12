using ModelloBattagliaNavale;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattagliaNavale
{
    class ControllerPartita
    {
        // Attributi necessari al controller
        private PartitaForm formPartita;
        private Giocatore giocatore_1;
        private Giocatore giocatore_2;
        private static ControllerPartita istanza;
        


        // Costruttore della classe
        private ControllerPartita()
        {

            this.giocatore_1 = new Giocatore("Giacomo");
            this.giocatore_2 = new Giocatore("Pavel");
            this.formPartita = new PartitaForm();
            this.formPartita.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Metodo dove inizializzo i vari click
            InizializzaEventi();
            PreparazionePartita();
        }

        // Metodo per l'implementazione del Design Pattern Singleton
        public static ControllerPartita getIstanza()
        {
            if (istanza == null )
            {
                istanza = new ControllerPartita();
            }

            return istanza;
        }

        private void PreparazionePartita()
        {
            // Dichiaro le variabili necessarie



            // 1)Invoco la funzione per la stampa dei campi dei giocatori
            stampaCampo(formPartita.PanelGiocatore_1, giocatore_1.MioCampo);
            stampaCampo(formPartita.PanelGiocatore_2, giocatore_2.MioCampo);
        }

        private void stampaCampo(Panel panel, CampoDaGioco campoDaGioco)
        {
            // Dichiaro una variabile bottone che sarà una matrice di dimensione 10
            Button[,] campoBtn = new Button[giocatore_1.MioCampo.Dimensione, giocatore_1.MioCampo.Dimensione];
            // Setto la dimensione dei bottoni del campo da gioco
            int dimensioneBottone = panel.Width / campoDaGioco.Dimensione;
            // Faccio in modo che il panel sia un quadrato perfetto
            panel.Height = panel.Width;


            // Doppio ciclo for per creare i bottoni e stamparli a schermo
            for (int i = 0; i < campoDaGioco.Dimensione; i++)
            {
                for (int j = 0; j < campoDaGioco.Dimensione; j++)
                {
                    campoBtn[i, j] = new Button();
                    campoBtn[i, j].Height = dimensioneBottone;
                    campoBtn[i, j].Width = dimensioneBottone;

                    // Aggiungo un evento ad ogni click per ogni bottone
                    campoBtn[i, j].MouseClick += bottoneCampoDaGioco_Click;


                    // Aggiungo i bottoni al panel del giocatore
                    panel.Controls.Add(campoBtn[i, j]);


                    // Stampo i bottoni in punti precisi del panel
                    campoBtn[i, j].Location = new Point(i * dimensioneBottone, j * dimensioneBottone);

                }
            }
        }

        private void bottoneCampoDaGioco_Click(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Hai cliccato un bottone del campo da gioco");
        }


        // metodo per inizializzare i vari click delle varie navi
        private void InizializzaEventi()
        {
            this.formPartita.Sottomarino_1.MouseClick += new MouseEventHandler(this.sottomarino_Click);         
        }

        private void sottomarino_Click(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Hai cliccato il sottomarino!!!!!");
        }



        // Metodo per mostrare il form della partita
        public void MostraPartita()
        {
            // Carico l'immagine del sottomarino
            this.formPartita.Sottomarino_1.Image = (Image)Properties.Resources.sottomarinoPic;
            this.formPartita.Sottomarino_2.Image = (Image)Properties.Resources.sottomarinoPic;
            this.formPartita.Sottomarino_3.Image = (Image)Properties.Resources.sottomarinoPic;
            this.formPartita.Sottomarino_4.Image = (Image)Properties.Resources.sottomarinoPic;
            this.formPartita.ShowDialog();
        }
    }
}
