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
