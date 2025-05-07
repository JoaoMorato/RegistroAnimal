using AuthRepository.Context;
using AuthService;
using Microsoft.EntityFrameworkCore;
using RepositoryUtil;
using Util;
using Util.AppService;

namespace AuthController;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Configuration.AddJsonFile("appsettings.json", false, true);
        builder.Configuration.AddJsonFile($"appsettings.{(builder.Environment.IsDevelopment() ? "Development" : "Production")}.json", true, true);

        var conn = builder.Configuration.GetConnectionString("Db");

        builder.Services.AddSqlServer<AuthContext>(conn);
        builder.Services.AddScoped(typeof(IAuthRepository<>), typeof(AuthRepository<>));
        
        builder.Services.ResgisterServices();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}
