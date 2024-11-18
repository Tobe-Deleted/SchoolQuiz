using System.Runtime.InteropServices;
public class Checks()
{
    public bool BackToMain(string message)
    {
        Console.Write($"{message} j/n");
        while(true)
        {
            ConsoleKey tryagainNameChoice = Console.ReadKey().Key;
            switch (tryagainNameChoice)
            {
                case ConsoleKey.J:
                    return false;
                case ConsoleKey.N:
                    return true;
            }
        }
    }
}