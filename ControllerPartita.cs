using ModelloBattagliaNavale;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
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

        // Dichiaro una variabile bottone che sarà una matrice di dimensione 10
        private Button[,] campoG1Btn;
        private Button[,] campoG2Btn;


        private Nave naveSelezionata;

        private bool direzioneInserimento;




        // Costruttore della classe
        private ControllerPartita()
        {
            this.giocatore_1 = new Giocatore("Giacomo");
            this.giocatore_2 = new Giocatore("Pavel");
            
            this.formPartita = new PartitaForm();
            this.formPartita.FormBorderStyle = FormBorderStyle.FixedDialog;

            this.campoG1Btn = new Button[giocatore_1.MioCampo.Dimensione, giocatore_1.MioCampo.Dimensione];

            this.campoG2Btn = new Button[giocatore_2.MioCampo.Dimensione, giocatore_2.MioCampo.Dimensione];

            this.direzioneInserimento = true;

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

            // Messaggio di benvenuto            
            formPartita.ConsoleLabel.Text = "Per iniziare seleziona una nave e inseriscila in campo!!";

            // 1)Invoco la funzione per la stampa dei campi dei giocatori
            stampaCampo(formPartita.PanelGiocatore_1, giocatore_1.MioCampo, campoG1Btn);
            //stampaCampo(formPartita.PanelGiocatore_2, giocatore_2.MioCampo, campoG2Btn);
        }

        private void stampaCampo(Panel panel, CampoDaGioco campoDaGioco, Button[,] bottone)
        {
            
            
            // Setto la dimensione dei bottoni del campo da gioco
            int dimensioneBottone = panel.Width / campoDaGioco.Dimensione;
            // Faccio in modo che il panel sia un quadrato perfetto
            panel.Height = panel.Width;


            // Doppio ciclo for per creare i bottoni e stamparli a schermo
            for (int i = 0; i < campoDaGioco.Dimensione; i++)
            {
                for (int j = 0; j < campoDaGioco.Dimensione; j++)
                {
                    
                    bottone[i, j] = new Button();
                    bottone[i, j].Height = dimensioneBottone;
                    bottone[i, j].Width = dimensioneBottone;

                    // Aggiungo un evento ad ogni click per ogni bottone
                    bottone[i, j].MouseDown += bottoneCampoDaGioco_Click;


                    // Aggiungo i bottoni al panel del giocatore
                    panel.Controls.Add(bottone[i, j]);

                    

                    // Stampo i bottoni in punti precisi del panel
                    bottone[i, j].Location = new Point(j * dimensioneBottone, i * dimensioneBottone);
                    
                    // utilizzo un tag per salvare la posizione del bottone
                    //bottone[i, j].Text = i + " | " + j;
                    bottone[i, j].Tag = new Point(i, j);

                    
                }
            }
        }

        private void bottoneCampoDaGioco_Click(object sender, MouseEventArgs e)
        {
            
            // Ottengo le cordinate del bottone cliccato
            Button bottoneCliccato = (Button) sender;
            Point posizione = (Point)bottoneCliccato.Tag;
            

            Casella casellaSelezionata = new Casella(posizione.X, posizione.Y);

            formPartita.ConsoleLabel.Text = "Hai selezionato le cordinate (" + casellaSelezionata.Riga + ", " + casellaSelezionata.Colonna + ")" + direzioneInserimento;

            
            if(naveSelezionata == null)
            {
                formPartita.ConsoleLabel.Text = "Non hai selezionato ancora nessuna nave!";
            }
            else
            {
                switch (e.Button)
                {
                    case MouseButtons.Right:
                        // Se premo il tasto destro del mouse devo modificare la direzione dell'inserimento da orizzontale
                        // a verticale o viceversa                        

                        direzioneInserimento = !direzioneInserimento;
                        formPartita.ConsoleLabel.Text = "valore di direzioneInserimento:" + direzioneInserimento;

                        break;
                    case MouseButtons.Left:
                        // Controllo che la nave non sia stata inserita in precedenza
                        if (naveSelezionata.Inserita)
                        {
                            formPartita.ConsoleLabel.Text = "La nave selezionata è gia stata inserita. Provane un'altra idiota!!!";
                        }
                        else
                        {
                            // Provo l'inserimento della nave nel campo del giocatore                            
                            naveSelezionata.InserimentoNave(casellaSelezionata, giocatore_1.MioCampo, direzioneInserimento);
                            // Condizione if per controllare che l'inserimento sia andato a buon fine
                            if (naveSelezionata.Inserita)
                            {
                                // Se l'inserimento è andato a buon fine aggiorno il campo da gioco del giocatore in modo che l'utente
                                // possa vedere l'avvenuto inserimento
                                for (int i = 0; i < naveSelezionata.Lunghezza; i++)
                                {
                                    campoG1Btn[naveSelezionata.Posizione[i].Riga, naveSelezionata.Posizione[i].Colonna].Text = "" + naveSelezionata.SimboloNave;
                                    campoG1Btn[naveSelezionata.Posizione[i].Riga, naveSelezionata.Posizione[i].Colonna].BackColor = Color.Gray;
                                }
                            }
                            else
                            {
                                formPartita.ConsoleLabel.Text = "La casella e/o la direzione scelta non risulta valida";
                            }
                        }
                        break;                    
                }                                       
            }
            // Invoco la funzione che andrà a controllare se la partita può iniziare
            controlloInizioPartita();
        }


        // Metodo che controlla se tutte le navi del giocatore sono state inserite.
        // In caso positivo, la partita può iniziare
        public void controlloInizioPartita()
        {
            bool naviPosizionate = true;
            // Ciclo foreach per controllare lo stato di tutte le navi
            foreach (Nave naveAttuale in giocatore_1.ListaNavi)
            {
                // Se anche solo una nave non è stata inserita il bottone non verrà mai stampato
                if (naveAttuale.Inserita != true)
                {
                    naviPosizionate = false;
                }
                
                if (naviPosizionate)
                {
                    // il bottone può essere stampato
                    this.formPartita.NaviPosizionateBtn.Visible = true;
                }                
                else
                {
                    // il bottone non sarà stampato
                    this.formPartita.NaviPosizionateBtn.Visible = false;
                }

            }
        }

        // metodo per inizializzare i vari click delle varie navi
        public void InizializzaEventi()
        {
            this.formPartita.Portaerei_Pic.MouseClick += new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Incrociatore_1Pic.MouseClick += new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Incrociatore_2Pic.MouseClick += new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Torpediniere_1Pic.MouseClick += new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Torpediniere_2Pic.MouseClick += new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Torpediniere_3Pic.MouseClick += new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Sottomarino_1Pic.MouseClick += new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Sottomarino_2Pic.MouseClick += new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Sottomarino_3Pic.MouseClick += new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Sottomarino_4Pic.MouseClick += new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.NaviPosizionateBtn.MouseClick += new MouseEventHandler(this.naviPosizionate_Click);
        }

        private void naviPosizionate_Click(object sender, MouseEventArgs e)
        {
            stampaCampo(formPartita.PanelGiocatore_2, giocatore_2.MioCampo, campoG2Btn);
            giocatore_2.CollocaNaviIA();

            for (int i = 0; i < giocatore_2.MioCampo.Dimensione; i++)
            {
                for (int j = 0; j < giocatore_2.MioCampo.Dimensione; j++)
                {
                    if(giocatore_2.MioCampo.Casella[i, j].StatoCasella == Stato.occupata)
                    {
                        campoG2Btn[i, j].Text = "" + giocatore_2.MioCampo.Casella[i, j].SimboloCasella;
                    }
                }
            }
        }

        // Metodo per gestire quale nave ha selezionato l'utente
        public void naveSelezionata_Click(object sender, MouseEventArgs e)
        {
            PictureBox picSelezionata = sender as PictureBox;
            // Serie di if-else per capire quale nave ha selezionato il giocatore
            if (sender.Equals(this.formPartita.Portaerei_Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[0];
                picSelezionata.BackColor = Color.LightGray;
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
            }
            else if (sender.Equals(this.formPartita.Incrociatore_1Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[1];
                picSelezionata.BackColor = Color.LightGray;
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
            }
            else if (sender.Equals(this.formPartita.Incrociatore_2Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[2];
                picSelezionata.BackColor = Color.LightGray;
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
            }
            else if (sender.Equals(this.formPartita.Torpediniere_1Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[3];
                picSelezionata.BackColor = Color.LightGray;
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
            }
            else if (sender.Equals(this.formPartita.Torpediniere_2Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[4];
                picSelezionata.BackColor = Color.LightGray;
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
            }
            else if (sender.Equals(this.formPartita.Torpediniere_3Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[5];
                picSelezionata.BackColor = Color.LightGray;
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
            }
            else if (sender.Equals(this.formPartita.Sottomarino_1Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[6];
                picSelezionata.BackColor = Color.LightGray;
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
            }
            else if (sender.Equals(this.formPartita.Sottomarino_2Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[7];
                picSelezionata.BackColor = Color.LightGray;
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
            }
            else if (sender.Equals(this.formPartita.Sottomarino_3Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[8];
                picSelezionata.BackColor = Color.LightGray;
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
            }
            else if (sender.Equals(this.formPartita.Sottomarino_4Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[9];
                picSelezionata.BackColor = Color.LightGray;
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
            }            
        }

        // Metodo per mostrare il form della partita
        public void MostraPartitaForm()
        {
            // Carico l'immagine delle navi
            // Portaerei
            this.formPartita.Portaerei_Pic.Image = (Image)Properties.Resources.portaereiPic;
            this.formPartita.Portaerei_Pic.Parent = this.formPartita.SfondoPartita;
            this.formPartita.Portaerei_Pic.BackColor = Color.Transparent;
            // Incrociatori
            this.formPartita.Incrociatore_1Pic.Image = (Image)Properties.Resources.incrociatorePic;
            this.formPartita.Incrociatore_1Pic.Parent = this.formPartita.SfondoPartita;
            this.formPartita.Incrociatore_1Pic.BackColor = Color.Transparent;
            this.formPartita.Incrociatore_2Pic.Image = (Image)Properties.Resources.incrociatorePic;
            this.formPartita.Incrociatore_2Pic.Parent = this.formPartita.SfondoPartita;
            this.formPartita.Incrociatore_2Pic.BackColor = Color.Transparent;
            // Torpedinieri
            this.formPartita.Torpediniere_1Pic.Image = (Image)Properties.Resources.torpedinierePic;
            this.formPartita.Torpediniere_1Pic.Parent = this.formPartita.SfondoPartita;
            this.formPartita.Torpediniere_1Pic.BackColor = Color.Transparent;
            this.formPartita.Torpediniere_2Pic.Image = (Image)Properties.Resources.torpedinierePic;
            this.formPartita.Torpediniere_2Pic.Parent = this.formPartita.SfondoPartita;
            this.formPartita.Torpediniere_2Pic.BackColor = Color.Transparent;
            this.formPartita.Torpediniere_3Pic.Image = (Image)Properties.Resources.torpedinierePic;
            this.formPartita.Torpediniere_3Pic.Parent = this.formPartita.SfondoPartita;
            this.formPartita.Torpediniere_3Pic.BackColor = Color.Transparent;
            // Sottomarini
            this.formPartita.Sottomarino_1Pic.Image = (Image)Properties.Resources.sottomarinoPic;
            this.formPartita.Sottomarino_1Pic.Parent = this.formPartita.SfondoPartita;
            this.formPartita.Sottomarino_1Pic.BackColor = Color.Transparent;
            this.formPartita.Sottomarino_2Pic.Image = (Image)Properties.Resources.sottomarinoPic;
            this.formPartita.Sottomarino_2Pic.Parent = this.formPartita.SfondoPartita;
            this.formPartita.Sottomarino_2Pic.BackColor = Color.Transparent;
            this.formPartita.Sottomarino_3Pic.Image = (Image)Properties.Resources.sottomarinoPic;
            this.formPartita.Sottomarino_3Pic.Parent = this.formPartita.SfondoPartita;
            this.formPartita.Sottomarino_3Pic.BackColor = Color.Transparent;
            this.formPartita.Sottomarino_4Pic.Image = (Image)Properties.Resources.sottomarinoPic;
            this.formPartita.Sottomarino_4Pic.Parent = this.formPartita.SfondoPartita;
            this.formPartita.Sottomarino_4Pic.BackColor = Color.Transparent;

            // Sfondo
            this.formPartita.SfondoPartita.Image = (Image)Properties.Resources.sfondoPartitaPic;
            // Panel Giocatore 1
            this.formPartita.PanelGiocatore_1.Parent = this.formPartita.SfondoPartita;
            this.formPartita.PanelGiocatore_1.BackColor = Color.Transparent;
            // Panel Giocatore 2
            this.formPartita.PanelGiocatore_2.Parent = this.formPartita.SfondoPartita;
            this.formPartita.PanelGiocatore_2.BackColor = Color.Transparent;
            // Label console
            this.formPartita.ConsoleLabel.Parent = this.formPartita.SfondoPartita;
            this.formPartita.ConsoleLabel.BackColor = Color.Transparent;
            
            // Visualizzo il form
            this.formPartita.ShowDialog();
        }
    }
}
