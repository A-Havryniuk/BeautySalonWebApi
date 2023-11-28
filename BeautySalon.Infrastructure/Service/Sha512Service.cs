using System.Security.Cryptography;
using System.Text;
using BeautySalon.Application.Service.Interfaces;

namespace BeautySalon.Infrastructure.Service;

public class Sha512Service : IHashService
{
    public string GetHash(string input)
    {
        using SHA512 sha512 = SHA512.Create();
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] hashBytes = sha512.ComputeHash(inputBytes);

        StringBuilder sb = new StringBuilder();
        foreach (byte b in hashBytes)
        {
            sb.Append(b.ToString("x2"));
        }
        return sb.ToString();
    }

    public bool VerifyHash(string input, string hash)
    {
        string inputHash = GetHash(input);
        return StringComparer.OrdinalIgnoreCase.Compare(inputHash, hash) == 0;
    }
}