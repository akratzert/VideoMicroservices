using Video.Data.Entities;

namespace Video.Data.Interfaces;
public interface IThemeDataService
{
    Task<ThemeEntity?> GetTheme(Guid themeId);
    Task<ThemeEntity> InsertTheme(ThemeEntity theme);
    Task<ThemeEntity> UpdateVideo(ThemeEntity theme);
}