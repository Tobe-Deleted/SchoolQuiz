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
            ConsoleKey LoggedOutChoice = Console.ReadKey().Key;
            switch (LoggedOutChoice)
            {
                case ConsoleKey.D1:
                    break;
                case ConsoleKey.D2:
                    lac.CreateUser();
                    //lac.LogIn();
                    break;
                case ConsoleKey.D0:
                    exit = true;
                    break;
            }
        }

    }
}
