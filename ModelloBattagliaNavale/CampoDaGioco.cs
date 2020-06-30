namespace ModelloBattagliaNavale
{
    public class CampoDaGioco
    {
        // Attributi della classe

        // dimensione della griglia
        public int Dimensione { get; set; }
        // Caselle della griglia
        public Casella[,] Casella { get; set; }



        // Costruttore
        public CampoDaGioco(int dim)
        {
            Dimensione = dim;

            // inizializzo la dimensione del campo a dim
            Casella = new Casella[Dimensione,Dimensione];


            for (int i = 0; i < Dimensione; i++)
            {
                for (int j = 0; j < Dimensione; j++)
                {
                    this.Casella[i, j] = new Casella(i, j);
                    this.Casella[i, j].SimboloCasella = ' ';
                }
            }
        }
    }
}
