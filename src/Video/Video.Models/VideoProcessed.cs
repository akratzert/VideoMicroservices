namespace Video.Models;

public class VideoProcessed
{
    public Uri Url { get; set; } = new(Constants.DEFAULT_URI);
    public Guid VideoId { get; set; } = Guid.Empty;
}
