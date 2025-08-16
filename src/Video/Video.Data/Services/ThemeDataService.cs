using Video.Data.Entities;
using Video.Data.Interfaces;

namespace Video.Data.Services;

public class ThemeDataService : IThemeDataService
{
    public async Task<ThemeEntity?> GetTheme(Guid themeId)
    {
        ThemeEntity result = new();

        // Dynamo Db Partition Key: ThemeId
        // Do Dynamo Db Query by partiaiotn key
        await Task.CompletedTask;

        return result;
    }

    public async Task<ThemeEntity> InsertTheme(ThemeEntity theme)
    {
        ThemeEntity result = new();

        // Insert into Dynamo Db
        await Task.CompletedTask;

        return result;
    }

    public async Task<ThemeEntity> UpdateVideo(ThemeEntity theme)
    {
        ThemeEntity result = new();

        // Update video in Dynamo Db based on Theme Id
        await Task.CompletedTask;

        return result;
    }
}
