using System.Security.Cryptography;
using System.Text;

namespace Codedash.Shared;

public class TokenGen
{
    public static String GenerateToken()
    {
        var stringBuilder = new StringBuilder(512);
        for (var i = 0; i < 512; ++i) stringBuilder.Append((Char) RandomNumberGenerator.GetInt32(33, 127));
        return stringBuilder.ToString();
    }
}