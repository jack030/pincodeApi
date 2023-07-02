using MySqlConnector;
using pincodeApi.Entities.Controllers.Repo;
using MySql.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString("Default")));

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program).Assembly); 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





// var startup = new Startup(builder.Configuration);
// startup.ConfigureServices(builder.Services); // calling ConfigureServices method
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepositpry>();
builder.Services.AddScoped<IVideoRepository, VideoRepository>();
builder.Services.AddScoped<IVideoFileRepository, VideoFileRepository>();
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.Write(connectionString);
builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlite(connectionString));
builder.Services.AddDbContext<RoomDbContext>(options => options.UseSqlite(connectionString));
builder.Services.AddDbContext<VideoDbContext>(options => options.UseSqlite(connectionString));







var app = builder.Build();






if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.UseRouting();


app.Run();