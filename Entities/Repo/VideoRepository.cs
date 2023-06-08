
using Microsoft.EntityFrameworkCore;

namespace pincodeApi.Entities.Controllers.Repo;
public class VideoRepository : IVideoRepository
{

    private readonly VideoDbContext _videoDbContext;
    public VideoRepository(VideoDbContext videoDbContext)
    {

        _videoDbContext = videoDbContext;
    }

    public async Task<Video> AddVideo(Video video)
    {
        var result = await _videoDbContext.Videos.AddAsync(video);
        await _videoDbContext.SaveChangesAsync();
        return result.Entity;

    }

    public async void DeleteVideo(int videoId)
    {
        var result = await _videoDbContext.Videos
                   .FirstOrDefaultAsync(e => e.Id == videoId);
        if (result != null)
        {
            _videoDbContext.Videos.Remove(result);
            await _videoDbContext.SaveChangesAsync();
        }
    }

    public async Task<Video> GetVideo(int videoId)
    {
        return await _videoDbContext.Videos.FirstOrDefaultAsync(e => e.Id == videoId);
    }

    public async Task<IEnumerable<Video>> GetVideos()
    {
        return _videoDbContext.Videos.ToList<Video>();
    }

    public async Task<Video> UpdateVideo(Video video)
    {
        var result = await _videoDbContext.Videos
        .FirstOrDefaultAsync(v => v.Id == video.Id);
        if (result != null)
        {
            result.Name = video.Name;
            result.Episode = video.Episode;
            result.Link = video.Link;
            result.RoomId = video.RoomId;

            await _videoDbContext.SaveChangesAsync();
            return result;
        }
        return null;
    }

    public async Task<IEnumerable<Video>> FindEpisodes(int roomId)
    {
        var videos =  _videoDbContext.Videos.Where( v=> v.RoomId == roomId);
        return videos.ToList();
    }

}