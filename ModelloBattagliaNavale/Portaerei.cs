namespace ModelloBattagliaNavale
{
    public class Portaerei : Nave
    {
        public Portaerei(string nome)
        {
            this.Nome = nome;
            this.SimboloNave = 'P';
            this.Lunghezza = 4;
            this.Posizione = new Casella[4];
        }


        
    }
}
