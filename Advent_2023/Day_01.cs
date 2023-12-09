using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLImber;

namespace Advent_2023
{
    [CommandClass(commandName: "day01", ShortDescription = "Day 1 of Advent of Code.")]
    internal class Day_01
    {
        private static readonly (string name, string number)[] _numberNames =
        [
            ("zero", "0"),
            ("one", "1"),
            ("two", "2"),
            ("three", "3"),
            ("four", "4"),
            ("five", "5"),
            ("six", "6"),
            ("seven", "7"),
            ("eight", "8"),
            ("nine", "9")
        ];

        [CommandOption(name: "file", Abbreviation = 'f')]
        public string FilePath { get; set; } = "day_01_input.txt";
        [CommandOption(name: "parse", Abbreviation = 'p')]
        public bool ParseText { get; set; } = false;

        [CommandHandler]
        public void Run()
        {
            int total = 0;
            using (StreamReader fileReader = new StreamReader(FilePath))
            {
                string line = string.Empty;
                while ((line = fileReader.ReadLine()) != null)
                {
                    if (ParseText) line = ParseTextToNumbers(line);
                    total += GetNumberFromLine(line);
                }
            }

            Console.WriteLine($"Total: {total}");
        }

        [CommandHandler]
        public void Run(string line)
        {
            int total = 0;
            if (ParseText) line = ParseTextToNumbers(line);
            total += GetNumberFromLine(line);

            Console.WriteLine($"Total: {total}");
        }

        private string ParseTextToNumbers(string line)
        {
            _numberNames.ToList().ForEach(n => line = line.Replace(n.name, n.number, StringComparison.CurrentCultureIgnoreCase));
            return line;
        }

        private int GetNumberFromLine(string line)
        {
            return (FindFirstNumber(line) * 10) + FindLastNumber(line);
        }

        private int FindFirstNumber(string line)
        {

            int digit = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (int.TryParse(line[i].ToString(), out digit))
                {
                    return digit;
                }
            }
            return 0;
        }

        private int FindLastNumber(string line)
        {
            int digit = 0;
            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (int.TryParse(line[i].ToString(), out digit))
                {
                    return digit;
                }
            }
            return 0;
        }

        
    }
}
