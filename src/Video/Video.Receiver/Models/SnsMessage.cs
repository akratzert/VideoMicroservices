namespace Video.Receiver.Models;

public class SnsMessage
{
    public string Message { get; set; } = string.Empty;
    public string MessageId { get; set; } = string.Empty;
    public string Timestamp { get; set; } = string.Empty;
    public string TopicArn { get; set; } = string.Empty;
}

