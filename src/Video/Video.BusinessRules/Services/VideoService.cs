using Video.BusinessRules.Extensions;
using Video.BusinessRules.Interfaces;
using Video.Data.Entities;
using Video.Data.Interfaces;
using Video.Models;

namespace Video.BusinessRules.Services;

public class VideoService(IThemeDataService themeDataService,
                          IVideoDataService videoDataService) : IVideoService
{
    public async Task<VideoDto?> GetVideo(Guid videoId)
    {
        VideoDto? dto = default;

        try
        {
            var videoEntity = await videoDataService.GetVideo(videoId);
            dto = videoEntity.ToDto();

            if (dto is not null && videoEntity is not null && videoEntity.ThemeId != Guid.Empty)
            {
                var themeEntity = await themeDataService.GetTheme(videoEntity.ThemeId);
                if (themeEntity is not null)
                {
                    dto.ThemeName = themeEntity.ThemeName;
                }
            }
        }
        catch (Exception ex)
        {
            // Log Error & Handle
        }

        return dto;
    }

    public async Task<List<VideoDto>> GetVideos(int pageSize, string? pageKey = null)
    {
        List<VideoDto> dtoList = [];

        try
        {
            var entities = await videoDataService.GetVideos(pageSize, pageKey);
            foreach (var entity in entities)
            {
                var dto = entity.ToDto();
                if (dto is not null)
                {
                    dtoList.Add(dto);
                }
            }
        }
        catch (Exception ex)
        {
            // Log Error & Handle
        }

        return dtoList;
    }

    public async Task<VideoDto?> UpsertVideo(VideoMetadata videoMetadata)
    {
        VideoDto? result = default;

        try
        {
            string videoUrl = videoMetadata.Url.ToString();
            if (videoUrl != Constants.DEFAULT_URI) // Has to have a valid Url
            {
                VideoEntity? resultEntity = default;

                // Find by url
                var existingEntity = await videoDataService.GetVideo(videoUrl);
                if (existingEntity is null)
                {
                    var newEntity = videoMetadata.ToEntity();
                    if (newEntity is not null)
                    {
                        resultEntity = await videoDataService.InsertVideo(newEntity);
                    }
                }
                else
                {
                    existingEntity.ThemeId = videoMetadata.ThemeId;
                    existingEntity.Description = videoMetadata.Description;
                    existingEntity.Title = videoMetadata.Title;

                    resultEntity = await videoDataService.UpdateVideo(existingEntity);
                }

                result = resultEntity.ToDto();
            }
        }
        catch (Exception ex)
        {
            // Log Error & Handle
        }

        return result;
    }
}
