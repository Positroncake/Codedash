namespace codedash.Shared;

public class Account
{
    public Guid Id { get; set; }
    public string? UsernameHash { get; set; }
    public string? PasswordHash { get; set; }
    public string? DisplayName { get; set; }
}