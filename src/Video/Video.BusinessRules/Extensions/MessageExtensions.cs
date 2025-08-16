using System;
using Video.Data.Entities;
using Video.Models;

namespace Video.BusinessRules.Extensions;
internal static class MessageExtensions
{
    public static VideoEntity? ToEntity(this VideoMetadata? message)
    {
        return message is null
            ? null
            : new()
            {
                Description = message.Description,
                ThemeId = message.ThemeId,
                Title = message.Title,
                Url = message.Url.ToString(),
            };
    }
}
