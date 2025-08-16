namespace Video.Models;

public class VideoMetadata
{
    public string Description { get; set; } = string.Empty;
    public Guid ThemeId { get; set; } = Guid.Empty;
    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}
