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
            Console.WriteLine("Login project v 0.5");
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Create new user");
            Console.WriteLine("0. Exit");
            ConsoleKey MainMenuChoice = Console.ReadKey().Key;
            switch (MainMenuChoice)
            {
                case ConsoleKey.D1:
                    string username;
                    string password;
                    Console.Clear();
                    Console.WriteLine("~~Log in~~");
                    Console.Write("Enter Username: ");
                    username = Console.ReadLine() ?? "!";
                    Console.Write("Enter password: ");
                    password = Console.ReadLine() ?? "!";
                    if (lac.LogIn(username, password))
                    {
                        exit = LoginMainView(username);
                        
                    }
                    else 
                    {
                        Console.WriteLine("Incorrect login");
                        Console.ReadKey();
                    }
                    break;

                case ConsoleKey.D2:
                    lac.CreateUser();
                    break;
                case ConsoleKey.D0:
                    exit = true;
                    break;
            }
        }
    }

    static bool LoginMainView(string user)
    {
        Console.WriteLine("You've successfully logged in");
        Console.WriteLine("Content will come in the future");
        Console.ReadKey();
        Console.Clear();
        return true;
    }
}
