using Microsoft.AspNetCore.Mvc;
using Video.BusinessRules.Interfaces;
using Video.Models;

namespace VideoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VideoController(IVideoService videoService) : ControllerBase
{
    [HttpGet("{videoId}")]
    public async Task<ActionResult<VideoDto>> GetVideo([FromRoute] Guid videoId)
    {
        var response = await videoService.GetVideo(videoId);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<VideoDto>> GetVideos([FromQuery] int pageSize,
                                                        [FromQuery] string? pageKey = null)
    {
        var response = await videoService.GetVideos(pageSize, pageKey);
        return Ok(response);
    }
}
