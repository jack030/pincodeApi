using Microsoft.EntityFrameworkCore;
using pincodeApi.Entities;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options)
       : base(options)
    {

    }
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            Name = "javad",
            Password = "112",
            UserType = UserTypes.A,
            RemainingDates = 30
        });
    }

}