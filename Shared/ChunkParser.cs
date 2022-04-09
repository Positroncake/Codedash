using System;
using System.Linq;
using System.Text.Json;
using codedash.Shared;

namespace codedash.Shared;

public class ProblemBlock
{
    public string Content { get; set; }
    public bool IsInput { get; set; }
    public int? FieldLength { get; set; }

    public static List<ProblemBlock> ParseProblemString(string str)
    {
        return str.Split('\u001E').Select(r =>
        {
            string[] fields = r.Split('\u001F');
            Console.WriteLine(JsonSerializer.Serialize(fields));
            ProblemBlock block = new()
            {
                Content = fields[0],
                IsInput = ((Func<bool>)(() =>
                {
                    if (fields[1] == "1") return true;
                    if (fields[1] == "0") return false;
                    throw new ArgumentException($"Invalid boolean {fields[1]}");
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