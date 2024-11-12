using System.Runtime.CompilerServices;
using System.Text.Json;

namespace UserSaveLoader.Data
{
    public class SaveLoadUser
    {
        private readonly string loginFilepath = "data/UserLogin/";
        public void SaveUser(User NewUser, string username)
        {
            string json = JsonSerializer.Serialize(NewUser);
            File.WriteAllText(loginFilepath + username + ".json", json);
        }

        public User LoadUser(string username)
        {
            if(File.Exists(loginFilepath + username + ".json"))
            return JsonSerializer.Deserialize<User>(File.ReadAllText(loginFilepath + username + ".json"))
                   ?? new User{Username = "!", Password = "!"};
            return new User{Username = "!", Password = "!"};
        }
    }
}