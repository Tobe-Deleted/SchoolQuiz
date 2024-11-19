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
    public int EnglishScore{get; set;}
    public int aScore {get; set;}
    public int bScore {get; set;}
    public int cScore {get; set;}
    public int dScore {get; set;}
    public int eScore {get; set;}
    public int fScore {get; set;}

    //Scores added incase it's needed for future updates
    
}