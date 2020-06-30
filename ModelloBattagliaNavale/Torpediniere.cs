namespace ModelloBattagliaNavale
{
    public class Torpediniere : Nave
    {
        public Torpediniere(string nome)
        {
            this.Nome = nome;
            this.SimboloNave = 'T';
            this.Lunghezza = 2;
            this.Posizione = new Casella[2];
        }   
    }
}
