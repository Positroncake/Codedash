using System.Security.Cryptography;
using System.Text;

namespace codedash.Shared;

public class TokenGen
{
    public static string GenerateToken()
    {
        var stringBuilder = new StringBuilder(512);
        for (var i = 0; i < 512; ++i) stringBuilder.Append((char) RandomNumberGenerator.GetInt32(33, 127));
        return stringBuilder.ToString();
    }
}