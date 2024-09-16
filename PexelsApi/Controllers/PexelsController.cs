using Microsoft.AspNetCore.Mvc;
using PexelsApi.Services;

namespace PexelsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PexelsController(IPexelsService pexelsService) : ControllerBase
{
    [HttpGet("images")]
    public async Task<IActionResult> GetCuratedImages(int page = 1, int perPage = 15)
    {
        var images = await pexelsService.GetCuratedImagesAsync(page, perPage);
        return Ok(images);
    }

    [HttpGet("videos")]
    public async Task<IActionResult> GetCuratedVideos(int page = 1, int perPage = 15)
    {
        var videos = await pexelsService.GetPopularVideosAsync(page, perPage);
        return Ok(videos);
    }
}