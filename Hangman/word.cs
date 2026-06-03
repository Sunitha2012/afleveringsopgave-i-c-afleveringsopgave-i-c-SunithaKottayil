namespace Hangman
{
    class Word
    {
        private Dictionary<string, List<string>> gameLevels = new()
        {
            {
                "Easy",
                new List<string>
                {
                    "MINECRAFT","FORTNITE","ROBLOX","TETRIS","MARIO","SONIC","POKEMON","HALO"
                }
            },
            {
                "Medium",
                new List<string>
                {
                    "CALL OF DUTY","GRAND THEFT AUTO","LEAGUE OF LEGENDS",
                    "ROCKET LEAGUE","OVERWATCH","FIFA","EA SPORTS FC"
                }
            },
            {
                "Hard",
                new List<string>
                {
                    "RED DEAD REDEMPTION","ELDEN RING","DARK SOULS",
                    "THE LAST OF US","GOD OF WAR","METAL GEAR SOLID"
                }
            }
        };

        private Random rnd = new();

        public string RandomWord(string level)
        {
            List<string> words = gameLevels[level];
            int index = rnd.Next(words.Count);
            return words[index];
        }
    }
}