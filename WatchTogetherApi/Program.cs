using WatchTogetherDataAccess;
using Microsoft.EntityFrameworkCore;
using WatchTogetherDataAccess.Repositories;
using WatchTogetherApplication.Services;
using WatchTogether.Infrastructure;
using WatchTogetherApi.Extensions;
using Microsoft.Extensions.Options;
using WatchTogetherCore.Models;
using WatchTogetherDataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace WatchTogetherApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

           // builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddAuthorization();
            //builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme)
            //    .AddBearerToken(IdentityConstants.BearerScheme);

            //builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<WatchTogetherIdentityDbContext>()
            //     .AddSignInManager()
            //    .AddDefaultTokenProviders();


            /*

            builder.Services.AddAuthentication(o => 
            { 
                o.DefaultScheme = IdentityConstants.ApplicationScheme;
                o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            }).AddIdentityCookies(o => 
            {
                o.ApplicationCookie?.Configure(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                    options.LoginPath = new PathString("/login");

                    options.AccessDeniedPath = new PathString("/Errors?status=404");
                    options.SlidingExpiration = true;
                });
            });
            */

            /*
            builder.Services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<WatchTogetherIdentityDbContext>()
                .AddApiEndpoints();

            */

            builder.Services.AddLogging();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IIndexRepository, IndexRepository>();
            builder.Services.AddScoped<IIndexService, IndexService>();
            builder.Services.AddScoped<IUserService, UserService>();
            

            builder.Services.AddScoped<IJwtProvider, JwtProvider>();
            builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

            builder.Services.ControllerExtensions(builder.Configuration); //Extension

            //builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<WatchTogetherIdentityDbContext>()
            //    .AddSignInManager().AddDefaultTokenProviders();
            //builder.Services.AddIdentityApiEndpoints<IdentityUser>()
            // .AddEntityFrameworkStores<WatchTogetherIdentityDbContext>();



            //Adding Identity Endpoints
            //builder.Services.AddIdentityApiEndpoints<User>()
            //   .AddEntityFrameworkStores<WatchTogetherIdentityDbContext>();

            
            builder.Services.AddDbContext<WatchTogetherDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:WatchTogetherConnectionString"]
                    );
            });
            
            builder.Services.AddDbContext<WatchTogetherIdentityDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:WatchTogetherConnectionString"]);
            });

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.MapIdentityApi<UserEntity>();
            app.UseCors(x =>
            {
                x.WithHeaders().AllowAnyHeader();
                x.WithOrigins("http://localhost:3000");
                x.WithMethods().AllowAnyMethod();
            });
            app.Run();
        }
    }
}
