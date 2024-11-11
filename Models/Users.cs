public class User()
{
    public required string username {get; set;}
    public required string password {get; set;}//TODO: add layer of crypto to passwords
}