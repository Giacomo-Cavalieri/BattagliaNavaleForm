using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelloBattagliaNavale
{
    public class Incrociatore : Nave
    {

        public Incrociatore(string nome)
        {
            this.Nome = nome;
            this.SimboloNave = 'I';
            this.Lunghezza = 3;
            this.Posizione = new Casella[3];
        }

        
    }
}
