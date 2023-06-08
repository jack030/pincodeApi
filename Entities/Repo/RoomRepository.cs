

using Microsoft.EntityFrameworkCore;


namespace pincodeApi.Entities.Controllers.Repo;
public class RoomRepositpry : IRoomRepository
{

    private readonly RoomDbContext _roomDbContext;
    private readonly VideoDbContext _videoDbContext;
    public RoomRepositpry(RoomDbContext roomDbContext , VideoDbContext videoDbContext)
    {

        _roomDbContext = roomDbContext;
        _videoDbContext = videoDbContext;
    }

    public async Task<Room> AddRoom(Room room)
    {
        var result = await _roomDbContext.Rooms.AddAsync(room);
        await _roomDbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async void DeleteRoom(int roomId)
    {
        var result = await _videoDbContext.Rooms
                   .FirstOrDefaultAsync(e => e.Id == roomId);
        if (result != null)
        {
            _videoDbContext.Rooms.Remove(result);
            await _videoDbContext.SaveChangesAsync();
        }
    }

    public async  Task<Room> GetRoom(int roomId)
    {
         return await _videoDbContext.Rooms.FirstOrDefaultAsync(e => e.Id == roomId);
    }

    public async Task<IEnumerable<Room>> GetRooms()
    {
        return _videoDbContext.Rooms.ToList<Room>();
    }

    public Task<Room> UpdateRoom(Room room)
    {
        throw new NotImplementedException();
    }
}