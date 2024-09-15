using Microsoft.AspNetCore.Mvc;
using PexelsApi.Services;

namespace PexelsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PexelsController: ControllerBase
{
    private readonly IPexelsService _pexelsService;

    public PexelsController(IPexelsService pexelsService)
    {
        _pexelsService = pexelsService;
    }

    [HttpGet("images")]
    public async Task<IActionResult> GetCuratedImages(int page = 1, int perPage = 15)
    {
        var images = await _pexelsService.GetCuratedImagesAsync(page, perPage);
        return Ok(images);
    }

    [HttpGet("videos")]
    public async Task<IActionResult> GetCuratedVideos(int page = 1, int perPage = 15)
    {
        var videos = await _pexelsService.GetCuratedVideosAsync(page, perPage);
        return Ok(videos);
    }
}