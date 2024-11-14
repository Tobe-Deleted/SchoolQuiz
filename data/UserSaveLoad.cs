using System.Runtime.CompilerServices;
using System.Text.Json;

namespace UserSaveLoader.Data
{
    public class SaveLoadUser
    {
        private readonly string loginFilepath = "data/UserLogin/";
        private readonly string infoFilepath = "data/UserInfo/Scores.json";
        public void SaveUser(UserLogin NewUser, string username)
        {
            string json = JsonSerializer.Serialize(NewUser);
            File.WriteAllText(loginFilepath + username + ".json", json);
        }

        public UserLogin LoadUser(string username)
        {
            if(File.Exists(loginFilepath + username + ".json"))
            return JsonSerializer.Deserialize<UserLogin>(File.ReadAllText(loginFilepath + username + ".json"))
                   ?? new UserLogin{Username = "!", Password = "!"};
            return new UserLogin{Username = "!", Password = "!"};
        }
        public void SaveUserInfo(UserInfo NewUserInfo)
        {
            string json = JsonSerializer.Serialize(NewUserInfo);
            File.WriteAllText(infoFilepath, json);
        }
        public UserInfo LoadUserInfo(string username)
    }
}