using pincodeApi.Entities.Controllers.Repo;
using MySqlConnector;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFramework;
using System.Configuration;

public class Startup
{
    public IConfiguration configRoot
    {
        get;
    }
    public Startup(IConfiguration configuration)
    {
        configRoot = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
    //     services.AddDbContext<UserDbContext>(options =>
       
    //     //    var connectionString =("ConnectionStrings");
    //        options.UseMySql(configRoot.GetConnectionString("Default"));
    //    );
        
        services.AddScoped<IUserRepository, UserRepository>();
    }
    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }


    
    }
}