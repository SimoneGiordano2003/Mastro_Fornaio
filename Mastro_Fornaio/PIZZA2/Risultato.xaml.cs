using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Mastro_Fornaio
{
    /// <summary>
    /// Pagina per la visualizzazione di Ingredienti e Ricette
    /// </summary>
    public sealed partial class Risultato : Page
    {
        /// <summary>
        /// Tipo di ricetta
        /// </summary>
        public enum Impasto
        {
            Napoletana,
            Romana,
            Pane,
        }

        private double _pesoLievito { get; set; }

        /// <summary>
        /// Imposta i valori precedentemente calcolati ai <TextBlock> presenti nel file "/Risultato.xaml"
        /// </summary>
        /// <param name="olio">Valore olio</param>
        /// <param name="sale">Valore sale</param>
        /// <param name="acqua">Valore acqua</param>
        /// <param name="farina">Valore farina</param>
        /// <param name="lievito">Valore lievito</param>
        /// <param name="impasto">Valore impasto</param>
        public Risultato(double olio , double sale , int acqua , int farina , double lievito , Impasto impasto)
        {
            this.InitializeComponent();

            _pesoLievito      = lievito > 0 ? lievito : 0;

            Peso_Acqua.Text   = $"Acqua: {acqua}g";
            Peso_Farina.Text  = $"Farina: {farina}g";
            Peso_Olio.Text    = $"Olio: {Arrotonda( olio , 1 )}g";
            Peso_Sale.Text    = $"Sale: {Arrotonda( sale , 1 )}g";
            Peso_Lievito.Text = $"Lievito: {Arrotonda( _pesoLievito , 2 )}g";

            Ricetta( impasto );
        }

        #region Ingredienti

        private void Fresco_Click(object sender , RoutedEventArgs e)
        {
            Peso_Lievito.Text = $"Lievito: {Arrotonda( _pesoLievito * 2.6 , 2 )}g";
        }

        private void Secco_Click(object sender , RoutedEventArgs e)
        {
            Peso_Lievito.Text = $"Lievito: {Arrotonda( _pesoLievito , 2 )}g";
        }

        /// <summary>
        /// Arrotonda il <System.Double> inserito
        /// </summary>
        /// <param name="n">Numero da arrotondare</param>
        /// <param name="decimali">Cifre dopo la virgola</param>
        /// <returns>Numero arrotondato</returns>
        private double Arrotonda(double n , int decimali)
        {
            int potenza = 1;

            for (int i = 0 ; i < decimali ; i++)
            {
                potenza *= 10;
            }

            return Convert.ToDouble( Convert.ToInt32( (n * potenza) ) ) / potenza;
        }

        #endregion Ingredienti

        #region Ricettaaaa

        /// <summary>
        /// Stampa la ricetta a schermo
        /// </summary>
        /// <param name="_impasto">Tipo di impasto</param>
        private void Ricetta(Impasto _impasto)
        {
            //Array contenenti la ricetta
            string[] Napoletana = new string[8], Romana = new string[7], Pane = new string[9];

            //Lista contenente i <TextBlock>
            TextBlock[] Ricetta_Block = {_0, _1, _2, _3, _4, _5, _6, _7, _8};

            //Metodo creato per non "sporcare" il codice
            ImpostaRicetta( ref Napoletana , ref Romana , ref Pane );

            //Array contenente la ricetta da stampare
            string[] _array = _impasto == Impasto.Pane ? Pane : _impasto == Impasto.Napoletana ? Napoletana : Romana;

            for (int i = 0 ; i < _array.Length ; i++)
            {
                Ricetta_Block[i].Text = _array[i];
            }
        }

        /// <summary>
        /// Aggiunge il testo agli array contenenti la ricetta
        /// </summary>
        /// <param name="Napoletana">Ricetta per Pizza Napoletana</param>
        /// <param name="Romana">Ricetta per Pizza Romana</param>
        /// <param name="Pane">Ricetta per Pane</param>
        private void ImpostaRicetta(ref string[] Napoletana , ref string[] Romana , ref string[] Pane)
        {
            Napoletana[0] = "Per preparare la pasta per la pizza iniziate versando la farina nella ciotola della planetaria. Aggiungete il lievito e 100 grammi d’acqua, quindi azionate la planetaria con il gancio montato a velocità medio bassa.";
            Romana[0]     = Napoletana[0];
            Pane[0]       = "Per preparare la pasta per il pane come prima cosa iniziate a sciogliere il lievito di birra fresco nell'acqua a temperatura ambiente. Poi versate in una ciotola capiente sia la farina 00 che la manitoba e aggiungete 1 cucchiaino di malto.";

            Napoletana[1] = "Procedete aggiungendo l’acqua poco per volta, avendo cura di aspettare che la dose precedente sia stata ben assorbita dalla farina. Una volta versati circa i 3/4 dell'acqua aggiungete il sale e continuate ad impastare. Aggiungete il resto dell’acqua sempre a filo e lasciate lavorare fino ad ottenere un composto liscio ed omogeneo.";
            Romana[1]     = Napoletana[1];
            Pane[1]       = "A questo punto iniziate a mescolare con una mano e con l'altra versate l'acqua poco per volta, unitene circa la metà e quando sarà completamente assorbita aggiungete anche il sale. Impastate nuovamente ";

            Napoletana[2] = "A questo punto aggiungete l’olio gradatamente (come avete fatto con l’acqua). Quando l’olio è stato completamente assorbito, estraete l’impasto dalla planetaria e modellatelo con le mani fino ad ottenere una palla. Inseritelo in una ciotola capiente leggermente unta.";
            Romana[2]     = Napoletana[2];
            Pane[2]       = "Aggiungete il resto dell'acqua sempre poco per volta, sempre continuando ad impastare. Una volta che avrete aggiunto anche l'ultima parte di acqua continuate ad impastare all'interno della ciotola per una decina di minuti, fino a che l'impasto non sarà ben incordato. Se preferite potete realizzare questi passaggi utilizzando un'impastatrice dotata di gancio, partendo da una velocità moderata e aumentandola leggermente all'ultimo. A questo punto lasciate riposare l'impasto per una decina di minuti, non servirà coprirlo";

            Napoletana[3] = "Coprite con pellicola o con un canovaccio pulito e mettete a lievitare nel forno con la luce accesa. Attendete che l’impasto abbia almeno raddoppiato il suo volume (1,5 h), meglio triplicato (2,5/3 h) e procedete alla stesura delle pizze. Una volta che l’impasto avrà lievitato, trasferitelo sulla spianatoia e dividetelo in 4 parti uguali ";
            Romana[3]     = "Coprite con pellicola o con un canovaccio pulito e mettete a lievitare nel forno spento con la luce accesa. Attendete che l’impasto abbia almeno raddoppiato il suo volume (1,5 h), meglio triplicato (2,5/3 h). Una volta che l’impasto avrà lievitato, trasferitelo sulla spianatoia e dividetelo in 4 parti uguali";
            Pane[3]       = "Quando l'impasto sarà ben rilassato trasferitelo su un piano leggermente infarinato aiutandovi con un tarocco e date le classiche pieghe. Allargate l'impasto con le mani, quindi ripiegate due dei 4 lembi esterni verso il centro. ";

            Napoletana[4] = "Fate con ognuno delle palline. Coprite con un canovaccio pulito e lasciate riposare per 30 minuti. Ungete leggermente con un filo d’olio 4 teglie da pizza di 30 cm di diametro. Posizionate al centro della teglia una pallina di impasto";
            Romana[4]     = "Fate con ognuno delle palline. Copritele con un canovaccio pulito e lasciate riposare per 30 minuti. Ungete leggermente con un filo d’olio 4 teglie da pizza di 30 cm di diametro. Posizionate al centro della teglia una pallina di impasto";
            Pane[4]       = "Ripiegate anche gli altri due lembi di pasta verso il centro e capovolgete il pane. Passate quindi alla pirlatura, roteandolo con le mani sul piano in modo da dargli una forma rotonda";

            Napoletana[5] = "Cominciate a schiacciare dal centro verso l’esterno, tirando i leggermente i lati se necessario. Se la pasta risulta troppo elastica e tende a tornare alla forma che aveva prima, mettete da parte la pizza che state stendendo e procedete a stenderne un’altra, facendo così riposare la precedente. Cercate di distendere la pasta su tutta la superficie della teglia. A parte, in una ciotola capiente, versate la salsa di pomodoro e conditela con sale, olio, pepe e origano ";
            Romana[5]     = "Cominciate a schiacciare dal centro verso l’esterno, tirando i leggermente i lati se necessario. Se la pasta risulta troppo elastica e tende a tornare alla forma che aveva prima, mettete da parte la pizza che state stendendo e procedete a stenderne un’altra, facendo così riposare la precedente. Cercate di distendere la pasta su tutta la superficie della teglia. Versate un mestolo abbondante di salsa al pomodoro, precentemente condita con sale e origano, sulla base della teglia e spargetela con un movimento circolare, ricoprendo quasi tutta l’area, lasciando solo un bordo di circa 1,5 cm ";
            Pane[5]       = "Trasferitelo poi in una ciotola leggermente infarinata, coprite con la pellicola per alimenti e lasciate lievitare per circa 2 ore o comunque fino a che non sarà raddoppiato. Se la temperatura è piuttosto alta basterà lasciarlo in cucina, lontano da correnti d'aria; d'inverno invece è consigliabile lasciar lievitare l'impasto in forno spento solo con la luce accesa. ";

            Napoletana[6] = "Versate un mestolo abbondante di salsa al pomodoro sulla base della pizza e spargetela con un movimento circolare, ricoprendo quasi tutta l’area, lasciando solo un bordo di circa 1,5 cm. Tagliate i frutti di cappero a metà e teneteli da parte.";
            Romana[6]     = "Tritate grossolanamente la mozzarella. Condite ora la pizza con i filetti di alici, un filo d'olio e la mozzarella tagliata a pezzetti. Lasciate riposare la pizza farcita per una decina di minuti, poi infornate a 250°C per 12/15 minuti in forno statico (altrimenti se utilizzate il forno ventilato basteranno una decina di minuti a 230°). Non appena estraete la pizza romana dal forno, servitela immediatamente ";
            Pane[6]       = "A questo punto trasferite l'impasto su un piano leggermente infarinato e ripetete le stesse operazioni di prima. Date delle pieghe, poi capovolgetelo e pirlatelo ";

            Napoletana[7] = "Condite ora con le alici, i frutti di cappero tagliati a metà e un filo d’olio. Lasciate riposare la pizza farcita per una decina di minuti, poi infornate a 210°C per 15/20 minuti in forno statico (190° invece se utilizzate il forno ventilato per circa 15 minuti). Non appena estraete la pizza alla napoletana dal forno, servitela immediatamente";
            Pane[7]       = "Non appena avrete ottenuto una forma rotonda trasferitelo su una leccarda da forno precedentemente infarinata, coprite con un panno umido e lasciate lievitare per ancora un'ora. Quando sarà ben lievitato, scaldate il forno statico a 250°";

            Pane[8]       = "Utilizzando un taglierino realizzate delle incisioni decorative (25-26). A questo punto diminuite la temperatura del forno a 230° e inserite una ciotolina colma d'acqua sul fondo, servirà a favorire la giusta umidità. Infornate il pane nel ripiano centrale e cuocete per 20 minuti, poi abbassate la temperatura a 180°, estraete la ciotolina d'acqua e proseguite la cottura per altri 35 minuti, simulando la valvola aperta, ovvero aprendo leggermente lo sportello del forno e incastrandovi una presina in modo da bloccarlo e lasciarlo socchiuso; in questo modo il pane risulterà più asciutto. Una volta sfornato, lasciatelo intiepidire prima di affettarlo! ";
        }

        #endregion Ricettaaaa
    }
}