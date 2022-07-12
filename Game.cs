using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_Game
{
    internal class Game
    {
        public string MyWord { get; set; }
        public bool[] CharsCorrect { get; set; }
        public List<char> CharsIncorrect { get; set; }
        public int Fails { get; set; }


        public Game()
        {
            MyWord = WordController.GetRandomWord();
            CharsCorrect = new bool[MyWord.Length];
            CharsIncorrect = new List<char>();
            Fails = 0;
        }

        bool isCharInWord(char input)
        {
            return MyWord.Contains(input);
        }

        int[] getPositions(char input)
        {
            List<int> positions = new List<int>();
            //for (int i = 0; i < MyWord.Length; i++)
            //{
            //    if (MyWord[i] == input)
            //        positions.Add(i);
            //}
            positions.ForEach(i =>
            {
                if (MyWord[i] == input)
                    positions.Add(i);
            });
            return positions.ToArray();
            
        }

        string getCorrectChar()
        {
            string output = "";
            for (int i = 0; i < MyWord.Length; i++)
            {
                if (CharsCorrect[i])
                {
                    output += MyWord[i];
                } else
                {
                    output += "_";
                }
            }
            return output;
        }

        /*
        string getIncorrectChar()
        {
            string output = "";
            for (int i = 0; i < CharsIncorrect.Count; i++)
            {
                output += CharsIncorrect[i];
            }
            return output;
        }
        */

        public void Show()
        {
            Console.WriteLine(Drawer.DrawHangman(Fails));
            Console.WriteLine("Cuvant " + getCorrectChar());
            Console.Write("Litere gresite ");
            CharsIncorrect.ForEach(c => Console.Write(c));
            Console.WriteLine();
        }

        public GameState UpdateStateGame(char input)
        {
            GameState state = GameState.InProgress;

            if (isCharInWord(input)) {
                int[] positions = getPositions(input);
                foreach (int pos in positions)
                {
                    CharsCorrect[pos] = true;
                }
            } else
            {
                CharsIncorrect.Add(input);
                Fails++;
            }

            if (Fails == 6)
                state = GameState.Lost;

            if (CharsCorrect.All(x => x == true))
                state = GameState.Won;

            Show();
            return state;
        }
    }

    enum GameState
    {
        Won,
        Lost,
        InProgress
    }
}
