
using Microsoft.EntityFrameworkCore;

namespace pincodeApi.Entities.Controllers.Repo;
public class VideoFileRepository : IVideoFileRepository
{

    private readonly VideoDbContext _vfDbContext;
    public VideoFileRepository(VideoDbContext videoDbContext)
    {

        _vfDbContext = videoDbContext;
    }

    public async Task<VideoFile> AddVideoFile(VideoFile videoFile)
    {
       
        var result = await _vfDbContext.VideoFiles.AddAsync(videoFile);
        await _vfDbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async void DeleteVideoFile(int vidoeFileId)
    {
        
        var result = await _vfDbContext.VideoFiles
                  .FirstOrDefaultAsync(e => e.Id == vidoeFileId);
        if (result != null)
        {
            _vfDbContext.VideoFiles.Remove(result);
            await _vfDbContext.SaveChangesAsync();
        }
    }

    public Task<VideoFile> FindVideoFile(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<VideoFile>> GetVideoFile()
    {
        throw new NotImplementedException();
    }

    public async Task<VideoFile> GetvideoFile(int vidoeFileId)
    {
        return await _vfDbContext.VideoFiles.FirstOrDefaultAsync(e => e.Id == vidoeFileId);
    }
}