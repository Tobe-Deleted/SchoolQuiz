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
            if (scoreBoard < 0) scoreBoard = 1;
            if (scoreBoard > 1) scoreBoard = 0;
            Console.Clear();
            switch (scoreBoard)
            {
                case 0:
                    Console.WriteLine("~~Ledertavle Total Poeng~~");
                    users = users.OrderBy(x => x.TotalScore).Reverse().ToList(); //TODO: fix sorting
                    break;
                case 1:
                    Console.WriteLine("~~Ledertavle Matte Poeng~~");
                    users = users.OrderBy(x => x.MathScore).Reverse().ToList(); //TODO: fix sorting
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
                        if(scoreBoard == 0) Console.Write($"{users[i].TotalScore}   ");
                        break;
                    case 1:
                        if(scoreBoard == 1) Console.Write($"{users[i].MathScore}   ");
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