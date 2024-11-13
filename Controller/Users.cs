using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;
using UserSaveLoader.Data;
public class LoginAndCreation()
{
    Checks checks = new Checks();
    SaveLoadUser slu = new SaveLoadUser();
    Encryption crypto = new Encryption();
    public void CreateUser()
    {
        bool userCreated = false;
        string username = "!";
        string password = "";
        while(!userCreated) // User loop TODO: check if needed
        {
            string validChars = "abcdefghjiklmnopqrstuvwxyzæøå1234567890";
            bool validName = false;
            bool numberOrSpecialChar = false;
            bool capitalLetter = false;
            bool match = false;
            while(!validName) // Username loop
            {
                validName = true;
                Console.Clear();
                Console.WriteLine("~~User Creation~~");
                Console.Write("Username: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                username = Console.ReadLine() ?? "!";
                Console.ResetColor();
                username = username.ToLower();
                if (slu.LoadUser(username).Username != "!")
                {
                    Console.WriteLine("Username is already in use");
                    if (checks.BackToMain())
                        return;
                    validName = false;
                }
                else if (username.Length > 2)
                {   
                    foreach (char ch in username)
                    {
                        if (!validChars.Contains(ch))
                        {
                            Console.WriteLine("Username can only contain numbers or letters");
                            if (checks.BackToMain())
                                return;
                            validName = false;
                        }
                    }
                }
                else 
                {
                Console.WriteLine("Username must contain 3 or more characters");
                if (checks.BackToMain())
                    return;
                validName = false;
                }

            }

            while (!numberOrSpecialChar || !capitalLetter || !match)
            {
                Console.Clear();
                Console.WriteLine("~~User Creation~~");
                Console.Write("Username: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(username);
                Console.ResetColor();
                Console.Write("Password: ");
                password = Console.ReadLine() ?? "!";
                if (password.Length > 6)
                {
                    foreach (char ch in "1234567890!@#¤%&/()=?+}][{€$£@-_,;:.^¨~* '")
                    {
                        if(password.Contains(ch))
                        {
                            numberOrSpecialChar = true;
                            break;
                        }
                    }
                    foreach (char ch in "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ")
                    {

                        if(password.Contains(ch))
                        {
                            capitalLetter = true;
                            break;
                        }
                    }
                    if(!numberOrSpecialChar || !capitalLetter) 
                    {
                        Console.WriteLine("Password must contain at least one capital letter and a number or special symbol\n");
                        if (checks.BackToMain())
                            return;
                    }
                }
                else 
                {
                    Console.WriteLine("Password must be more than 6 characters long");
                    if (checks.BackToMain())
                        return;
                }
                if (capitalLetter && numberOrSpecialChar)
                {
                    Console.Write("Type password again: ");
                    if (password == Console.ReadLine())
                        match = true;
                    else 
                    {
                        Console.WriteLine("The passwords did not match");
                        if(checks.BackToMain())
                            return;
                    }
                }

            }
            if (capitalLetter && numberOrSpecialChar && validName) userCreated = true;
        }
        User user = new User{Username = username, Password = crypto.Hashed(password)};
        slu.SaveUser(user, username);
        Console.Clear();
        Console.WriteLine("User created");
        Console.WriteLine("Press any key to proceed");
        Console.ReadKey();
    }

    public bool LogIn(string username, string password)
    {
        User user = slu.LoadUser(username);
        if(crypto.Hashed(password) == user.Password && user.Username != "!") return true; 
        return false;
    }
}