namespace Hangman
{
    class Game
    {
        
    private bool PlayGame()
        {
            Word word = new Word();// Lav et nyt Word‑objekt, så jeg kan bruge Word‑klassens metoder.
            Status status = new Status();

            string level = SelectLevel(); // variable level gemmer resultat af metoden 

            if (level == "EXIT")
                return false;

            string wordGuess = word.RandomWord(level).ToUpper();

            char[] secret = new char[wordGuess.Length];// gemmer wordguess som char array ,så skal vi  ændre ét tegn ad gangen
            

           for (int i = 0; i < secret.Length; i++)
            {
                if (wordGuess[i] == ' ')
                    secret[i] = ' ';
                else
                    secret[i] = '-';
            }


            int lives = 6;
            List<char> guessedLetters = new List<char>();

            while (lives > 0 && new string(secret) != wordGuess)
            {
                Console.Clear();
                Canvas(status, lives, secret, guessedLetters);

                string guessInput = ValidateInput(guessedLetters);

                if (guessInput == "EXIT")
                    return false;

                char guess = guessInput[0];
                guessedLetters.Add(guess);

                bool found = false;

                for (int i = 0; i < wordGuess.Length; i++)
                {
                    if (wordGuess[i] == guess)
                    {
                        secret[i] = guess;
                        found = true;
                    }
                }

                if (!found)
                    lives--;
            }

            Console.Clear();
            Canvas(status, lives, secret, guessedLetters);// method fra linje 144 

            if (new string(secret) == wordGuess)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Well done ...you guessed correct : {wordGuess}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nGame Over!");
                Console.ResetColor();
                Console.WriteLine($"The word was: {wordGuess}");
            }

            return AskPlayAgain();
        }

        private string SelectLevel()
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===== HANGMAN =====");
                Console.ResetColor();

                Console.WriteLine("Choose difficultylevel:");
                Console.WriteLine("1. Easy");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. Hard");
                Console.WriteLine("0. Exit");
                Console.Write("Your choice: ");

                string choice = Console.ReadLine() ;

                switch (choice)
                {
                    case "0":
                        return "EXIT"; // linje 13 if level 0, return false dvs stop spillet 

                    case "1":
                        return "Easy";

                    case "2":
                        return "Medium";

                    case "3":
                        return "Hard";

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid choice. Press Enter to try again...");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }


        private void Canvas(Status status, int lives, char[] secret, List<char> guessedLetters) // alle parametre , den skal bruge
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(status.Header());
            Console.ResetColor();

            Console.Write(status.MainSection(lives, secret));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(status.AlphabetSection(guessedLetters));
            Console.ResetColor();

            Console.Write("Guess a letter (or type 0 to exit): ");
        }

        
        private string ValidateInput(List<char> guessedLetters)
        {
            while (true)
            {
                string input = Console.ReadLine() ?? "";

            // Hvis spilleren ikke skriver noget
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Please enter a letter A-Z : ");
                    Console.ResetColor();
                    continue;
                }


                input = input.Trim().ToUpper();


                if (input == "0")
                    return "EXIT";

                char guess = input[0]; // tager første bogstaver fra input

                if (!char.IsLetter(guess))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Please enter a letter A-Z : ");
                    Console.ResetColor();
                    continue;
                }

                if (guessedLetters.Contains(guess))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("You already guessed that letter. Try again: ");
                    Console.ResetColor();
                    continue;
                }

                return guess.ToString(); // converter char til string
            }
        }

        private bool AskPlayAgain()
        {
            string answer;

            do
            {
                Console.Write("\nPlay again? (Y/N): ");
                answer = (Console.ReadLine() ?? "").Trim().ToUpper();

                if (answer == "Y" )
                {
                    return true;
                }

                if (answer == "N")
                {
                    return false;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please type Y or N.");
                Console.ResetColor();

            } while (true);
        }

        

        public void Start()
        {
            bool playAgain = true;

            while (playAgain)
            {
                playAgain = PlayGame();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nThanks for playing Hangman!");
            Console.ResetColor();
        }
    }
}
