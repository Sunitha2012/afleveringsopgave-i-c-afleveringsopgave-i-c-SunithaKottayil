
namespace Hangman
{
    class Status
    {
        public void ShowProgress(string secret)
        {
            Console.WriteLine("Word: " + secret);
        }



        public void DrawHangman(int lives)
        {
            Console.Clear();

            //Top hanging tree
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.ResetColor();

            // HEAD
            if (lives <= 5)
                Console.WriteLine("  |  🧑");
            else
                Console.WriteLine("  |");

            // BODY + ARMS
            if (lives <= 3)
                Console.WriteLine("  |  /|\\");
            else if (lives == 4)
                Console.WriteLine("  |   |");
            else
                Console.WriteLine("  |");

            // LEGS
            if (lives == 1)
                Console.WriteLine("  |  /");
            else if (lives == 0)
                Console.WriteLine("  |  / \\");
            else
                Console.WriteLine("  |");

            Console.WriteLine("  |");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("=========");
            Console.ResetColor();
        }

        public void ShowRemainingLetters(List<char> guessed)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string remaining = "";

            foreach (char c in alphabet)
            {
                if (!guessed.Contains(c))
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    remaining += c + " ";
                    Console.ResetColor();
                }
            }

            Console.WriteLine("Remaining letters: " + remaining);
        }
    }
}