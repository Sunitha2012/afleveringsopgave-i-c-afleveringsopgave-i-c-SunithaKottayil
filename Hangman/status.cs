namespace Hangman
{
    class Status
    {
        public string Header()
        {
            return
                $@"
                H   H      A       N   N    GGGG     M   M      A       N   N
                H   H     A A      NN  N   G         MM MM     A A      NN  N
                HHHHH    A   A     N N N   G  GGG    M M M    A   A     N N N
                H   H   AAAAAAA    N  NN   G    G    M   M   AAAAAAA    N  NN
                H   H  A       A   N   N    GGGG     M   M  A       A   N   N


                ";
        }

        // Viser Spil  Sektion
        public string MainSection(int lives, char[] secret) 
        {
            List<string> hang = DrawHangMan(lives); // henter linjer fra hangmanline and add based on lives
            string wordLine = string.Join(" ", secret); // tilføjer gættet letter til secret ord 
            string hearts = GetHearts(lives);

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

        public string AlphabetSection(List<char> guessedLetters)
        {
            string row = AllLetters(guessedLetters);

            return
                $@"Alphabet:
                {row}
                ========================================================================
                ";
        }

        public List<string> DrawHangMan(int lives)
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

        // Bygger hjerte til lives  
       public string GetHearts(int lives)
        {
            string hearts = "";

            for (int i = 0; i < 6; i++)
            {
                hearts += i < lives ? "❤️ " : "🖤 ";
            }

            return hearts;
}

        // Metoden Returnerer alfabetet som en streng, hvor gættede bogstaver erstattes med "_"
        public string AllLetters(List<char> guessedLetters)
        {
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string row = "";

            foreach (char c in alphabet)
            {
                row += guessedLetters.Contains(c) ? "_ " : c + " ";
            }

            return row;
        }
    }
}
