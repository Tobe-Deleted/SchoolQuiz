using UserSaveLoader.Data;
public class LoginAndCreation()
{
    public SaveLoadUser slu = new SaveLoadUser();
    public void CreateUser()
    {
        bool userCreated = false;
        string username = "!";
        string password = "";
        while(!userCreated) // User loop TODO: check if needed
        {
            string validChars = "abcdefghjiklmnopqrstuvwxyzæøå1234567890";
            bool validName = false;
            bool validPassword = false;
            while(!validName) // Username loop
            {
                validName = true;
                Console.Clear();
                Console.WriteLine("~~User creation~~");
                Console.Write("Username: ");
                username = Console.ReadLine() ?? "!";
                username = username.ToLower();
                if (false/*User already exists*/) //TODO: make a check for username
                {
                    Console.WriteLine("Username is already in use");
                    Console.ReadKey();
                }
                else if (username.Length > 2)
                {   
                    foreach (char ch in username)
                    {
                        if (!validChars.Contains(ch))
                        {
                            validName = false;
                            Console.WriteLine("Username can only contain numbers or letters");
                            Console.ReadKey();
                            break;
                        }
                    }
                }
                else 
                {
                Console.WriteLine("Username must contain 3 or more characters");
                Console.ReadKey();
                }

            }

            while (!validPassword)
            {
                Console.Clear();
                Console.WriteLine("~~User Creation~~");
                Console.WriteLine($"Username: {username}");
                Console.Write("Password: ");
                password = Console.ReadLine() ?? "!";
                if (password.Length > 6)
                {
                    foreach (char ch in "1234567890!@#¤%&/()=?+}][{€$£@-_,;:.^¨~* '")
                    {
                        if(password.Contains(ch))
                        {
                            validPassword = true;
                            break;
                        }
                    }
                    foreach (char ch in "1234567890")
                    {
                        if(password.Contains(ch))
                        {
                            validPassword = true;
                            break;
                        }
                        validPassword = false;
                    }
                    foreach (char ch in "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ")
                    {
                        if(password.Contains(ch))
                        {
                            validPassword = true;
                            break;
                        }
                        validPassword = false;
                    }
                }
                else Console.WriteLine("Password must be more than 6 characters long");
                if(!validPassword) Console.WriteLine("Password must contain at least one capital letter, number and special symbol\n");
                Console.ReadKey();
            }
            if (validPassword && validName) userCreated = true;
        }
        User user = new User{Username = username, Password = password};
        slu.SaveUser(user, username);
        Console.Clear();
        Console.WriteLine("User created");
        Console.WriteLine("Proceed to login");
        Console.ReadKey();

    }

    public bool LogIn(string username, string password)
    {
        if (username == "!" || password == "!") return false;
        User user = slu.LoadUser(username);
        if(password == user.Password) return true;
        return false;
    }
}