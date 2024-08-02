using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MitarbeiterVerwaltungSystem
{
    public class MitarbeiterVerwaltung
    {
        private List<Mitarbeiter> mitarbeiterListe = new List<Mitarbeiter>();

        public void MitarbeiterHinzufuegen(Mitarbeiter mitarbeiter)
        {
            mitarbeiterListe.Add(mitarbeiter);
        }

        public List<Mitarbeiter> AlleMitarbeiter()
        {
            return mitarbeiterListe;
        }

        public Mitarbeiter SucheMitarbeiter(string vorname, string nachname)
        {
            return mitarbeiterListe.FirstOrDefault(m => m.Vorname == vorname && m.Nachname == nachname);
        }

        public double MaxGehalt()
        {
            return mitarbeiterListe.Max(m => m.Gehalt);
        }

        public double MinGehalt()
        {
            return mitarbeiterListe.Min(m => m.Gehalt);
        }

        public double SummeGehalt()
        {
            return mitarbeiterListe.Sum(m => m.Gehalt);
        }

        public double DurchschnittGehalt()
        {
            return mitarbeiterListe.Average(m => m.Gehalt);
        }

        public double StandardabweichungGehalt()
        {
            double durchschnitt = DurchschnittGehalt();
            return Math.Sqrt(mitarbeiterListe.Average(m => Math.Pow(m.Gehalt - durchschnitt, 2)));
        }

        public double MedianGehalt()
        {
            var sortedGehalt = mitarbeiterListe.Select(m => m.Gehalt).OrderBy(g => g).ToList();
            int count = sortedGehalt.Count;
            if (count % 2 == 0)
            {
                return (sortedGehalt[count / 2 - 1] + sortedGehalt[count / 2]) / 2;
            }
            else
            {
                return sortedGehalt[count / 2];
            }
        }

        public void SchreibeDatenInDatei(string dateiPfad)
        {
            using (StreamWriter writer = new StreamWriter(dateiPfad))
            {
                writer.WriteLine("Vorname,Nachname,StatusImBetrieb,Gehalt,AnzahlJahreImBetrieb");
                foreach (var mitarbeiter in mitarbeiterListe)
                {
                    writer.WriteLine($"{mitarbeiter.Vorname},{mitarbeiter.Nachname},{mitarbeiter.StatusImBetrieb},{mitarbeiter.Gehalt},{mitarbeiter.AnzahlJahreImBetrieb}");
                }

                writer.WriteLine();
                writer.WriteLine($"Max Gehalt: {MaxGehalt()}");
                writer.WriteLine($"Min Gehalt: {MinGehalt()}");
                writer.WriteLine($"Summe Gehalt: {SummeGehalt()}");
                writer.WriteLine($"Durchschnitt Gehalt: {DurchschnittGehalt()}");
                writer.WriteLine($"Standardabweichung Gehalt: {StandardabweichungGehalt()}");
                writer.WriteLine($"Median Gehalt: {MedianGehalt()}");
            }
        }
    }
}