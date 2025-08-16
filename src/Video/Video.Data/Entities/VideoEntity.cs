using Microsoft.VisualBasic;

namespace Video.Data.Entities;

// This would be definned in a Data Layer
public class VideoEntity
{
    public string Description { get; set; } = string.Empty;
    public Guid ThemeId { get; set; } = Guid.Empty;
    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public Guid VideoId { get; set; } = Guid.Empty;
}
