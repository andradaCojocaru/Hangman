using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_Game
{
    internal class WordController
    {
        public static string GetRandomWord()
        {
            Random random = new Random();
            string fileName = @"C:\Users\andrada.cojocaru\source\repos\Hangman Game\Hangman Game\Words.txt";

            var lines = File.ReadAllLines(fileName);
            var r = new Random();
            var randomLineNumber = r.Next(0, lines.Length - 1);
            var line = lines[randomLineNumber];

            return line;
        }
    }
}
