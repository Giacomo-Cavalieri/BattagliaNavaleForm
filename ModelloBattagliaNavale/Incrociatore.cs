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
