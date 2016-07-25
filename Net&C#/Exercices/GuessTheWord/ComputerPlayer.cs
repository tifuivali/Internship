using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheWord
{
    public class ComputerPlayer:Player
    {
        public string PathToWordsFile { get; set; }

        public override string GetLeterOrWord()
        {
            int letterNumber = new Random().Next(65,90);
            return ""+(char)letterNumber;
        }

        public override string GetWordToGuess()
        {
            TextReader reader = File.OpenText(PathToWordsFile);
            List<string> words = new List<string>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                words.Add(line);
            }
            int numberOfLine = new Random().Next(words.Count);
            return words[numberOfLine];
        }
    }
    
}
