public class User()
{
    public string UserID {"00001"};
    public required string Username {get; set;}
    public required string Password {get; set;}//TODO: add layer of crypto to passwords
}