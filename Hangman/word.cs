using System.Net.Mail;

namespace Hangman
{
    class Word
    {
        private List<string> words = new List<string>()
        {
            "toyota",
            "bmw",
            "audi",
            "ford",
            "volvo"
        };
//  metode til at  bruge et index til at hente  et tilfældigt ord  fra words-liste og returnerer det som en string
       private Random rnd = new Random();

public string RandomWord()
{
    int index = rnd.Next(words.Count);
    return words[index];
}
    }
}
