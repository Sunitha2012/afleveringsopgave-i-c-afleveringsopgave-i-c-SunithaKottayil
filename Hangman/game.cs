namespace Hangman
{
    class Game
    {
        public void Start()
        {
            Word word = new Word(); // get a variable from the word class 

            string WordGuess = word.RandomWord(); // accessing method RandomWord from word class 

            char[] Secret = new char[WordGuess.Length]; // empty array to store same number of characters

            // fill Secret  array with '-'
            for (int i = 0; i < Secret.Length; i++)
            {
                Secret[i] = '-';
            }

            int lives = 6;   

            while (lives > 0 && new string(Secret) != WordGuess)
            {
                Console.Write("Guess a letter (or type 'exit'): ");
                string input = Console.ReadLine();

               
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Game ended by user.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter a letter.");
                    continue;
                }

                if (input.Length != 1)
                {
                    Console.WriteLine("Only one character allowed.");
                    continue;
                }

                char guess = char.ToLower(input[0]);

                bool found = false;

                // CHECK LETTER
                for (int i = 0; i < WordGuess.Length; i++)
                {
                    if (WordGuess[i] == guess)
                    {
                        Secret[i] = guess;
                        found = true;
                    }
                }

                if (!found)
                {
                    lives--;
                    Console.WriteLine("Wrong! Lives left: " + lives);
                }

                Console.WriteLine(new string(Secret));
            }

            
        }
    }
}

