
using Microsoft.EntityFrameworkCore;

namespace pincodeApi.Entities.Controllers.Repo;
public class UserRepository : IUserRepository
{

    private readonly UserDbContext _userDbContext;
    public UserRepository(UserDbContext userDbContext)
    {

        _userDbContext = userDbContext;
    }

    public async Task<User> AddUser(User user)
    {

        var result = await _userDbContext.Users.AddAsync(user);
        await _userDbContext.SaveChangesAsync();
        return result.Entity;

    }

    public async void DeleteUser(int userId)
    {
        var result = await _userDbContext.Users
                  .FirstOrDefaultAsync(e => e.Id == userId);
        if (result != null)
        {
            _userDbContext.Users.Remove(result);
            await _userDbContext.SaveChangesAsync();
        }
    }

    public async Task<User> GetUser(int userId)
    {
        return await _userDbContext.Users.FirstOrDefaultAsync(e => e.Id == userId);
    }

    public async Task<IEnumerable<User>> GetUsers()
    {


        var list = _userDbContext.Users.ToList<User>();

        // foreach (var item in list)
        // {


        //     Console.WriteLine("list: " + item);
        // }
        // Console.WriteLine("list count: " + list.Count());
        if (list.Count() > 0)
            return list;
        return null;
    }

    public async Task<User> UpdateUser(User user)
    {

        Console.WriteLine("Id  :  " + user.Id);
        var result = await _userDbContext.Users
            .FirstOrDefaultAsync(e => e.Id == user.Id);
        // Console.WriteLine(result.Id);
        if (result != null)
        {
            result.Name = user.Name;
            result.Password = user.Password;
            result.RemainingDates = user.RemainingDates;
            result.UserType = user.UserType;


            await _userDbContext.SaveChangesAsync();

            return result;
        }

        return null;
    }

    public async Task<User> FindUser(string name)
    {
        return await _userDbContext.Users.FirstOrDefaultAsync(e => e.Name == name);
    }
}