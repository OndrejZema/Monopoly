using System.Security.Cryptography;

namespace Monopoly.Service.Helpers;

public static class PasswordHelper
{
    public static string HashPassword(string password)
    {
        // Vytvoření náhodné soli
        byte[] salt = new byte[16];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }

        // Hashování hesla pomocí PBKDF2
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
        byte[] hash = pbkdf2.GetBytes(20);

        // Kombinace soli a hashe
        byte[] hashBytes = new byte[36];
        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 20);

        // Převod na string ve formátu Base64
        string hashedPassword = Convert.ToBase64String(hashBytes);

        return hashedPassword;
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        // Extrahování hashované hodnoty z base64
        byte[] hashBytes = Convert.FromBase64String(hashedPassword);

        // Extrahování soli
        byte[] salt = new byte[16];
        Array.Copy(hashBytes, 0, salt, 0, 16);

        // Hashování hesla znovu pomocí PBKDF2 s původní solí
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
        byte[] hash = pbkdf2.GetBytes(20);

        // Porovnání původního hashe s nově vytvořeným hashem
        for (int i = 0; i < 20; i++)
            if (hashBytes[i + 16] != hash[i])
                return false;

        return true;
    }
}