using System.Security.Cryptography;
public class Crypto()
{
    public string Hashed(string password)
    {
        string hash = "";
        
        List<int> hashAlgo1 = new List<int>{};
        foreach (char ch in password)
        {
            hashAlgo1.Add(Convert.ToInt32(ch));
        }
        return hash;
    }
}