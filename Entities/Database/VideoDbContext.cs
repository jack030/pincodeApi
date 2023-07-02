using Microsoft.EntityFrameworkCore;
using pincodeApi.Entities;

public class VideoDbContext : DbContext
{
    public VideoDbContext(DbContextOptions<VideoDbContext> options)
       : base(options)
    {

    }
    public virtual DbSet<Video> Videos { get; set; }
    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<VideoFile> VideoFiles { get;set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Room>().HasData(new Room
        {
            Id = 1,
            Name = "class1",
            RoomType = RoomTypes.B
        });
        modelBuilder.Entity<Video>().HasData(new Video
        {
            Id = 1,
            Name = "video1",
            Episode = 2,
            Link = "google.com",
            RoomId = 1

        });
        modelBuilder.Entity<VideoFile>().HasData(new VideoFile
        {
            Id = 1,
            Name = "video1",
           
        });

    }

}