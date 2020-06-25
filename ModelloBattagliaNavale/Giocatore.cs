using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ModelloBattagliaNavale
{
    public class Giocatore
    {
        public int Punteggio { get; set; }
        // Nome del giocatore
        public string Nome { get; set; }

        //lista di navi 
        public List<Nave> ListaNavi { get; set; }
       

        // Campo da gioco del giocatore
        public CampoDaGioco MioCampo { get; set; }

        // Costruttore della classe
        public Giocatore(string nome)
        {
            this.Nome = nome;

            // inizializzato le navi, non ha molta differenza dagli array 
            this.ListaNavi = new List<Nave>(10)
            {
                new Portaerei("Portaerei"),
                new Incrociatore("Incrociatore_1"),
                new Incrociatore("Incrociatore_2"),
                new Torpediniere("Torpediniere_1"),
                new Torpediniere("Torpediniere_2"),
                new Torpediniere("Torpediniere_3"),
                new Sottomarino("Sottomarino_1"),
                new Sottomarino("Sottomarino_2"),
                new Sottomarino("Sottomarino_3"),
                new Sottomarino("Sottomarino_4")
            };

            this.MioCampo = new CampoDaGioco(10);
            
                        
        }
       
        // Metodo per sparare nel campo dell'avversario
        public bool FaccioFuoco(Casella bersaglio, CampoDaGioco campoNemico)
        {
            bool colpito = false;

            // stati della casella: libera, occupata, mancata, colpita

            // Controllo che nella casella bersaglio sia presente una nave
            if(campoNemico.Casella[bersaglio.Riga, bersaglio.Colonna].StatoCasella == Stato.occupata)
            {
                colpito = true;
                // cambio lo stato della casella in modo che non possa essere più colpita
                campoNemico.Casella[bersaglio.Riga, bersaglio.Colonna].StatoCasella = Stato.colpita;
                campoNemico.Casella[bersaglio.Riga, bersaglio.Colonna].SimboloCasella = 'O';
            }
            else
            {
                // anche se non è stata colpita nessuna nave devo cambiare lo stato della casella
                campoNemico.Casella[bersaglio.Riga, bersaglio.Colonna].StatoCasella = Stato.mancata;
                campoNemico.Casella[bersaglio.Riga, bersaglio.Colonna].SimboloCasella = 'X';
            }

            return colpito;
        }



        // Metodo per collocare le navi in maniera casuale per l'IA
        public void CollocaNaviIA()
        {
            /* Questo metodo deve generare delle cordinate casuali e, se le cordinate
             * risulteranno valide, inserire la nave selezionata grazie ad un foreach
             * nel proprio campo da gioco.
             */
            Casella casellaEstratta = new Casella();
            int scelta;
            bool direzione;
            // qui ho cambiano la variabe da Nave a ListaNave visto che ha un nuovo nome e la stessa cosa l'ho fatto dalle altre parti
            foreach (var naveAttuale in this.ListaNavi)
            {
                do
                {
                    // Genero un seme sempre diverso
                    Random rand = new Random((int)DateTime.Now.Millisecond);
                    // genero 2 numeri: uno per la riga, l'altro per la colonna
                    casellaEstratta.Riga = rand.Next(0, 10);
                    casellaEstratta.Colonna = rand.Next(0, 10);
                    scelta = (rand.Next(1, 101)); // se il numero è pari direzione sarà uguale a orizzontale
                    if ((scelta % 2) == 0)
                    {
                        direzione = true;
                    }
                    else
                    {
                        direzione = false;
                    }
                    naveAttuale.InserimentoNave(casellaEstratta, this.MioCampo, direzione);
                } while (naveAttuale.Inserita != true);
            }
            
        }

        // Metodo per controllare quale nave sia stata colpita
        public bool ControllaNaveColpita(Casella casellaBersagliata)
        {
            bool naveAffondata = true;
            // Ciclo foreach per trovare quale nave del giocatore è stata colpita            
            foreach (Nave naveAttuale in this.ListaNavi.ToList())
            {
                if (naveAffondata)
                {
                    // ciclo for per controllare se la naveAttuale sia la nave bersagliata
                    for (int i = 0; i < naveAttuale.Lunghezza; i++)
                    {
                        // faccio un controllo tramite la casellaBersagliata e la casella attuale della nave
                        if (naveAttuale.Posizione[i].Riga == casellaBersagliata.Riga &&
                            naveAttuale.Posizione[i].Colonna == casellaBersagliata.Colonna)
                        {
                            // nave trovata! invoco il metodo per controllare lo stato della nave
                            naveAffondata = naveAttuale.ControlloDanni(casellaBersagliata);
                            // se naveAffondata è uguale a true setto la variabile booleana Affondata della nave a true
                            if (naveAffondata)
                            {
                                naveAttuale.Affondata = true;
                                ListaNavi.Remove(naveAttuale);
                                Console.WriteLine(naveAttuale.Nome + ": Nave affondata!");
                            }
                        }
                    }
                }                
            }
            return naveAffondata;
        }


        // metodo per controllare se il giocatore ha fatto gameover
        public bool GameOver()
        {
            // Variabili utili alla funzione
            bool gameOver = false;

            // Ciclo foreach che va a controllare la variabile Affondata di tutte le navi possedute dal giocatore
            
            if(ListaNavi.Count == 0)
            {
                gameOver = true;
            }
            return gameOver;
        }
    }
}
