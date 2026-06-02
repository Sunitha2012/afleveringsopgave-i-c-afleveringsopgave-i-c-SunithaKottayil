

namespace Hangman
{
    class Status
    {
        public void DrawHangman(int wrong)
        {
            Console.WriteLine("Wrong guesses: " + wrong);
          
        }

        public void ShowProgress(string progress)
        {
            Console.WriteLine("Word: " + progress);
        }
    }
}
