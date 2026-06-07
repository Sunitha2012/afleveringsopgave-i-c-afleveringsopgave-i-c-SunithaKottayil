namespace Hangman
{
    class Word
    {
        private List<string> EasyWords = new()
        {
            "MARIO", "SONIC", "HALO", "FIFA",
            "TETRIS", "ROBLOX", "POKEMON", "PIKACHU"
        };

        private List<string> MediumWords = new()
        {
            "MINECRAFT",    "FORTNITE",
            "GRAN TURISMO", "ROCKET LEAGUE"
        };

        private List<string> HardWords = new()
        {
            "DARK SOULS",     "ELDEN RING",
            "NEED FOR SPEED", "LEAGUE OF LEGENDS",
            "LARA CROFT",     "MASTER CHIEF",
            "DONKEY KONG",    "CRASH BANDICOOT"
        };

        private Random Rnd = new();

  //Metod til  at generere random ord 
        public string RandomWord(string level)
        {
            List<string> wordList;

            switch (level)
            {
                case "Easy":
                    wordList = EasyWords;
                    break;
                case "Medium":
                    wordList = MediumWords;
                    break;
                default:
                    wordList = HardWords;
                    break;
            }

            return wordList[Rnd.Next(wordList.Count)]; // væl et random ord fra index range (0,antalord)
        }
    }
}

