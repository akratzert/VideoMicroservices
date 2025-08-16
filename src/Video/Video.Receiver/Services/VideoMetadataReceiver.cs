using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using Video.BusinessRules.Interfaces;
using Video.Models;
using Video.Receiver.Models;

namespace Video.Receiver.Services;

public class VideoMetadataReceiver(IAmazonSQS sqsClient,
                                   IVideoService videoService) : BackgroundService
{
    private const string _queueUrl = "SqsSqueueUrl";

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                // Poll SQS queue for messages
                var receiveRequest = new ReceiveMessageRequest
                {
                    QueueUrl = _queueUrl,
                    MaxNumberOfMessages = 10, // This is the Max
                    WaitTimeSeconds = 20,
                };

                var response = await sqsClient.ReceiveMessageAsync(receiveRequest, cancellationToken);

                foreach (var message in response.Messages)
                {
                    try
                    {
                        // Process the SNS message
                        await ProcessMessageAsync(message, cancellationToken);

                        // Delete the message from the queue after processing
                        await sqsClient.DeleteMessageAsync(new DeleteMessageRequest
                        {
                            QueueUrl = _queueUrl,
                            ReceiptHandle = message.ReceiptHandle
                        }, cancellationToken);
                    }
                    catch (Exception ex)
                    {
                        // Log Error
                    }
                }
            }
            catch (Exception ex)
            {
                // Log a polling Error 
                await Task.Delay(3000, cancellationToken); // Wait 3 secs before retry
            }
        }
    }

    private async Task ProcessMessageAsync(Message message, CancellationToken cancellationToken)
    {
        try
        {
            // SNS wraps the actual message in a JSON payload
            SnsMessage? snsMessage = JsonSerializer.Deserialize<SnsMessage>(message.Body);

            if (snsMessage is not null)
            {
                string sqsMessageJson = snsMessage.Message;
                VideoMetadata? videoMetadata = JsonSerializer.Deserialize<VideoMetadata>(sqsMessageJson);

                if (videoMetadata is not null)
                {
                    await videoService.UpsertVideo(videoMetadata);
                }
                else
                {
                    // Log Bad Sqs message
                }
            }
            else
            {
                // Log Bad Sns message
            }
        }
        catch (JsonException ex)
        {
            // Log Error with deserializing
        }
    }
}
