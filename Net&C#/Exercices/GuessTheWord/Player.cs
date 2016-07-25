using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheWord
{
    public abstract class Player
    {
        private int numberOfLifes;

        public int NumberOfLifes
        {
            get { return numberOfLifes; }
            set
            {
                if (value < 1 || value > 5)
                    throw new Exception($"Number of lifes must be between 1 and 5! Curent value is {value}");
                numberOfLifes = value;
            }
        }

        public int Score { get; set; }

        public string PlayerName { get; set; }

        public abstract string GetLeterOrWord();

        public abstract string GetWordToGuess();

    }
}
