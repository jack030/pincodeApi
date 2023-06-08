using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using pincodeApi.Entities.Controllers.Dto;
using pincodeApi.Entities.Controllers.Repo;

namespace pincodeApi.Entities.Controllers;


[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{


    private readonly IUserRepository _userRepository;


    private readonly ILogger<UserController> _logger;
    private readonly IMapper _mapper;
    public UserController(ILogger<UserController> logger, IUserRepository userRepositpry, IMapper mapper)
    {
        _logger = logger;
        _userRepository = userRepositpry;
        _mapper = mapper;
    }

    //create
    [HttpPost(Name = "/Signup")]

    // [Route("[action]")]
    public async Task<ActionResult<User>> Signup([FromBody] UserDto user)
    {

        Console.WriteLine("here:  " + user);
        try
        {
            if (user == null)
                return BadRequest();
            if (user.Confirm.Equals(user.Password))
            {

                var passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Confirm);

                Console.WriteLine("password:" + passwordHash);
                user.Password = passwordHash;
                var u = _mapper.Map<User>(user);
                var createdUser = await _userRepository.AddUser(u);
                return StatusCode(StatusCodes.Status200OK,
                    "done creating new user record"); ;
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new user record");

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new user record");
        }
    }


    [HttpPost(Name = "/Login")]
    public async Task<ActionResult<User>> Login([FromBody] LoginDto user)
    {
        var loginUser = await _userRepository.FindUser(user.Name);
        if (BCrypt.Net.BCrypt.Verify(user.Password, loginUser.Password))
        {
            return StatusCode(StatusCodes.Status200OK,
                loginUser); ;
        }
        return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new user record");
    }
    //read
    [HttpGet(Name = "GetUsers")]
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
    {
        var userList = await _userRepository.GetUsers();
        // Console.WriteLine(userList.Count());
        if (userList.Count() > 0)
        {

            // Console.WriteLine("inline"+userList.Count());
            return StatusCode(StatusCodes.Status200OK,
               userList); ;
        }
        return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new user record");

    }
    [HttpGet(Name = "GetUser{id}")]
    public async Task<ActionResult<User>> FindById(int id)
    {
        var user = await _userRepository.GetUser(id);
        Console.WriteLine("user " + user);
        if (!user.Name.Equals(""))
        {

            return StatusCode(StatusCodes.Status200OK,
                user); ;
        }
        return StatusCode(StatusCodes.Status500InternalServerError,
                "Error finding user record");

    }
    [HttpDelete(Name = "DeleteUser{id}")]
    public async Task<ActionResult<User>> DeleteById(int id)
    {
        var user = await _userRepository.GetUser(id);
        if (user.Id > 0)
        {

            _userRepository.DeleteUser(id);
            return StatusCode(StatusCodes.Status200OK,
                   user.Id + "removed"); ;
        }


        return StatusCode(StatusCodes.Status500InternalServerError,
                "Error finding user record");

    }

    [HttpPost(Name = "UpdateUser")]
    public async Task<ActionResult<User>> Update(UpdateUserDto user)
    {
        if (user.Confirm.Equals(user.Password))
        {

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Confirm);
            user.Password = passwordHash;

            var u = _mapper.Map<User>(user);
            Console.WriteLine("update Id :" + u.Id);
            var userUpdated = await _userRepository.UpdateUser(u);
            // Console.WriteLine("updated:  "+ userUpdated);
            return StatusCode(StatusCodes.Status200OK,
                  userUpdated); ;
        }
        return StatusCode(StatusCodes.Status500InternalServerError,
                      "password error"); ;

    }
}