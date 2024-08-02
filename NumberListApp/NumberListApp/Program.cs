using System;
using NumberListApp;

namespace NumberListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberListManager manager = new NumberListManager();

            while (true)
            {
                Console.WriteLine("Geben Sie eine Zahl ein, um sie zur Liste hinzuzufügen (oder geben Sie 'q' zum Beenden der Eingabe ein):");
                string input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    break;
                }

                if (int.TryParse(input, out int number))
                {
                    manager.AddNumber(number);
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Zahl ein.");
                }
            }

            manager.DisplayNumbers();

            try
            {
                Console.WriteLine($"Durchschnitt: {manager.CalculateAverage()}");
                Console.WriteLine($"Median: {manager.CalculateMedian()}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            while (true)
            {
                Console.WriteLine("Geben Sie eine Zahl ein, um sie aus der Liste zu entfernen (oder geben Sie 'q' zum Beenden der Entfernung ein):");
                string input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    break;
                }

                if (int.TryParse(input, out int number))
                {
                    manager.RemoveNumber(number);
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Zahl ein.");
                }
            }

            manager.DisplayNumbers();

            manager.SaveToFile("numbers.txt");

            manager.LoadFromFile("numbers.txt");
            manager.DisplayNumbers();

            try
            {
                Console.WriteLine($"Durchschnitt: {manager.CalculateAverage()}");
                Console.WriteLine($"Median: {manager.CalculateMedian()}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}