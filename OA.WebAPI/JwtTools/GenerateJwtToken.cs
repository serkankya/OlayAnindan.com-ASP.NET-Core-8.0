using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OA.WebAPI.JwtTools
{
    public class GenerateJwtToken
    {
        readonly IConfiguration _configuration;

        public GenerateJwtToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Generate(int userId)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            // SecretKey için null kontrolü ekleyin
            var secretKey = jwtSettings["SecretKey"];
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("SecretKey is missing from configuration.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Expiry süresi için DateTime'u doğru şekilde ayarlayın
            var expiryInMinutes = Convert.ToInt32(jwtSettings["ExpiryInMinutes"]);
            var expires = DateTime.UtcNow.AddMinutes(expiryInMinutes);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: new List<Claim>
                {
                    new Claim("userId", userId.ToString())  // Kullanıcı ID'sini claim olarak ekledik
                },
                expires: expires,  // Expiry doğru şekilde ayarlandı
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
