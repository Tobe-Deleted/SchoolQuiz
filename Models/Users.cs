public class UserLogin()
{
    public required string Username {get; set;}
    public required string Password {get; set;}
    public string? Role {get; set;}//TODO: Add function for admin roles to change passwords
}
public class UserInfo()
{
    public required string Username {get; set;}
    public int MathScore {get; set;}
    public int TotalScore {get; set;}
    //More scores to come
    
}