using System.Security.Cryptography;
public class Encryption()
{
    //May cause collisions, but not very likely
    public string Hashed(string password)
    {
        string tempHash = "";
        string result = "";
        List<int> hashAlgo1 = new List<int>{};
        for (int i = 0; i < 10; i++)
        {
            if (i > 0) 
            {password = tempHash;
            result += password;}
            Console.WriteLine(password);
            Console.ReadKey();
            tempHash = "";
            foreach (char ch in password)
            {
                hashAlgo1.Add(Convert.ToInt32(ch));
                if (hashAlgo1.Sum() > 137)
                {
                    tempHash += Convert.ToString(Convert.ToChar(hashAlgo1.Sum() % 137));
                    hashAlgo1 = new List<int> {hashAlgo1.Sum()};
                }
            }
            tempHash += Convert.ToString(hashAlgo1.Sum() % 3 * 15);
            hashAlgo1 = new List<int>{};
        }
        return result;
    }
}