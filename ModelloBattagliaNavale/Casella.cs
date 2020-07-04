using System;

namespace ModelloBattagliaNavale
{
    public enum Stato { colpita, mancata, libera, occupata }
    // Classe che andrà a costituire il campo del giocatore (la griglia sarà una matrice di Casella)
    public class Casella
    {
        // attrubbuti per l'individuazione delle coordinate all'interno della matrice
        private int riga;
        private int colonna;

        // Dichiarazione delle property
        // Property per lo stato della casella
        public Stato StatoCasella { get; set; }

        // Property per il simbolo di ogni casella
        public char SimboloCasella { get; set; }

        // Property per la coordinata riga
        public int Riga
        {
            get { return this.riga; }
            set
            {
                if(value >= 0 && value < 10)
                {
                    riga = value;
                }
                else
                {
                    throw new Exception("Il valore di riga deve essere compreso tra 0 e 9!!!");
                }
            }
        }

        // Property per la coordinata colonna
        public int Colonna
        {
            get { return this.colonna; }
            set
            {
                if (value >= 0 && value < 10)
                {
                    colonna = value;
                }
                else
                {
                    throw new Exception("Il valore di colonna deve essere compreso tra 0 e 9!!!");
                }
            }
        }

        // Costruttore vuoto
        public Casella()
        {
            StatoCasella = Stato.libera;
        }


        // Costruttore
        public Casella(int x, int y)
        {
            Riga = x;
            Colonna = y;
            StatoCasella = Stato.libera;
        }
    }
}
