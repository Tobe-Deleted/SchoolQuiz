public class Games
{
    public void MathGame()
    {
        Random rnd = new Random();
        int a; int b; int c; int d; int e;
        while(true)
        {
            int lives = 3;
            int score = 0;
            for(int i = 0; i < 10; i++)
            {
                Console.Clear();
                Console.WriteLine("~~Mattematikk: Første nivå - 1 poeng per rett~~");

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
                a = rnd.Next(0, i); b = rnd.Next(0, i);
                Console.Write($"{a} * {b} = ");
                string input = Console.ReadLine() ?? "-1";
                try
                {
                    if(a * b == Convert.ToInt32(input))
                        score++;
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
            UserInfo ui = new UserInfo();
        }


    }
}