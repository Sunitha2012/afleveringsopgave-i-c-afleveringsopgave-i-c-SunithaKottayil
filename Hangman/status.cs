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
    if (lives == 6)
    {
        Console.WriteLine("");
    }
    else if (lives == 5)
    {
        Console.WriteLine("  O");
    }
    else if (lives == 4)
    {
        Console.WriteLine("  O");
        Console.WriteLine("  |");
    }
    else if (lives == 3)
    {
        Console.WriteLine("  O");
        Console.WriteLine(" /|");
    }
    else if (lives == 2)
    {
        Console.WriteLine("  O");
        Console.WriteLine(" /|\\");
    }
    else if (lives == 1)
    {
        Console.WriteLine("  O");
        Console.WriteLine(" /|\\");
        Console.WriteLine(" /");
    }
    else if (lives == 0)
    {
        Console.WriteLine("  O");
        Console.WriteLine(" /|\\");
        Console.WriteLine(" / \\");
    }
}

    }
}
