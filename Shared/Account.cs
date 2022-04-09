namespace codedash.Shared;

public class Account
{
    public string? Id { get; set; }
    public string? UsernameHash { get; set; }
    public string? PasswordHash { get; set; }
    public string? DisplayName { get; set; }
    public int Solved { get; set; }
    public decimal AverageTime { get; set; }
    public int SubmissionsNum { get; set; }
    public string? Submissions { get; set; }
    public DateTime RegistrationDate { get; set; }
}