using Microsoft.AspNetCore.Mvc;

using pincodeApi.Entities.Controllers.Repo;

namespace pincodeApi.Entities.Controllers;


[ApiController]
[Route("[controller]/[action]")]
public class VideoController : ControllerBase
{


    private readonly IVideoRepository _videoRepository;
    private readonly IVideoFileRepository _videoFileRepository;


    private readonly ILogger<VideoController> _logger;
    public VideoController(ILogger<VideoController> logger, IVideoRepository videoRepositpry, IVideoFileRepository videoFileRepository)
    {
        _logger = logger;
        _videoRepository = videoRepositpry;
        _videoFileRepository = videoFileRepository;
    }

    //create
    [HttpPost(Name = "CreateVideo")]

    public async Task<ActionResult<Video>> Create([FromForm] Video video)
    {
        // var video  =new Video();

        Console.WriteLine("here:  " + video);
        try
        {
            if (video == null)
                return BadRequest();

            var createdVideo = await _videoRepository.AddVideo(video);

            return StatusCode(StatusCodes.Status200OK,
                "done creating new video record"); ;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new video record");
        }
    }



    //read
    [HttpGet(Name = "GetVideos")]
    public async Task<ActionResult<IEnumerable<Video>>> GetAll()
    {
        var videoList = await _videoRepository.GetVideos();
        if (videoList.Count() > 0)
        {

            return StatusCode(StatusCodes.Status200OK,
               videoList); ;
        }
        return StatusCode(StatusCodes.Status500InternalServerError,
                "Error finding all video record");

    }

    [HttpGet(Name = "GetVide{id}")]
    public async Task<ActionResult<Video>> FindById(int id)
    {
        var video = await _videoRepository.GetVideo(id);
        if (!video.Name.Equals(""))
        {

            return StatusCode(StatusCodes.Status200OK,
                video); ;
        }
        return StatusCode(StatusCodes.Status500InternalServerError,
                "Error finding user record");
    }
    [HttpDelete(Name = "DeleteVideo{id}")]
    public async Task<ActionResult<Video>> DeleteById(int id)
    {
        var video = await _videoRepository.GetVideo(id);
        if (video.Id > 0)
        {

            _videoRepository.DeleteVideo(id);
            return StatusCode(StatusCodes.Status200OK,
                   video.Id + "removed"); ;
        }


        return StatusCode(StatusCodes.Status500InternalServerError,
                "Error finding user record");

    }
    [HttpPost(Name = "UpdateVideo")]
    public async Task<ActionResult<User>> Update(Video video)
    {


        var updated = await _videoRepository.UpdateVideo(video);
        // Console.WriteLine("updated:  "+ userUpdated);
        if (updated != null)
            return StatusCode(StatusCodes.Status200OK,
                  updated); ;

        return StatusCode(StatusCodes.Status500InternalServerError,
                  "password error"); ;

    }

    [HttpGet(Name = "GetEpisodes{id}")]
    public async Task<ActionResult<IEnumerable<Video>>> FindByRoomId(int id)
    {
        var videos = await _videoRepository.FindEpisodes(id);

        if (videos.Count() > 0)
        {

            return StatusCode(StatusCodes.Status200OK,
                videos); ;
        }
        return StatusCode(StatusCodes.Status500InternalServerError,
                "Error finding user record");

    }

    [HttpPost("FileUpload")]
    public async Task<IActionResult> Index(IFormFile file)
    {
        // long size = file
        // 
        // var filePaths = new List<string>();
        // foreach (var formFile in files)
        // {
        var vf = _videoFileRepository.AddVideoFile(new VideoFile
        {
            Id = 0,
            Name = file.FileName
        });
        var filePath = "";
        if (file.Length > 0)
        {
            // full path to file in temp location
            filePath = "./Videos/" + vf.Id;
            // Path.GetTempFileName(); //we are using Temp file name just for the example. Add your own file path.
            // filePath.Add(filePath);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }

        return Ok(vf);
    }

}