public class User()
{
    public required string Username {get; set;}
    public required string Password {get; set;}//TODO: add layer of crypto to passwords
}