using Video.Data.Entities;
using Video.Data.Interfaces;

namespace Video.Data.Services;


public class VideoDataService : IVideoDataService
{
    public async Task<VideoEntity?> GetVideo(Guid videoId)
    {
        VideoEntity result = new();

        // Dynamo Db Partition Key: VideoId
        // Do Dynamo Db Query by partiaiotn key
        await Task.CompletedTask;

        return result;
    }

    public async Task<VideoEntity?> GetVideo(string url)
    {
        VideoEntity result = new();

        // Do Dynamo Db Query by url
        // If dataset is massive and this is too slow, a separate Index Dynamo Db can be maintained with url for Partition Key and VideoId
        await Task.CompletedTask;

        return result;
    }

    public async Task<List<VideoEntity>> GetVideos(int pageSize, string? pageKey = null)
    {
        List<VideoEntity> result = [];

        // Do Dynamo Db Scan
        await Task.CompletedTask;

        return result;
    }

    public async Task<VideoEntity> InsertVideo(VideoEntity video)
    {
        VideoEntity result = new();

        // Insert into Dynamo Db
        await Task.CompletedTask;

        return result;
    }

    public async Task<VideoEntity> UpdateVideo(VideoEntity video)
    {
        VideoEntity result = new();

        // Update video in Dynamo Db based on Video Id
        await Task.CompletedTask;

        return result;
    }
}
