using Library_MinimalAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library_MinimalAPI.Services;

public class TokenService
{
    private readonly IConfiguration _config;

    public TokenService(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateToken(Customer customer)
    {
        Claim[] claims =
        {
            new Claim("id", customer.Id),
            new Claim("firstName", customer.FirstName),
            new Claim("lastName", customer.LastName),
            new Claim("username", customer.NormalizedUserName!)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
             _config["SymmetricSecurityKeyLibrary"]));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.Aes128CbcHmacSha256);

        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
