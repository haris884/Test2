using System;
using System.Collections.Generic;
using MitarbeiterVerwaltungSystem;

namespace MitarbeiterVerwaltungSystem
{
    class Program
    {
        static void Main()
        {
            MitarbeiterVerwaltung verwaltung = new MitarbeiterVerwaltung();

            verwaltung.MitarbeiterHinzufuegen(new Mitarbeiter("Arthur", "OG", "Aktiv", 500000000, 28));
            verwaltung.MitarbeiterHinzufuegen(new Mitarbeiter("Haris", "Lil G", "Aktiv", 60000, 22));
            verwaltung.MitarbeiterHinzufuegen(new Mitarbeiter("niemals G", "Hühnemeier", "Inaktiv", 31, 60));
            verwaltung.MitarbeiterHinzufuegen(new Mitarbeiter("Sebi G", "Sigma", "Aktiv", 70000, 22));

            List<Mitarbeiter> alleMitarbeiter = verwaltung.AlleMitarbeiter();
            foreach (var mitarbeiter in alleMitarbeiter)
            {
                Console.WriteLine($"{mitarbeiter.Vorname} {mitarbeiter.Nachname} - {mitarbeiter.StatusImBetrieb} - {mitarbeiter.Gehalt} - {mitarbeiter.AnzahlJahreImBetrieb} Jahre");
            }

            string suchVorname = "Haris";
            string suchNachname = "G";
            Mitarbeiter gefundenerMitarbeiter = verwaltung.SucheMitarbeiter(suchVorname, suchNachname);
            if (gefundenerMitarbeiter != null)
            {
                Console.WriteLine($"Gefunden: {gefundenerMitarbeiter.Vorname} {gefundenerMitarbeiter.Nachname}");
            }
            else
            {
                Console.WriteLine("Mitarbeiter nicht gefunden.");
            }

            verwaltung.SchreibeDatenInDatei("mitarbeiterdaten.txt");
        }
    }
}