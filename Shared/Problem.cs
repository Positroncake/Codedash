namespace Codedash.Shared;

public class Problem
{
    public String? Id { get; set; }
    public String? Chunks { get; set; }
    public String? Output { get; set; }
    public String? Title { get; set; }
    public Int32 Difficulty { get; set; }
    public Boolean IsUserMade { get; set; }
}