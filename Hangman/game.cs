namespace Hangman
{
    class Game
    {
        public int maxLives { get; private set; }

        public void Start()
        {
            Word word = new Word();
            Status status = new Status();

            Console.WriteLine("===== HANGMAN =====");
            Console.WriteLine("Choose difficulty:");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");

            string choice = Console.ReadLine();

            string level = choice switch
            {
                "1" => "Easy",
                "2" => "Medium",
                "3" => "Hard",
                _ => "Easy"
            };

            string WordGuess = word.RandomWord(level).ToUpper();

            char[] Secret = new char[WordGuess.Length];
            List<char> guessedLetters = new List<char>();

            // Fill with '-' but reveal spaces
            for (int i = 0; i < Secret.Length; i++)
            {
                Secret[i] = WordGuess[i] == ' ' ? ' ' : '-';
            }

            int lives = level switch
            {
                "Easy" => 8,
                "Medium" => 6,
                "Hard" => 5,
                _ => 6
            };

            maxLives = lives;   // ❤️ FIX ADDED HERE

            while (lives > 0 && new string(Secret) != WordGuess)
            {
                Console.WriteLine();
                Console.WriteLine($"Difficulty: {level}");
                Console.WriteLine($"Lives: {lives}");
                Console.WriteLine();

                Console.Write("Lives left: ");
for (int i = 0; i < maxLives; i++)
{
    if (i < lives)
        Console.Write("❤️ ");
    else
        Console.Write("🤍 ");
}
Console.WriteLine($" ({lives}/{maxLives})");

                status.DrawHangman(lives);

                Console.WriteLine();
                Console.WriteLine(new string(Secret));
                Console.WriteLine();

                status.ShowRemainingLetters(guessedLetters);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Guess a letter (or type 'exit'): ");
                Console.ResetColor();

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

                char guess = char.ToUpper(input[0]);

                if (guessedLetters.Contains(guess))
                {
                    Console.WriteLine("You already guessed that letter.");
                    continue;
                }

                guessedLetters.Add(guess);

                bool found = false;

                for (int i = 0; i < WordGuess.Length; i++)
                {
                    if (WordGuess[i] == guess)
                    {
                        Secret[i] = guess;
                        found = true;
                    }
                }

                if (found)
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    lives--;
                    Console.WriteLine($"Wrong! Lives left: {lives}");
                }

                // ❤️ HEART BAR
                Console.Write("Lives left: ");
                for (int i = 0; i < maxLives; i++)
                {
                    if (i < lives)
                        Console.Write("❤️ ");
                    else
                        Console.Write("🤍 ");
                }
                Console.WriteLine($" ({lives}/{maxLives})");
            }

            Console.WriteLine();

            if (new string(Secret) == WordGuess)
            {
                Console.WriteLine("🎉 Congratulations!");
                Console.WriteLine($"You guessed: {WordGuess}");
            }
            else
            {
                status.DrawHangman(0);
                Console.WriteLine("💀 Game Over!");
                Console.WriteLine($"The game was: {WordGuess}");
            }
        }
    }
}