using System;
using System.Collections.Generic;

namespace Hangman
{
    class Game
    {
        private Word wordGenerator = new Word();
        private Status status = new Status();

        public void Start()
        {
            string secret = wordGenerator.GetRandomWord();

        
            Console.WriteLine("Welcome");
        }
    }
}
