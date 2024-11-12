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
            Console.WriteLine("Login project v 0.1");
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
                        Console.WriteLine("Logged in");//TODO: replace with logged in view
                    Console.WriteLine("Incorrect login");
                    continue;

                case ConsoleKey.D2:
                    lac.CreateUser();
                    break;
                case ConsoleKey.D0:
                    exit = true;
                    break;
            }
        }

    }
}
