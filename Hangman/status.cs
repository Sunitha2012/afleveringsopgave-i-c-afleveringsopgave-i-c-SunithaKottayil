using System.Collections.Generic;

namespace Hangman
{
    class Status
    {
        public string BuildHeader()
        {
            return
@"HANGMAN
========================================================================
";
        }

        // bygger midterdelen af spillet
        public string BuildMainSection(int lives, int maxLives, char[] secret) //
        {
            List<string> hang = GetHangmanLines(lives); // henter linjer fra hangmanline and add based on lives
            string wordLine = string.Join(" ", secret); // tilføjer gættet letter til secret ord 
            string hearts = GetHearts(lives, maxLives);

            return
$@"{hang[0]}
{hang[1]}
{hang[2]}
{hang[3]}
{hang[4]}
{hang[5]}

Word:  {wordLine}
Lives: {hearts}

";
        }

        public string BuildAlphabetSection(List<char> guessedLetters)
        {
            string row = AllLetters(guessedLetters);

            return
$@"Alphabet:
{row}
========================================================================
";
        }

        public List<string> GetHangmanLines(int lives)
        {
            string head = " ";
            string body = " ";
            string leftArm = " ";
            string rightArm = " ";
            string leftLeg = " ";
            string rightLeg = " ";

            if (lives <= 5) head = "👦";
            if (lives <= 4) body = "|";
            if (lives <= 3) leftArm = "/";
            if (lives <= 2) rightArm = "\\";
            if (lives <= 1) leftLeg = "/";
            if (lives <= 0) rightLeg = "\\";

            return new List<string>
            {
                "   ┏━━━━━━━━━━━━┓",
                "   ┃            |",
                $"   ┃           {head}",
                $"   ┃           {leftArm}{body}{rightArm}",
                $"   ┃           {leftLeg} {rightLeg}",
                "   ┃"
            };
        }

        // Bygger hjerte til lives 🤎 og  🖤 for mistede
        public string GetHearts(int lives, int maxLives)
        {
            string hearts = "";

            // Gå gennem alle indexer (fra 0 til maxLives-1)
            for (int index = 0; index < maxLives; index++)
            {
                if (index < lives)
                {
                    hearts += "🤎 ";
                }
                else
                {
                    hearts += "🖤 ";      //mistet lives
                }
            }

            return hearts;
        }

        // Metoden Returnerer alfabetet som en streng, hvor gættede bogstaver erstattes med "_"
        public string AllLetters(List<char> guessedLetters)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string row = "";

            foreach (char c in alphabet)
            {
                if (guessedLetters.Contains(c))
                {
                    row += "_ ";
                }
                else
                {
                    row += c + " ";
                }
            }

            return row;
        }
    }
}