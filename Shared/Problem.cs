namespace codedash.Shared;

public struct ProblemBlank {
    public int Line {get; set;}
    public int Column {get; set;}
    public int Length {get; set;}
}
public struct Problem {
    public string Output {get; set;}
    public string Source {get; set;}
    
    // Info per blank.
    public List<ProblemBlank> Blanks {get; set;}
    
    public Problem() {
        Source = "";
        Output = "";
        Blanks = new List<ProblemBlank>();
    }
}