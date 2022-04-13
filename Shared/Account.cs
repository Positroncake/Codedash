namespace Codedash.Shared;

public class Account
{
    public String? Id { get; set; }
    public String? UsernameHash { get; set; }
    public String? PasswordHash { get; set; }
    public String? DisplayName { get; set; }
    public Int32 Solved { get; set; }
    public Decimal AverageTime { get; set; }
    public Int32 SubmissionsNum { get; set; }
    public String? Submissions { get; set; }
    public DateTime RegistrationDate { get; set; }
}