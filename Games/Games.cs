using System.Diagnostics;
using UserSaveLoader.Data;

public class Games
{
    public void MathGame(string username)
    {
        SaveLoadUser slu = new SaveLoadUser();
        List<UserInfo> UserInfoList = slu.LoadUserInfo();
        UserInfo CurrentUser = UserInfoList.Find(x => x.Username == username) 
                            ?? new UserInfo{Username = username, MathScore = 0};
        Random rnd = new Random();
        int a; int b; int c; int d; int e;
        while(true)
        {
            int lives = 3;
            int score = 0;
            for(int i = 1; i <= 10; i++)
            {
                if(lives > 1) break;
                Console.Clear();
                Console.WriteLine("~~Mattematikk: Første nivå - 1 poeng per rett svar~~");

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
                a = rnd.Next(0, 11); b = rnd.Next(0, 11);
                Console.Write($"Oppgave {i}: {a} * {b} = ");
                string input1 = Console.ReadLine() ?? "-1";
                try
                {
                    if(a * b == Convert.ToInt32(input1))
                        score++;
                    else
                        lives--;

                }
                catch(FormatException)
                {
                    lives--;
                }
                    
            }
            for(int i = 1; i <= 10; i++)
            {
                if(lives > 1) break;
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
                a = rnd.Next(0, 11); b = rnd.Next(0, 11); c= rnd.Next(0,11);
                Console.Write($"Oppgave {i}: {a} * {b} * {c} = ");
                string input2 = Console.ReadLine() ?? "-1";
                try
                {
                    if(a * b == Convert.ToInt32(input2))
                        score += 2;
                    else
                        lives--;

                }
                catch(FormatException)
                {
                    lives--;
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
            Console.WriteLine("------------------------------------------------------------------------------------");
            if (score > CurrentUser.MathScore) 
            {
                CurrentUser.MathScore = score;
                CurrentUser.TotalScore = CurrentUser.MathScore;//UPDATE: Må oppdateres med fremtidige scores
                Console.WriteLine($"Ny Highscore! Din nye highscore er {CurrentUser.MathScore}");
            }
            Checks checks = new Checks();
            if (checks.BackToMain("Vil du starte et nytt spill?"))
                return;
        }


    }
}