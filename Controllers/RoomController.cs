using Microsoft.AspNetCore.Mvc;

using pincodeApi.Entities.Controllers.Repo;

namespace pincodeApi.Entities.Controllers;


[ApiController]
[Route("[controller]/[action]")]
public class RoomController : ControllerBase
{


    private readonly IRoomRepository _roomRepositry;
    // private readonly IRoomRepository _roomRepositry;


    private readonly ILogger<RoomController> _logger;
    public RoomController(ILogger<RoomController> logger, IRoomRepository roomRepositpry)
    {
        _logger = logger;
        _roomRepositry = roomRepositpry;
    }

    //create
    [HttpPost(Name = "Create")]

    public async Task<ActionResult<Room>> Create([FromBody] Room room)
    {

        Console.WriteLine("here:  " + room);
        try
        {
            if (room == null)
                return BadRequest();

            var createdUser = await _roomRepositry.AddRoom(room);

            return StatusCode(StatusCodes.Status200OK,
                "done creating new room record"); ;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new user record");
        }
    }



    //read
    [HttpGet(Name = "GetRooms")]
    public async Task<ActionResult<IEnumerable<Room>>> GetAll()
    {
        var roomlList = await _roomRepositry.GetRooms();
        if (roomlList.Count() > 0)
        {

            // Console.WriteLine("inline"+userList.Count());
            return StatusCode(StatusCodes.Status200OK,
               roomlList); ;
        }
        return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new user record");
    }
    
    [HttpGet(Name = "GetVideo{id}")]
    public async Task<ActionResult<Video>> FindById(int id)
    {
        var room = await _roomRepositry.GetRoom(id);

        if (!room.Name.Equals(""))
        {

            return StatusCode(StatusCodes.Status200OK,
                room); ;
        }
        return StatusCode(StatusCodes.Status500InternalServerError,
                "Error finding user record");

    }

    
    [HttpDelete(Name = "DeleteRoom{id}")]
    public async Task<ActionResult<Room>> DeleteById(int id)
    {
        var room = await _roomRepositry.GetRoom(id);
        if (room.Id > 0)
        {

            _roomRepositry.DeleteRoom(id);
            return StatusCode(StatusCodes.Status200OK,
                   room.Id + "removed"); ;
        }


        return StatusCode(StatusCodes.Status500InternalServerError,
                "Error finding user record");

    }



}