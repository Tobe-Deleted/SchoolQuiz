public class User()
{
    public required string Username {get; set;}
    public required string Password {get; set;}
    public string? Role {get; set;}//TODO: Add function for admin roles to change passwords
}