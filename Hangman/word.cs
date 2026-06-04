namespace Hangman
{
    class Word
    {
        public List<string> EasyWords = new()
        {
            "MINECRAFT", "FORTNITE", "ROBLOX", "TETRIS",
            "MARIO", "SONIC", "POKEMON", "HALO"
        };

        public List<string> MediumWords = new()
        {
            "CALL OF DUTY", "GRAND THEFT AUTO", "LEAGUE OF LEGENDS",
            "ROCKET LEAGUE", "OVERWATCH", "FIFA", "EA SPORTS FC"
        };

        public List<string> HardWords = new()
        {
            "RED DEAD REDEMPTION", "ELDEN RING", "DARK SOULS",
            "THE LAST OF US", "GOD OF WAR", "METAL GEAR SOLID"
        };

        public Dictionary<string, List<string>> GameLevels = new();
       

        public Word() // auto update object -  line 134 in game.cs 
        {
            GameLevels["Easy"] = EasyWords;
            GameLevels["Medium"] = MediumWords;
            GameLevels["Hard"] = HardWords;
        }

 public Random Rnd = new();
        public string RandomWord(string level)
        {
            var words = GameLevels[level];
            return words[Rnd.Next(words.Count)];
        }
    }
}
