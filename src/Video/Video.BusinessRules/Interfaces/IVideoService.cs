using Video.Models;

namespace Video.BusinessRules.Interfaces;

public interface IVideoService
{
    Task<VideoDto?> GetVideo(Guid videoId);
    Task<List<VideoDto>> GetVideos(int pageSize, string? pageKey = null);
    Task<VideoDto?> UpsertVideo(VideoMetadata videoMetadata);
}