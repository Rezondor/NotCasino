using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TWD.NotCasino.Api.Base.Services;
using TWD.NotCasino.Api.Core.Dtos;
using TWD.NotCasino.Api.Core.Requests.User;
using TWD.NotCasino.Api.Core.Services;
using TWD.NotCasino.Api.Mappings;
using TWD.NotCasino.Core.Entities;
using TWD.NotCasino.Domain.Base;
using TWD.NotCasino.Domain.Core;
using TWD.NotCasino.Domain.Core.Repositories;

namespace TWD.NotCasino.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<RequestProfile>();
        });

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<IPasswordHasher<ForHashModel>, PasswordHasher<ForHashModel>>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<INotCasinoRepositoryManager, NotCasinoRepositoryManager>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(NotCasino.Base.MediatRMarker).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(NotCasino.Games.Base.MediatRMarker).Assembly);
        });

        builder.Services
            .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(o =>
            {
                o.Cookie.Name = "auth.session";
                o.Cookie.HttpOnly = true;
                o.Cookie.SameSite = SameSiteMode.Lax; // ≈сли фронт на другом домене Ч см. ниже заметку
                o.Cookie.SecurePolicy = CookieSecurePolicy.Always; // в проде под HTTPS
                o.LoginPath = "/api/auth/login";   // не об€зателен дл€ API, но пусть будет
                o.LogoutPath = "/api/auth/logout"; // тоже не об€зателен
                o.SlidingExpiration = true;
                o.ExpireTimeSpan = TimeSpan.FromDays(14);
            });

        builder.Services.AddDbContext<NotCasinoContext>(
            options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly("TWD.NotCasino.Domain.Base.Postgres")));

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
