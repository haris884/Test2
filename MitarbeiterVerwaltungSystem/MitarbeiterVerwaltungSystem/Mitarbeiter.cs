namespace MitarbeiterVerwaltungSystem
{
    public class Mitarbeiter
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string StatusImBetrieb { get; set; }
        public double Gehalt { get; set; }
        public int AnzahlJahreImBetrieb { get; set; }

        public Mitarbeiter(string vorname, string nachname, string statusImBetrieb, double gehalt, int anzahlJahreImBetrieb)
        {
            Vorname = vorname;
            Nachname = nachname;
            StatusImBetrieb = statusImBetrieb;
            Gehalt = gehalt;
            AnzahlJahreImBetrieb = anzahlJahreImBetrieb;
        }
    }
}