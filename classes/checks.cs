using System.Runtime.InteropServices;

public class Checks()
{
    public bool BackToMain()
    {
        Console.Write("Do you wish to try again? y/n");
        ConsoleKey tryagainNameChoice = Console.ReadKey().Key;
        switch (tryagainNameChoice)
        {
            case ConsoleKey.Y:
                return false;
            case ConsoleKey.N:
                return true;
        }
        return true;//should be unreachable
    }
}