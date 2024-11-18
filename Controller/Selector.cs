public class Selector()
{
    public void SelectGame(string username)
    {
        Games game = new Games();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Velg spill");
            Console.WriteLine("1. Matte");
            Console.WriteLine("0. Tilbake");
            ConsoleKey menuChoice = Console.ReadKey().Key;
            switch (menuChoice)
            {
                case ConsoleKey.D0:
                    return;
                case ConsoleKey.D1:
                    game.MathGame(username);
                    break;
            }
        }
    }
    
}