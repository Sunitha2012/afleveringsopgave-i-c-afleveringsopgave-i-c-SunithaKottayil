
namespace Hangman
{
    class Game
    {
        public int maxLives;

        private void Canvas(Status status, int lives, int maxLives, char[] secret, List<char> guessedLetters) //  alle parametre , den skal bruge 
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(status.BuildHeader());
            Console.ResetColor();

            Console.Write(status.BuildMainSection(lives, maxLives, secret));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(status.BuildAlphabetSection(guessedLetters));
            Console.ResetColor();

            Console.Write("Guess a letter (or type 0 to exit): ");
        }

        private string GetDifficultyChoice()
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===== HANGMAN =====");
                Console.ResetColor();

                Console.WriteLine("Choose difficulty:");
                Console.WriteLine("1. Easy");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. Hard");
                Console.WriteLine("0. Exit");
                Console.Write("Your choice: ");

                string choice = Console.ReadLine() ;

                if (choice == "0")
                    return "EXIT";
                if (choice == "1")
                    return "Easy";
                if (choice == "2")
                    return "Medium";
                if (choice == "3")
                    return "Hard";

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid choice. Press Enter to try again...");
                Console.ResetColor();
                Console.ReadLine();
            }
        }

        private string GetValidGuess(List<char> guessedLetters)
        {
            while (true)
            {
                string input = Console.ReadLine() ;
                input = input.Trim().ToUpper();

                if (input == "0" )
                    return "EXIT";


                char guess = input[0]; // tager første bogstaver fra inpot 

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
            while (true)
            {
                Console.Write("\nPlay again? (Y/N): ");
                string answer = (Console.ReadLine() ?? "").Trim().ToUpper();

                if (answer == "Y" || answer == "YES")
                    return true;

                if (answer == "N" || answer == "NO" || answer == "0" || answer == "EXIT")
                    return false;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please type Y or N.");
                Console.ResetColor();
            }
        }

        private bool PlayGame()
        {
            Word word = new Word();
            Status status = new Status();

            string level = GetDifficultyChoice();

            if (level == "EXIT")
                return false;

            string wordGuess = word.RandomWord(level).ToUpper();

            char[] secret = new char[wordGuess.Length];
            List<char> guessedLetters = new List<char>();

            for (int i = 0; i < secret.Length; i++)
                secret[i] = wordGuess[i] == ' ' ? ' ' : '-';

            int lives = 6;
            maxLives = 6;

            while (lives > 0 && new string(secret) != wordGuess)
            {
                Console.Clear();
                Canvas(status, lives, maxLives, secret, guessedLetters);

                string guessInput = GetValidGuess(guessedLetters);

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
            Canvas(status, lives, maxLives, secret, guessedLetters);

            if (new string(secret) == wordGuess)
            {
                
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Well done ...you gueesed correct  : {wordGuess}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n Game Over!");
                Console.ResetColor();
                Console.WriteLine($"The word was: {wordGuess}");
            }

            return AskPlayAgain();
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