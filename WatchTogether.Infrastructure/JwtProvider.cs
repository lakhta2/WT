﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WatchTogetherCore.Models;

namespace WatchTogether.Infrastructure
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;
        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }
        public string GenerateToken(User user)
        {
            Claim[] claims = [new("userId", user.Id.ToString())];

            var signingCreditnails = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCreditnails,
                expires: DateTime.UtcNow.AddHours(_options.ExpiresHours));


            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }
}
