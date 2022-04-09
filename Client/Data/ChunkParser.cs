using System;
using System.Linq;
using codedash.Shared;

namespace codedash.Client.Data;

public class ProblemBlock
{
    public string Content { get; set; }
    public bool IsInput { get; set; }
    public int? FieldLength { get; set; }

    public static List<ProblemBlock> ParseProblemString(string str)
    {
        Console.WriteLine(str.Split('\u001E').Length);
        return str.Split('\u001E').Select(r =>
        {
            string[] fields = r.Split('\u001F');
            
            ProblemBlock block = new()
            {
                Content = fields[0],
                IsInput = ((Func<bool>)(() =>
                {
                    if (str == "1") return true;
                    if (str == "0") return false;
                    throw new ArgumentException($"Invalid boolean {str}");
                }))(),
                FieldLength = ((Func<int?>) (() =>
                {
                    int x = int.Parse(fields[2]);
                    return (x < 0) ? null : x;
                }))()
            };
            return block;
        }).ToList();
    }
}