using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheWord
{
    public class HumanPlayer:Player
    {
        public override string GetLeterOrWord()
        {
            Console.WriteLine($"{PlayerName} insert a letter or correct word:");
            return Console.ReadLine();
        }

        public override string GetWordToGuess()
        {
            Console.WriteLine($"{PlayerName} insert your guess word:");
            return Console.ReadLine();
        }
    }
}
