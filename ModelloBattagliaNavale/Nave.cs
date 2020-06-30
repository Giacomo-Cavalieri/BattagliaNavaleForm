namespace ModelloBattagliaNavale
{
    public abstract class Nave
    {
        public string Nome { get; set; }
        public bool Inserita { get; set; }

        public bool Affondata { get; set; }
        public char SimboloNave { get; set; }

        public int Lunghezza { get; set; }

        // property per la posizione
        public Casella[] Posizione { get; set; }


        // costruttore
        public Nave()
        {            
            Inserita = false;
            Affondata = false;
        }

        // Metodo ToString di debug
        public override string ToString()
        {
            return "Nome della nave : " + this.Nome +
                   "\nLunghezza della nave: " + this.Lunghezza +
                   "\nSimbolo della nave: " + this.SimboloNave +
                   "\nNave inserita (true/false): " + this.Inserita;
        }


        //Metodo per il controllo e il successivo inserimento della nave in griglia di gioco
        public void InserimentoNave(Casella cordinata, CampoDaGioco campo, bool direzione)
        {
            bool casellaLibera = true;
            
            if (direzione) // Se direzione = true la nave sarà disposta orizzontalmente
            {
                for (int i = 0; i < this.Lunghezza; i++) // ciclo per controllare tutte le caselle necessarie alla nave per inserirsi
                {
                    if (casellaLibera == true)
                    {
                        // Controllo che i valori siano validi e non eccedano la dimensione della matrice
                        if ((cordinata.Riga) > 9 ||
                            (cordinata.Colonna + i) > 9)
                        {                            
                            casellaLibera = false;
                        }
                        // Faccio un ulteriore controllo che la casella non risulti occupata
                        else if (campo.Casella[cordinata.Riga, cordinata.Colonna + i].StatoCasella != Stato.libera)   
                        {                            
                            casellaLibera = false;
                        }                        
                    }                    
                }
                if (casellaLibera) // tutte le caselle sono libere
                {
                    // Vado a inserire la nave  
                    for (int i = 0; i < this.Lunghezza; i++)
                    {
                        // Disegno nella griglia il simbolo della nave
                        campo.Casella[cordinata.Riga, cordinata.Colonna + i].SimboloCasella = this.SimboloNave;
                        // Setto la casella come occupata
                        campo.Casella[cordinata.Riga, cordinata.Colonna + i].StatoCasella = Stato.occupata;
                        // Salvo nella nave la posizione nella griglia
                        this.Posizione[i] = new Casella(cordinata.Riga, cordinata.Colonna + i);
                        // Setto la variabile Inserita come true
                        this.Inserita = true;
                    }
                }
            }
            else // direzione = false. La nave deve essere disposta in modo verticale
            {
                for (int i = 0; i < this.Lunghezza; i++) // ciclo per conttrollare tutte le caselle necessarie alla nave per inserirsi
                {
                    if (casellaLibera)
                    {
                        // Controllo che i valori siano validi e non eccedano la dimensione della matrice
                        if ((cordinata.Riga + i) > 9 ||
                            (cordinata.Colonna) > 9)
                        {                            
                            casellaLibera = false;
                        }
                        // Faccio un ulteriore controllo che la casella non risulti occupata
                        else if (campo.Casella[cordinata.Riga + i, cordinata.Colonna].StatoCasella != Stato.libera)
                        {                            
                            casellaLibera = false;
                        }
                        
                    }
                }
                if (casellaLibera) // tutte le caselle sono libere vado a inserire la nave
                {
                    for (int i = 0; i < this.Lunghezza; i++)
                    {
                        // Disegno nella griglia il simbolo della nave
                        campo.Casella[cordinata.Riga + i, cordinata.Colonna].SimboloCasella = this.SimboloNave;
                        // Setto la casella come occupata
                        campo.Casella[cordinata.Riga + i, cordinata.Colonna].StatoCasella = Stato.occupata;
                        // Salvo nella nave la posizione nella griglia
                        this.Posizione[i] = new Casella(cordinata.Riga + i, cordinata.Colonna);
                        // Setto la variabile Inserita come true
                        this.Inserita = true;
                    }
                }
            }
        }

        // Metodo per controllare se la nave sia stata affondata
        public bool ControlloDanni(Casella parteNaveColpita)
        {
            // dichiaro le variabili utili alla funzione
            bool colpitoeAffondato = true;            

            // ciclo for per settare la casella come colpita
            for (int i = 0; i < this.Lunghezza; i++)
            {
                // vado a individuare il punto della nave che è stata colpito
                if (this.Posizione[i].Riga == parteNaveColpita.Riga &&
                    this.Posizione[i].Colonna == parteNaveColpita.Colonna)
                {
                    // casella trovata, vado a settare lo stato come colpita
                    this.Posizione[i].StatoCasella = Stato.colpita;                    
                }
            }

            // ciclo for per controllare se la nave sia affondata
            for (int i = 0; i < this.Lunghezza; i++)
            {
                if(this.Posizione[i].StatoCasella != Stato.colpita)
                {
                    colpitoeAffondato = false;
                }                
            }
            return colpitoeAffondato;
        }
    }
}
