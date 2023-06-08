using Microsoft.EntityFrameworkCore;
using pincodeApi.Entities;

public class RoomDbContext : DbContext
{
    public RoomDbContext(DbContextOptions<RoomDbContext> options)
       : base(options)
    {

    }
    public DbSet<Room> Rooms { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Room>().HasData(new Room
        {
            Id = 1,
            Name = "class1",  
            RoomType = RoomTypes.B
        });
    }

  
}