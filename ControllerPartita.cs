using ModelloBattagliaNavale;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        Nave naveSelezionata;




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
                    // utilizzo un tag per salvare la posizione del bottone
                    campoBtn[i, j].Tag = new Point(i, j);
                }
            }
        }

        private void bottoneCampoDaGioco_Click(object sender, MouseEventArgs e)
        {
            // Ottengo le cordinate del bottone cliccato
            Button bottoneCliccato = (Button) sender;
            Point posizione = (Point)bottoneCliccato.Tag;            

            Casella casellaSelezionata = new Casella(posizione.Y, posizione.X);

            string test1 = "( " + casellaSelezionata.Riga + ", " + casellaSelezionata.Colonna + ")";
            if(naveSelezionata == null)
            {
                MessageBox.Show("Non hai ancora selezionato nessuna nave");
            }
            else
            {
                string test = "caselle occupata dalla nave: (";
                MessageBox.Show("Hai selezionato la nave " + naveSelezionata.Nome + " e le coordinate " + test1);
                // Inserisco in griglia la nave selezionata
                naveSelezionata.InserimentoNave(casellaSelezionata, giocatore_1.MioCampo, true);
                for (int i = 0; i < giocatore_1.ListaNavi[6].Lunghezza; i++)
                {
                    test += giocatore_1.ListaNavi[6].Posizione[i].Riga;
                    test += ",";
                    test += giocatore_1.ListaNavi[6].Posizione[i].Colonna;
                }
                test += ")";
                MessageBox.Show(test);
                stampaCampo(formPartita.PanelGiocatore_1, giocatore_1.MioCampo);
            }            
        }


        // metodo per inizializzare i vari click delle varie navi
        public void InizializzaEventi()
        {
            this.formPartita.Sottomarino_1Pic.MouseClick += new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Sottomarino_2Pic.MouseClick += new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Sottomarino_3Pic.MouseClick += new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Sottomarino_4Pic.MouseClick += new MouseEventHandler(this.naveSelezionata_Click);
        }

        // Metodo per 
        public void naveSelezionata_Click(object sender, MouseEventArgs e)
        {
            
            PictureBox picSelezionata = sender as PictureBox;
            // Serie di if-else per capire quale nave ha selezionato il giocatore
            if (sender.Equals(this.formPartita.Sottomarino_1Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[6];
                
            }
            else if (sender.Equals(this.formPartita.Sottomarino_2Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[7];
            }
            else if (sender.Equals(this.formPartita.Sottomarino_3Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[8];
            }
            else if (sender.Equals(this.formPartita.Sottomarino_4Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[9];
            }
            
        }



        // Metodo per mostrare il form della partita
        public void MostraPartitaForm()
        {
            // Carico l'immagine dei sottomarini
            this.formPartita.Sottomarino_1Pic.Image = (Image)Properties.Resources.sottomarinoPic;
            this.formPartita.Sottomarino_2Pic.Image = (Image)Properties.Resources.sottomarinoPic;
            this.formPartita.Sottomarino_3Pic.Image = (Image)Properties.Resources.sottomarinoPic;
            this.formPartita.Sottomarino_4Pic.Image = (Image)Properties.Resources.sottomarinoPic;
            this.formPartita.ShowDialog();
        }
    }
}
