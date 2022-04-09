namespace codedash.Shared;

public class Problem
{
    public Guid Id { get; set; }
    public string? Chunks { get; set; }
    public string? Title { get; set; }
    public int Difficulty { get; set; }
}