namespace BusinessLogic.DTOS.Account;

public class CreateStudio
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? StudioPhone { get; set; }
    public string? StudioEmail { get; set; }
    
}