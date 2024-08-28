using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Monopoly.NewDAL.Entities;

namespace Monopoly.Service.Helpers;

public static class TokenHelper
{
    public static bool VerifyJwt(string token)
    {
        if (token == null)
        {
            return false;
        }
        var tokenHandler = new JwtSecurityTokenHandler();
        string secret = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
        var key = Encoding.UTF8.GetBytes(secret == null ? "12345678901234561234567890123456" : secret);

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
            ValidateAudience = true,
            ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero // Eliminace časové tolerance
        };

        try
        {
            var principal =
                tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

            // Dodatečná kontrola, zda je token správného typu
            if (validatedToken is JwtSecurityToken jwtToken && jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            //todo add log
        }

        return false;
    }

    public static string GenerateJwt(string email, string userId)
    {
        string s = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(s == null ? "12345678901234561234567890123456" : s));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: Environment.GetEnvironmentVariable("JWT_ISSUER"),
            audience: Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
            claims: claims,
            expires: DateTime.Now.AddDays(30),
            signingCredentials: creds);
        string jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}