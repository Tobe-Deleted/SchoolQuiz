using System.Xml.Serialization;
using UserSaveLoader.Data;

public class LeaderBoard()
{
    SaveLoadUser slu = new SaveLoadUser();
    public void LeaderBoardMain()
    {
        List<UserInfo> users = slu.LoadUserInfo();
        int scoreBoard = 0;
        while (true)
        {
            if (scoreBoard < 0) scoreBoard = 2;
            if (scoreBoard > 2) scoreBoard = 0;
            Console.Clear();
            switch (scoreBoard)
            {
                case 0:
                    Console.WriteLine("~~Ledertavle Total Score~~");
                    users = users.OrderBy(x => x.TotalScore).Reverse().ToList();
                    break;
                case 1:
                    Console.WriteLine("~~Ledertavle Matte Score~~");
                    users = users.OrderBy(x => x.MathScore).Reverse().ToList();
                    break;
                case 2:
                    Console.WriteLine("~~Ledertavle Engelsk Score~~");
                    users = users.OrderBy(x => x.EnglishScore).Reverse().ToList();
                    break;
            }
            Console.WriteLine("----------------------------------------------------------------------------------------");
            for(int i = 0; i < users.Count(); i++)
            {
                Console.Write($"{i+1}. ");
                Console.ForegroundColor = ConsoleColor.Red;
                switch (scoreBoard)
                {   
                    case 0:
                        Console.Write($"{users[i].TotalScore}   ");
                        break;
                    case 1:
                        Console.Write($"{users[i].MathScore}   ");
                        break;
                    case 2:
                        Console.Write($"{users[i].EnglishScore}   ");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{users[i].Username}");
                Console.ResetColor();
                if (i > 8) break;
            }
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("Bruk venste pil <- eller høyre pil -> for å navigere ledertavler");
            Console.WriteLine("0. Avslutt");
            ConsoleKey leaderboardNavigation = Console.ReadKey().Key;
            switch(leaderboardNavigation)
            {
                case ConsoleKey.LeftArrow:
                    scoreBoard--;
                    break;
                case ConsoleKey.RightArrow:
                    scoreBoard++;
                    break;
                case ConsoleKey.D0:
                    return;
            }
        }

    }
}