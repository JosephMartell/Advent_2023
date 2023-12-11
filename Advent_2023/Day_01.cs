using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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
                    total += ParseLine(line);
                }
            }

            Console.WriteLine($"Total: {total}");
        }

        [CommandHandler]
        public void Run(string line)
        {
            Console.WriteLine($"Total: {ParseLine(line)}");
        }

        private int ParseLine(string line)
        {
            string forwardLine = ParseText ? ParseFirstNumber(line) : line;
            string revLine = ParseText ? ParseLastNumber(line) : line;
            return FirstNumber(forwardLine) * 10 + LastNumber(revLine);
        }


        private string ParseFirstNumber(string line)
        {
            string newLine = line;
            for (int i = 0; i < line.Length; i++)
            {
                for (int j = 0; j < _numberNames.Length; j++)
                {
                    if (line.Substring(i).StartsWith(_numberNames[j].name))
                    {
                        return line.Replace(_numberNames[j].name, _numberNames[j].number);
                    }
                }
            }
            return newLine;
        }
        private string ParseLastNumber(string line)
        {
            string newLine = line;
            for (int i = line.Length; i > 0; i--)
            {
                for (int j = 0; j < _numberNames.Length; j++)
                {
                    if (line.Substring(0, line.Length - (line.Length - i)).EndsWith(_numberNames[j].name))
                    {
                        return line.Replace(_numberNames[j].name, _numberNames[j].number);
                    }
                }
            }
            return newLine;
        }

        private int FirstNumber(string line)
        {
            return (from c in line.ToArray() 
                    where char.IsNumber(c) 
                    select int.Parse(c.ToString())).First();
        }

        private int LastNumber(string line)
        {
            return (from c in line.ToArray()
                    where char.IsNumber(c)
                    select int.Parse(c.ToString())).Last();
        }

        
    }
}
