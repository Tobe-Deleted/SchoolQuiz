using System.Runtime.CompilerServices;
using System.Text.Json;

namespace UserSaveLoader.Data
{
    public class SaveLoadUser
    {
        private readonly string loginFilepath = "data/UserLogin/";
        public void SaveUser(User Newuser, string username)
        {
            string json = JsonSerializer.Serialize(Newuser);
            File.WriteAllText(loginFilepath + username + ".json", json);
        }

        public User LoadUser(string username)
        {
            return JsonSerializer.Deserialize<User>(File.ReadAllText(loginFilepath + username + ".json"));
            //      ?? new User;
            //TODO: figure out why I can't return new user
        }
    }
}