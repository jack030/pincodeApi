using pincodeApi.Entities;
namespace pincodeApi.Entities.Controllers.Repo;
// {
//     public interface IUserRepository
//     {
//     }
// }



public interface IVideoFileRepository
{
    Task<IEnumerable<VideoFile>> GetVideoFile();
    Task<VideoFile> GetvideoFile(int vidoeFileId);
    Task<VideoFile> AddVideoFile(VideoFile videoFile);
    // Task<User> UpdateUser(User user);
    Task<VideoFile> FindVideoFile(string name);
    void DeleteVideoFile(int vidoeFileId);
}