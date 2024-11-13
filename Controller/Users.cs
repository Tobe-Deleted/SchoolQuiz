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
                Console.WriteLine("~~Lag Bruker~~");
                Console.Write("Brukernavn: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                username = Console.ReadLine() ?? "!";
                Console.ResetColor();
                username = username.ToLower();
                if (slu.LoadUser(username).Username != "!")
                {
                    Console.WriteLine("Brukernavn er allerede i bruk");
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
                            Console.WriteLine("Brukernavn kan kun inneholde bokstaver og tall");
                            if (checks.BackToMain())
                                return;
                            validName = false;
                        }
                    }
                }
                else 
                {
                Console.WriteLine("Brukernavn må inneholde minst 3 tegn");
                if (checks.BackToMain())
                    return;
                validName = false;
                }

            }

            while (!numberOrSpecialChar || !capitalLetter || !match)
            {
                Console.Clear();
                Console.WriteLine("~~Lag Bruker~~");
                Console.Write("Brukernavn: ");
                Console.ForegroundColor = ConsoleColor.Yellow;//Just testing
                Console.WriteLine(username);
                Console.ResetColor();
                Console.Write("Passord: ");
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
                        Console.WriteLine("passord må inneholde minst én stor bokstav og et spesialtegn eller nummer\n");
                        if (checks.BackToMain())
                            return;
                    }
                }
                else 
                {
                    Console.WriteLine("Passord må være mer enn 6 tegn langt");
                    if (checks.BackToMain())
                        return;
                }
                if (capitalLetter && numberOrSpecialChar)
                {
                    Console.Write("Skriv inn passord på nytt: ");
                    if (password == Console.ReadLine())
                        match = true;
                    else 
                    {
                        Console.WriteLine("Passordet var ikke skrevet inn likt");
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
        Console.WriteLine("Bruker lagret!");
        Console.WriteLine("Trykk en knapp for å fortsette");
        Console.ReadKey();
    }

    public bool LogIn(string username, string password)
    {
        User user = slu.LoadUser(username);
        if(crypto.Hashed(password) == user.Password && user.Username != "!") return true; 
        return false;
    }
}