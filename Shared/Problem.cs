namespace codedash.Shared;

public class Problem
{
    public string? Id { get; set; }
    public string? Chunks { get; set; }
    public string? Output { get; set; }
    public string? Title { get; set; }
    public int Difficulty { get; set; }
    public bool IsUserMade { get; set; }
}