namespace loginProject;

class Program
{
    static void Main(string[] args)
    {
        LoginAndCreation lac = new LoginAndCreation();
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Bjørndalsskogen Quiz v 0.6");
            Console.WriteLine("1. Logg inn");
            Console.WriteLine("2. Lag ny bruker");
            Console.WriteLine("0. Avslutt");
            ConsoleKey MainMenuChoice = Console.ReadKey().Key;
            switch (MainMenuChoice)
            {
                case ConsoleKey.D1:
                    string username;
                    string password;
                    Console.Clear();
                    Console.WriteLine("~~Logg inn~~");
                    Console.Write("Brukernavn: ");
                    username = Console.ReadLine() ?? "!";
                    Console.Write("Passord: ");
                    password = Console.ReadLine() ?? "!";
                    if (lac.LogIn(username, password))
                    {
                        exit = LoggedInMainMenu(username);
                        
                    }
                    else 
                    {
                        Console.WriteLine("Feil passord eller brukernavn");
                        Console.ReadKey();
                    }
                    break;

                case ConsoleKey.D2:
                    lac.CreateUser();
                    break;
                case ConsoleKey.D0:
                    exit = true;
                    Console.Clear();
                    break;
            }
        }
    }

    static bool LoggedInMainMenu(string user)
    {
        Selector selector = new Selector();
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Du er logget inn som {user}");
            //Console.ReadKey();
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("1. Spill");
            Console.WriteLine("2. Se Ledertavle");
            Console.WriteLine("3. Endre passord");
            Console.WriteLine("0. Logg ut");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            ConsoleKey mainMenuchoice = Console.ReadKey().Key;
            switch (mainMenuchoice)
            {
                case ConsoleKey.D0:
                    return false;
                case ConsoleKey.D1:
                    selector.SelectGame();
                    break;
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.D3:
                    break;
            }
        }
        // Console.WriteLine();
        // Console.WriteLine();
        // Console.WriteLine();
        // Console.WriteLine();
        Console.ReadKey();
        Console.Clear();
        return true;
    }
}
