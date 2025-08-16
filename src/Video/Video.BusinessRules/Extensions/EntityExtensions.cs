using Video.Data.Entities;
using Video.Models;

namespace Video.BusinessRules.Extensions;
internal static class EntityExtensions
{
    public static VideoDto? ToDto(this VideoEntity? entity)
    {
        return entity is null
            ? null
            : new()
            {
                Description = entity.Description,
                ThemeId = entity.ThemeId,
                Title = entity.Title,
                Url = new Uri(entity.Url),
                VideoId = entity.VideoId,
            };
    }
}
