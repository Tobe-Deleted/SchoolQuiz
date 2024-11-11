using System.Runtime.CompilerServices;
using System.Text.Json;

namespace UserSaveLoader.Data
{
    public class SaveLoadUser
    {
        private readonly string filepath = "data/";
        public void SaveUser(User Newuser, string username)
        {
            string json = JsonSerializer.Serialize(Newuser);
            File.WriteAllText(filepath + username + ".json", json);
        }

        public User LoadUser(string username)
        {
            return JsonSerializer.Deserialize<User>(File.ReadAllText(filepath + username + ".json"))
                    ?? new User;
        }
    }
}