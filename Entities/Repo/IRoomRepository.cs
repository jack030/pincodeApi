using pincodeApi.Entities;
namespace pincodeApi.Entities.Controllers.Repo;
// {
//     public interface IUserRepository
//     {
//     }
// }



public interface IRoomRepository
{
    Task<IEnumerable<Room>> GetRooms();
    Task<Room> GetRoom(int roomId);
    Task<Room> AddRoom(Room room);
    Task<Room> UpdateRoom(Room room);
    void DeleteRoom(int roomId);
}