using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelloBattagliaNavale
{
    public class Sottomarino : Nave
    {
        public Sottomarino(string nome)
        {
            this.Nome = nome;
            this.SimboloNave = 'S';
            this.Lunghezza = 1;
            this.Posizione = new Casella[1];
        }
    }
}
