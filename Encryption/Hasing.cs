using System.Security.Cryptography;
public class Encryption()
{
    //May cause collisions, but not very likely
    public string Hashed(string password)
    {
        string hash = "";
        
        List<int> hashAlgo1 = new List<int>{};
        foreach (char ch in password)
        {
            hashAlgo1.Add(Convert.ToInt32(ch));
            if (hashAlgo1.Sum() > 137)
            {
                hash += Convert.ToString(Convert.ToChar(hashAlgo1.Sum() % 137));
                hashAlgo1 = new List<int> {hashAlgo1.Sum()};
            }
        }
        hash += Convert.ToString(hashAlgo1.Sum() % 3 * 15);
        return hash;
    }
}