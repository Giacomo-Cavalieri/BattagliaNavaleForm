Autori:
Pavel Bucsanu [Matricola 271426];
Giacomo Cavalieri [Matricola 272094];

Titolo Progetto: "Battaglia Navale"

Specifica:
Si vuole realizzare un software che riproduca una partita del gioco “Battaglia Navale”
scrivendo un’applicazione con interfaccia utente Windows Forms.
In particolare, si vuole sviluppare una versione del gioco in cui è possibile sfidare
unicamente un avversario “non-umano”, ovvero l’avversario del giocatore sarà il computer stesso.
Le regole del gioco sono quelle della versione classica a carta e penna:

Ogni giocatore dispone di 10 navi così suddivise:
1 nave di classe Portaerei;
2 navi di classe Incrociatori;
3 navi di classe Torpedinieri;
4 navi di classe Sottomarini;

Nella fase iniziale del gioco, ogni giocatore dovrà disporre segretamente
le proprie navi nella griglia a lui associata. Ogni nave occuperà un numero diverso di caselle,
più precisamente:
La Portaerei occupa 4 caselle;
Gli Incrociatori occupano 3 caselle;
I Torpedinieri occupano 2 caselle;
I Sottomarini occupano 1 casella;

Ogni turno, il giocatore dovrà decidere in quale punto della griglia avversaria dovrà sparare
sperando di colpire una delle navi nemiche e, in caso, affondarla;

Quando una nave viene colpita in tutte le sue parti (ovvero tutte le caselle occupate) verrà affondata.

Il gioco continua fino a quando uno dei due giocatori non avrà affondato tutte le navi avversarie
e quindi vinto la partita.

A queste regole vengono aggiunte però delle modifiche:

Il giocatore non-umano, diversamente dal suo avversario disporrà le proprie navi
in maniera pseudo-casuale;
Il giocatore non-umano, diversamente dal suo avversario, deciderà le coordinate per lo sparo
in maniera pseudo-casuale;

Ogni mossa dei 2 giocatori, verrà accompagnata da una scritta a schermo che indicherà
l’esito dell’attacco:
“Colpito!” nel caso si sia colpita una parte della nave avversaria;
“Colpito e Affondato!” nel caso si sia affondata una nave avversaria;
“Mancato!” nel caso non si sia colpito nulla;