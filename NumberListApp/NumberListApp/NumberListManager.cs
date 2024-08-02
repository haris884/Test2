using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NumberListApp
{
    public class NumberListManager
    {
        private List<int> numbers;

        public NumberListManager()
        {
            numbers = new List<int>();
        }

        public void AddNumber(int number)
        {
            numbers.Add(number);
            Console.WriteLine($"{number} wurde zur Liste hinzugefügt.");
        }

        public void RemoveNumber(int number)
        {
            if (numbers.Remove(number))
            {
                Console.WriteLine($"{number} wurde aus der Liste entfernt.");
            }
            else
            {
                Console.WriteLine($"{number} ist nicht in der Liste vorhanden.");
            }
        }

        public void DisplayNumbers()
        {
            if (numbers.Count == 0)
            {
                Console.WriteLine("Die Liste ist leer.");
            }
            else
            {
                Console.WriteLine("Aktuelle Liste der Zahlen:");
                foreach (int number in numbers)
                {
                    Console.WriteLine(number);
                }
            }
        }

        public double CalculateAverage()
        {
            if (numbers.Count == 0)
            {
                throw new InvalidOperationException("Die Liste ist leer. Durchschnitt kann nicht berechnet werden.");
            }
            return numbers.Average();
        }

        public double CalculateMedian()
        {
            if (numbers.Count == 0)
            {
                throw new InvalidOperationException("Die Liste ist leer. Median kann nicht berechnet werden.");
            }

            var sortedNumbers = numbers.OrderBy(n => n).ToList();
            int count = sortedNumbers.Count;
            if (count % 2 == 0)
            {
                return (sortedNumbers[count / 2 - 1] + sortedNumbers[count / 2]) / 2.0;
            }
            else
            {
                return sortedNumbers[count / 2];
            }
        }

        public void SaveToFile(string filePath)
        {
            File.WriteAllLines(filePath, numbers.Select(n => n.ToString()));
            Console.WriteLine("Liste wurde in der Datei gespeichert.");
        }

        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                numbers = File.ReadAllLines(filePath).Select(int.Parse).ToList();
                Console.WriteLine("Liste wurde aus der Datei geladen.");
            }
            else
            {
                Console.WriteLine("Datei nicht gefunden.");
            }
        }
    }
}