using System.Diagnostics;
using UserSaveLoader.Data;

public class Games
{
    public void MathGame(string username)
    {
        SaveLoadUser slu = new SaveLoadUser();
        List<UserInfo> UserInfoList = slu.LoadUserInfo();
        UserInfo CurrentUser = UserInfoList.Find(x => x.Username == username.ToLower()) 
                            ?? new UserInfo
                            {Username = username, TotalScore = 0, MathScore = 0, EnglishScore = 0,
                             aScore = 0, bScore = 0, cScore = 0, dScore = 0, eScore = 0, fScore = 0};
                             //added a bunch of scores to avoid corrupting future user profiles when program is updated
        
        Random rnd = new Random();
        int a; int b; int c; /*int d; int e;*/
        while(true)
        {
            int lives = 3;
            int score = 0;
            for(int i = 1; i <= 10; i++)
            {

                if(lives < 1) break;
                Console.Clear();
                Console.WriteLine("~~Mattematikk: Første nivå: 1 poeng per rett svar~~");
                Console.Write($"Du har ");
                Console.ForegroundColor = ConsoleColor.Green;
                if (lives < 2)Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{lives}");
                Console.ResetColor();
                Console.Write(" liv || Du har ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{score}");
                Console.ResetColor();
                Console.WriteLine(" poeng!");

                Console.WriteLine("------------------------------------------------------------------------------------");
                a = rnd.Next(2, 11); b = rnd.Next(2, 11);
                Console.Write($"Oppgave {i}: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{a} * {b} = ");
                Console.ResetColor();
                string input1 = Console.ReadLine() ?? "g";
                try
                {
                    if(a * b == Convert.ToInt32(input1))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Riktig!");
                        Console.ResetColor();
                        Console.Write("trykk en knapp for neste oppgave");
                        Console.ReadKey();
                        score++;
                    }
                    else
                    {
                        lives--;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"Feil. Svaret var ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{a * b}");
                        Console.ResetColor();
                        Console.Write("trykk en knapp for neste oppgave");
                        Console.ReadKey();
                    }

                }
                catch(FormatException)
                {
                    lives--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"Feil. Svaret var ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{a * b}");
                    Console.ResetColor();
                    Console.Write("trykk en knapp for neste oppgave");
                    Console.ReadKey();
                }
                    
            }
            for(int i = 1; i <= 10; i++)
            {
                if(lives < 1) break;
                Console.Clear();
                Console.WriteLine("~~Mattematikk: Andre nivå - 2 poeng per rett svar~~");

                Console.Write($"Du har ");
                Console.ForegroundColor = ConsoleColor.Green;
                if (lives < 2)Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{lives}");
                Console.ResetColor();
                Console.Write(" liv || Du har ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{score}");
                Console.ResetColor();
                Console.WriteLine(" poeng!");

                Console.WriteLine("------------------------------------------------------------------------------------");
                a = rnd.Next(2, 11); b = rnd.Next(2, 11); c = rnd.Next(2,11);
                Console.Write($"Oppgave {i}: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{a} * {b} * {c} = ");
                Console.ResetColor();
                string input2 = Console.ReadLine() ?? "g";
                try
                {
                    if(a * b * c == Convert.ToInt32(input2))
                    {
                        score += 2;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Riktig!");
                        Console.ResetColor();
                        Console.Write("trykk en knapp for neste oppgave");
                        Console.ReadKey();
                    }
                    else
                    {
                        lives--;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"Feil. Svaret var ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{a * b * c}");
                        Console.ResetColor();
                        Console.Write("trykk en knapp for neste oppgave");
                        Console.ReadKey();
                    }

                }
                catch(FormatException)
                {
                    lives--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"Feil. Svaret var ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{a * b * c}");
                    Console.ResetColor();
                    Console.Write("trykk en knapp for neste oppgave");
                    Console.ReadKey();
                }

            }
            Console.Clear();
            Console.WriteLine("~~Game Over~~");
            Console.WriteLine("------------------------------------------------------------------------------------");    
            Console.Write("Du fikk ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{score}");
            Console.ResetColor();
            Console.WriteLine(" poeng!");
            if (score > CurrentUser.MathScore) 
            {
                CurrentUser.MathScore = score;
                CurrentUser.TotalScore = CurrentUser.MathScore;//UPDATE: Må oppdateres med fremtidige scores
                Console.WriteLine($"Ny Highscore! Din nye highscore er {CurrentUser.MathScore}");
                UserInfoList.Add(CurrentUser);
                slu.SaveUserInfo(UserInfoList);
            }
            else
                Console.WriteLine($"Ikke ny highscore. Din tidligere Highscore er {CurrentUser.MathScore}");
            Console.ReadKey();
            Checks checks = new Checks();
            if (checks.BackToMain("Vil du starte et nytt spill?"))
                return;
        }


    }
}