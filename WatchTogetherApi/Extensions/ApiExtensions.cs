using WatchTogetherApi.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using WatchTogether.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WatchTogetherDataAccess;
using WatchTogetherCore.Models;
using System;
using WatchTogetherDataAccess.Entities;

namespace WatchTogetherApi.Extensions
{
    public static class ApiExtensions 
    {
        public static void ControllerExtensions(this IServiceCollection services, IConfiguration configuration) 
        {

            var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

            services.AddAuthorization();

            services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme)
                .AddBearerToken(IdentityConstants.BearerScheme);


            services.AddIdentityCore<UserEntity>()
                .AddEntityFrameworkStores<WatchTogetherIdentityDbContext>()
                .AddApiEndpoints();
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => 
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions!.SecretKey))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                         {

                             context.Token = context.Request.Cookies["Tasty-cookies"];

                             return Task.CompletedTask;
                         }
                    };
                });

            services.AddAutoMapper(typeof(WatchTogetherMappingProfile));
        }
    }
}
