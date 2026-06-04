using System;
using System.Collections.Generic;

namespace Hangman
{
    class Word
    {
        private readonly List<string> easyWords = new()
        {
            "MINECRAFT", "FORTNITE", "ROBLOX", "TETRIS",
            "MARIO", "SONIC", "POKEMON", "HALO"
        };

        private readonly List<string> mediumWords = new()
        {
            "CALL OF DUTY", "GRAND THEFT AUTO", "LEAGUE OF LEGENDS",
            "ROCKET LEAGUE", "OVERWATCH", "FIFA", "EA SPORTS FC"
        };

        private readonly List<string> hardWords = new()
        {
            "RED DEAD REDEMPTION", "ELDEN RING", "DARK SOULS",
            "THE LAST OF US", "GOD OF WAR", "METAL GEAR SOLID"
        };

        private readonly Dictionary<string, List<string>> gameLevels = new(); // a dictionary with  key string and value list 
        private readonly Random rnd = new();



        public Word()
        {
            gameLevels["Easy"] = easyWords;
            gameLevels["Medium"] = mediumWords;
            gameLevels["Hard"] = hardWords;
        }
        

        public string RandomWord(string level)
{
    List<string> words = gameLevels[level]; // access the values(list) for level key 
    int index = rnd.Next(words.Count); //pick a random index
    return words[index];
}
    }
}