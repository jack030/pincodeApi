using pincodeApi.Entities;
namespace pincodeApi.Entities.Controllers.Repo;
// {
//     public interface IUserRepository
//     {
//     }
// }



public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(int userId);
    Task<User> AddUser(User user);
    Task<User> UpdateUser(User user);
    Task<User> FindUser(string name);
    void DeleteUser(int userId);
}