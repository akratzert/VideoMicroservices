namespace Video.Models;

public class VideoDto
{
    public string Description { get; set; } = string.Empty;
    public Guid ThemeId { get; set; } = Guid.Empty;
    public string ThemeName { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public Uri Url { get; set; } = new(Constants.DEFAULT_URI);
    public Guid VideoId { get; set; } = Guid.Empty;
}
