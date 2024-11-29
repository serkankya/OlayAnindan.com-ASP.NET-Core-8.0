﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace OA.WebAPI.JwtTools
{
    public static class JwtSettings
    {
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];

            // SecretKey için null kontrolü ekleyin
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("JwtSettings: SecretKey is missing or empty.");
            }

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))  // secretKey doğru şekilde kullanılıyor
                };

                // Hata mesajlarını düzgün bir şekilde almak için event handler eklenebilir
                opt.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        // Authentication failed durumunda hata loglaması yapabilirsiniz
                        Console.WriteLine("Authentication failed: " + context.Exception.Message);
                        return Task.CompletedTask;
                    },
                    OnChallenge = context =>
                    {
                        // Challenge durumunda hata loglaması yapabilirsiniz
                        Console.WriteLine("Authentication challenge: " + context.ErrorDescription);
                        return Task.CompletedTask;
                    }
                };
            });
        }
    }
}
