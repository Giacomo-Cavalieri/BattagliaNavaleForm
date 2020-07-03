using ModelloBattagliaNavale;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BattagliaNavale
{
    class ControllerPartita
    {        
        // Attributi necessari al controller
        private PartitaForm formPartita;
        private Giocatore giocatore_1;
        private Giocatore giocatore_2;        

        // Dichiaro una variabile bottone che sarà una matrice di dimensione 10
        // per il giocatore 1 e per il giocatore 2
        private Button[,] campoG1Btn;
        private Button[,] campoG2Btn;

        // attributo necessario per sapere quale nave è stata selezionata dall'utente
        private Nave naveSelezionata;

        // variabile che gestisce la direzione dell'inserimento del giocatore
        private bool direzioneInserimento;
        // variabile utile per sapere quale icona della nave è stata selezionata dall'utente       
        private PictureBox picSelezionata;

        // variabile timer per leggere i cambiamento nella consoleLabel del form
        System.Windows.Forms.Timer timer; 

        // Costruttore della classe
        public ControllerPartita()
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

        private void PreparazionePartita()
        {
            // Messaggio di benvenuto            
            formPartita.ConsoleLabel.Text = "Seleziona una nave con il click sinistro del mouse e inseriscila nel tuo campo!";

            // Faccio inserire le navi all'IA
            giocatore_2.CollocaNaviIA();

            // Invoco la funzione per la stampa dei campi dei giocatori
            stampaCampo();            
        }

        private void stampaCampo()
        {           
            // Setto la dimensione dei bottoni del campo da gioco
            int dimensioneBottone = formPartita.PanelGiocatore_1.Width / giocatore_1.MioCampo.Dimensione;
            // Faccio in modo che i panel siano un quadrato perfetto
            formPartita.PanelGiocatore_1.Height = formPartita.PanelGiocatore_1.Width;
            formPartita.PanelGiocatore_2.Height = formPartita.PanelGiocatore_2.Width;


            // Doppio ciclo for per creare i bottoni e stamparli a schermo
            for (int i = 0; i < giocatore_1.MioCampo.Dimensione; i++)
            {
                for (int j = 0; j < giocatore_1.MioCampo.Dimensione; j++)
                {
                    // Bottoni per il giocatore 1
                    campoG1Btn[i, j] = new Button();
                    campoG1Btn[i, j].Height = dimensioneBottone;
                    campoG1Btn[i, j].Width = dimensioneBottone;
                    // Bottoni per il giocatore 2
                    campoG2Btn[i, j] = new Button();
                    campoG2Btn[i, j].Height = dimensioneBottone;
                    campoG2Btn[i, j].Width = dimensioneBottone;
                    // Aggiungo un evento ad ogni click per ogni bottone
                    campoG1Btn[i, j].MouseDown += bottoneCampoDaGioco_Click;
                    

                    // Aggiungo i bottoni ai rispettivi panel
                    formPartita.PanelGiocatore_1.Controls.Add(campoG1Btn[i, j]);
                    formPartita.PanelGiocatore_2.Controls.Add(campoG2Btn[i, j]);

                    // Stampo i bottoni in punti precisi dei panel
                    campoG1Btn[i, j].Location = new Point(j * dimensioneBottone, i * dimensioneBottone);
                    campoG2Btn[i, j].Location = new Point(j * dimensioneBottone, i * dimensioneBottone);

                    // utilizzo un tag per salvare la posizione del bottone                    
                    campoG1Btn[i, j].Tag = new Point(i, j);
                    campoG2Btn[i, j].Tag = new Point(i, j);
                }
            }
        }

        

        private void bottoneCampoDaGioco_Click(object sender, MouseEventArgs e)
        {            
            // Ottengo le cordinate del bottone cliccato
            Button bottoneCliccato = (Button) sender;
            Point posizione = (Point)bottoneCliccato.Tag;            

            Casella casellaSelezionata = new Casella(posizione.X, posizione.Y);
            
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
                        formPartita.ConsoleLabel.Text = "Direzione inserirento:" + ((direzioneInserimento)? "orizzontale" : "verticale");

                        break;
                    case MouseButtons.Left:
                        // Controllo che la nave non sia stata inserita in precedenza
                        if (naveSelezionata.Inserita)
                        {
                            formPartita.ConsoleLabel.Text = "La nave selezionata è gia stata inserita.";
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
                                picSelezionata.BackColor = Color.FromArgb(73, 255, 93);
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
        private void controlloInizioPartita()
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

        // metodo per inizializzare i vari click delle varie navi e del bottone delle istruzioni
        private void InizializzaEventi()
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

        // Metodo che darà il via alla partita
        private void naviPosizionate_Click(object sender, MouseEventArgs e)
        {
            // Devo avviare la partita
            Partita();
        }

        private void Partita()
        {            
            // Rendo invisibile il tasto navi posizionate btn
            formPartita.NaviPosizionateBtn.Visible = false;
            // Disattivo il click sulle picturebox delle navi
            this.formPartita.Portaerei_Pic.MouseClick -= new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Incrociatore_1Pic.MouseClick -= new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Incrociatore_2Pic.MouseClick -= new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Torpediniere_1Pic.MouseClick -= new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Torpediniere_2Pic.MouseClick -= new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Torpediniere_3Pic.MouseClick -= new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Sottomarino_1Pic.MouseClick -= new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Sottomarino_2Pic.MouseClick -= new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Sottomarino_3Pic.MouseClick -= new MouseEventHandler(this.naveSelezionata_Click);
            this.formPartita.Sottomarino_4Pic.MouseClick -= new MouseEventHandler(this.naveSelezionata_Click);

            this.formPartita.ConsoleLabel.Text = "Partita iniziata! scegli una casella nel campo avversario\n";
            this.formPartita.ConsoleLabel.Text += "e fai fuoco cliccando con il tasto sinistro del mouse!";
            // Ciclo for per disabilitare il metodo dei bottoni del panel del giocatore 1
            // e abilitare i bottoni del campo avversario
            for (int i = 0; i < giocatore_1.MioCampo.Dimensione; i++)
            {
                for (int j = 0; j < giocatore_1.MioCampo.Dimensione; j++)
                {
                    campoG1Btn[i,j].MouseDown -= bottoneCampoDaGioco_Click;
                    campoG2Btn[i, j].MouseClick += bottoneCampoAvversario_Click;
                }
            }                        
        }         

        private void bottoneCampoAvversario_Click(object sender, MouseEventArgs e)
        {
            // dichiaro una variabile button e la rendo uguale a sender
            Button bottoneCliccato = (Button)sender;
            // faccio una conversione in Point in modo da poter utilizzare il tag
            // ovvero i valori x e y della casella cliccata
            Point posizione = (Point)bottoneCliccato.Tag;
            Casella casellaSelezionata = new Casella(posizione.X, posizione.Y);
            bool naveColpita;
            bool colpitaeAffondata;                       

            // Faccio un controllo preventivo per vedere se la casella può essere colpita
            if (giocatore_2.MioCampo.Casella[casellaSelezionata.Riga, casellaSelezionata.Colonna].StatoCasella == Stato.colpita ||
               giocatore_2.MioCampo.Casella[casellaSelezionata.Riga, casellaSelezionata.Colonna].StatoCasella == Stato.mancata)
            {
                formPartita.ConsoleLabel.Text = "Hai già fatto fuoco su questa casella. Selezionane un'altra";                
            }
            else
            {
                // la casella è libera. Posso sparare
                naveColpita = giocatore_1.FaccioFuoco(casellaSelezionata, giocatore_2.MioCampo);
                // Una volta sparato faccio un controllo nel caso la nave sia stata affondata
                if (naveColpita)
                {
                    // La nave è stata colpita, devo colorare la casella di rosso
                    campoG2Btn[casellaSelezionata.Riga, casellaSelezionata.Colonna].BackColor = Color.Red;
                    colpitaeAffondata = giocatore_2.ControllaNaveColpita(casellaSelezionata);
                    if (colpitaeAffondata)
                    {
                        formPartita.ConsoleLabel.Text = giocatore_1.Nome + ": hai ";
                        formPartita.ConsoleLabel.Text += "colpito e affondato una nave nemica";                        
                        // Se la nave è stata affondata controllo che il giocatore avversario abbia altre navi.
                        // In caso contrario sarebbe gameover
                        if (giocatore_2.GameOver())
                        {
                            // Il giocatore 2 ha perso. Faccio in modo che non si possa più cliccare
                            // sulla casella del campo avversario
                            for (int i = 0; i < 10; i++)
                            {
                                for (int j = 0; j < 10; j++)
                                {
                                    campoG2Btn[i, j].MouseClick -= bottoneCampoAvversario_Click;
                                }
                            }

                            formPartita.ConsoleLabel.Text += "\nComplimenti " + giocatore_1.Nome + " hai vinto la partita!";
                            
                            formPartita.NaviPosizionateBtn.Text = "TORNA AL MENU PRINCIPALE";
                            formPartita.NaviPosizionateBtn.Visible = true;
                            formPartita.NaviPosizionateBtn.MouseClick += tornoAlMenuPrincipale_Click;
                        }
                    }
                    else
                    {
                        // La nave è stata solamente colpita                        
                        formPartita.ConsoleLabel.Text = giocatore_1.Nome + ": hai ";                        
                        formPartita.ConsoleLabel.Text += "colpito una nave nemica";                       
                    }
                }
                else
                {
                    // non è stato colpita nessuna nave avversaria. Devo colorare
                    // la casella di blu
                    campoG2Btn[casellaSelezionata.Riga, casellaSelezionata.Colonna].BackColor = Color.Blue;
                    formPartita.ConsoleLabel.Text = giocatore_1.Nome + ": hai ";
                    formPartita.ConsoleLabel.Text += "mancato il nemico!";
                }
                // Turno del giocatore 1 finito. Inizio turno giocatore 2
                if (giocatore_2.GameOver() == false)
                {
                    // Inizio turno giocatore 2. Devo disabilitare il click
                    // sui bottoni del campo del giocatore 1
                    for (int i = 0; i < giocatore_1.MioCampo.Dimensione; i++)
                    {
                        for (int j = 0; j < giocatore_1.MioCampo.Dimensione; j++)
                        {                            
                            campoG2Btn[i, j].MouseClick -= bottoneCampoAvversario_Click;
                        }
                    }
                    // Se il giocatore 2 non ha ancora perso, può eseguire il suo turno
                    // verrà utilizzato un timer per far in modo che l'utente possa riuscire
                    // a leggere il risultato del suo sparo nella consoleLabel
                    timer = new System.Windows.Forms.Timer();
                    timer.Tick += new EventHandler(turnoIA);
                    timer.Interval = 1500; // setto un intervallo di 1 secondo
                    timer.Start();                    
                }
            }            
        }

        private void turnoIA(object source, EventArgs e)
        {
            bool naveColpita;
            bool colpitaeAffondata;
            Casella bersaglio = new Casella();

            timer.Stop();            
            
            // Racchiudo il generatore di cordinate casuali in un ciclo do-while in modo da essere
            // sicuro che le cordinate generate possano essere accettate.            
            do
            {
                // Genero un seme sempre diverso
                Random rand = new Random((int)DateTime.Now.Millisecond);
                // Genero 2: uno per la riga, uno per la colonna
                bersaglio.Riga = rand.Next(0, 10);
                bersaglio.Colonna = rand.Next(0, 10);                
            } while (giocatore_1.MioCampo.Casella[bersaglio.Riga, bersaglio.Colonna].StatoCasella == Stato.colpita ||
                     giocatore_1.MioCampo.Casella[bersaglio.Riga, bersaglio.Colonna].StatoCasella == Stato.mancata);

            // Una volta generate le cordinate corrette faccio fuoco sul campo avversario
            naveColpita = giocatore_2.FaccioFuoco(bersaglio, giocatore_1.MioCampo);

            // Una volta sparato faccio un controllo nel caso la nave sia stata affondata
            if (naveColpita)
            {
                // La nave è stata colpita, devo colorare la casella di rosso
                campoG1Btn[bersaglio.Riga, bersaglio.Colonna].BackColor = Color.Red;
                colpitaeAffondata = giocatore_1.ControllaNaveColpita(bersaglio);
                if (colpitaeAffondata)
                {
                    formPartita.ConsoleLabel.Text = giocatore_2.Nome + ": hai ";
                    formPartita.ConsoleLabel.Text += "colpito e affondato una nave nemica!";
                    if (giocatore_1.GameOver())
                    {
                        // Il giocatore 1 ha perso. Faccio in modo che non si possa più cliccare
                        // sulla casella del campo avversario
                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                campoG2Btn[i, j].MouseClick -= bottoneCampoAvversario_Click;
                            }
                        }

                        formPartita.ConsoleLabel.Text += "\nComplimenti " + giocatore_2.Nome + " hai vinto la partita!";

                        formPartita.NaviPosizionateBtn.Text = "TORNA AL MENU PRINCIPALE";
                        formPartita.NaviPosizionateBtn.Visible = true;
                        formPartita.NaviPosizionateBtn.MouseClick += tornoAlMenuPrincipale_Click;
                    }
                }
                else
                {
                    formPartita.ConsoleLabel.Text = giocatore_2.Nome + ": hai ";
                    formPartita.ConsoleLabel.Text += "colpito una nave nemica!";                    
                }
            }
            else
            {
                campoG1Btn[bersaglio.Riga, bersaglio.Colonna].BackColor = Color.Blue;
                formPartita.ConsoleLabel.Text = giocatore_2.Nome + ": hai ";
                formPartita.ConsoleLabel.Text += "mancato il nemico!";
            }

            if (!giocatore_1.GameOver())
            {
                // Turno del giocatore 2 finito. Devo riabilitare il click
                // sul campo avversario
                for (int i = 0; i < giocatore_1.MioCampo.Dimensione; i++)
                {
                    for (int j = 0; j < giocatore_1.MioCampo.Dimensione; j++)
                    {
                        campoG2Btn[i, j].MouseClick += bottoneCampoAvversario_Click;
                    }
                }
            }            
        }

        // Metodo che chiude il form della partita per ritornare al menu principale
        private void tornoAlMenuPrincipale_Click(object sender, MouseEventArgs e)
        {
            // Il metodo dovrà chiudere il form partita e dovrà al menu principale
            ControllerMenuPrincipale menuprincipale = ControllerMenuPrincipale.getIstanza();
                        
            // chiudo il form
            formPartita.Close();
            // mostro il menu principale
            menuprincipale.MenuPrincipale.Show();
        }

        // Metodo per gestire quale nave ha selezionato l'utente
        private void naveSelezionata_Click(object sender, MouseEventArgs e)
        {
            picSelezionata = sender as PictureBox;
            picSelezionata.BackColor = Color.White;
            // Serie di if-else per capire quale nave ha selezionato il giocatore
            if (sender.Equals(this.formPartita.Portaerei_Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[0];
                
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
                formPartita.ConsoleLabel.Text += ". \nPosizionati nella casella desiderata e tramite click destro decidi la direzione.";
            }
            else if (sender.Equals(this.formPartita.Incrociatore_1Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[1];
                
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
                formPartita.ConsoleLabel.Text += ". \nPosizionati nella casella desiderata e tramite click destro decidi la direzione.";
            }
            else if (sender.Equals(this.formPartita.Incrociatore_2Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[2];
                
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
                formPartita.ConsoleLabel.Text += ". \nPosizionati nella casella desiderata e tramite click destro decidi la direzione.";
            }
            else if (sender.Equals(this.formPartita.Torpediniere_1Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[3];
                
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
                formPartita.ConsoleLabel.Text += ". \nPosizionati nella casella desiderata e tramite click destro decidi la direzione.";
            }
            else if (sender.Equals(this.formPartita.Torpediniere_2Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[4];
                
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
                formPartita.ConsoleLabel.Text += ". \nPosizionati nella casella desiderata e tramite click destro decidi la direzione.";
            }
            else if (sender.Equals(this.formPartita.Torpediniere_3Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[5];
                
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
                formPartita.ConsoleLabel.Text += ". \nPosizionati nella casella desiderata e tramite click destro decidi la direzione.";
            }
            else if (sender.Equals(this.formPartita.Sottomarino_1Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[6];
                
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
                formPartita.ConsoleLabel.Text += ". \nPosizionati nella casella desiderata e tramite click destro decidi la direzione.";
            }
            else if (sender.Equals(this.formPartita.Sottomarino_2Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[7];
                
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
                formPartita.ConsoleLabel.Text += ". \nPosizionati nella casella desiderata e tramite click destro decidi la direzione.";
            }
            else if (sender.Equals(this.formPartita.Sottomarino_3Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[8];
                
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
                formPartita.ConsoleLabel.Text += ". \nPosizionati nella casella desiderata e tramite click destro decidi la direzione.";
            }
            else if (sender.Equals(this.formPartita.Sottomarino_4Pic))
            {
                naveSelezionata = giocatore_1.ListaNavi[9];
                
                formPartita.ConsoleLabel.Text = "Nave Selezionata: " + naveSelezionata.Nome;
                formPartita.ConsoleLabel.Text += ". \nPosizionati nella casella desiderata e tramite click destro decidi la direzione.";
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
