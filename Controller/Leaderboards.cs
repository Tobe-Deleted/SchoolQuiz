using UserSaveLoader.Data;

public class LeaderBoard()
{
    SaveLoadUser slu = new SaveLoadUser();
    public void LeaderBoardMain()
    {
        List<UserInfo> users = slu.LoadUserInfo();
        Console.Clear();
        Console.WriteLine("~~Ledertavle Total Poeng~~");
        Console.WriteLine("----------------------------------------------------------------------------------------");
        for(int i = 0; i < users.Count(); i++)
        {
            Console.Write($"{i+1}. ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{users[i].TotalScore}   ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{users[i].Username}");
            Console.ResetColor();
            if (i > 8) break;
        }
        Console.WriteLine("----------------------------------------------------------------------------------------");
        Console.ReadKey();
    }
}