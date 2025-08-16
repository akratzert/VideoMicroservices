using Video.Data.Entities;

namespace Video.Data.Interfaces;
public interface IVideoDataService
{
    Task<VideoEntity?> GetVideo(Guid videoId);
    Task<VideoEntity?> GetVideo(string url);
    Task<List<VideoEntity>> GetVideos(int pageSize, string? pageKey = null);
    Task<VideoEntity> InsertVideo(VideoEntity video);
    Task<VideoEntity> UpdateVideo(VideoEntity video);
}