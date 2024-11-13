using System.Runtime.InteropServices;
public class Checks()
{
    public bool BackToMain()
    {
        Console.Write("Vil du prøve igjen?? j/n");
        ConsoleKey tryagainNameChoice = Console.ReadKey().Key;
        switch (tryagainNameChoice)
        {
            case ConsoleKey.J:
                return false;
            case ConsoleKey.N:
                return true;
        }
        return true;//should be unreachable
    }
}