using System;
using System.Collections.Generic;

namespace Hangman
{
    class Word
    {
        private List<string> words = new List<string>()
        {
            
        };

        public string GetRandomWord()
        {
            Random rnd = new Random();
            int index = rnd.Next(words.Count);
            return words[index];
        }
    }
}
