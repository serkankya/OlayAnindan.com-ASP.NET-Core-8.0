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
			var secretKey = jwtSettings["SecretKey"];
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: jwtSettings["Issuer"],
				audience: jwtSettings["Audience"],
				claims: new List<Claim> { new Claim(ClaimTypes.Name, userId.ToString()) },
				expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryInMinutes"])),
				signingCredentials: creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
