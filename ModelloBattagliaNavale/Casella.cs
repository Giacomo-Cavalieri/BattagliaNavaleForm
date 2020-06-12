using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelloBattagliaNavale
{
    public enum Stato { colpita, mancata, libera, occupata }
    // Classe che andrà a costituire il campo del giocatore (la griglia sarà una matrice di Casella)
    public class Casella
    {
        // Dichiarazione delle property

        // Property per l'individuazione delle coordinate all'interno della matrice
        private int riga;
        private int colonna;

        // Property per lo stato della casella
        public Stato StatoCasella { get; set; }


        public char SimboloNave { get; set; }

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
