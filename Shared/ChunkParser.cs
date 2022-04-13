using System.Text.Json;

namespace Codedash.Shared;

public class ProblemBlock
{
    public String? Content { get; set; }
    public Boolean IsInput { get; set; }
    public Int32? FieldLength { get; set; }

    public static List<ProblemBlock> ParseProblemString(String str)
    {
        return str.Split('\u001E').Select(r =>
        {
            String[] fields = r.Split('\u001F');
            Console.WriteLine(JsonSerializer.Serialize(fields));
            ProblemBlock block = new()
            {
                Content = fields[0],
                IsInput = ((Func<Boolean>)(() =>
                {
                    if (fields[1] == "1") return true;
                    if (fields[1] == "0") return false;
                    throw new ArgumentException($"Invalid boolean {fields[1]}");
                }))(),
                FieldLength = ((Func<Int32?>) (() =>
                {
                    Int32 x = Int32.Parse(fields[2]);
                    return (x < 0) ? null : x;
                }))()
            };
            return block;
        }).ToList();
    }
}