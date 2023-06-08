using pincodeApi.Entities;
namespace pincodeApi.Entities.Controllers.Repo;
// {
//     public interface IVideoRepository
//     {
//     }
// }



public interface IVideoRepository
{
    Task<IEnumerable<Video>> GetVideos();
    Task<Video> GetVideo(int videoId);
    Task<Video> AddVideo(Video video);
    Task<Video> UpdateVideo(Video video);
    Task<IEnumerable<Video>> FindEpisodes(int roomId);
    void DeleteVideo(int videoId);
}