using PexelsApi.Models;

namespace PexelsApi.Services;

public interface IPexelsService
{
    Task<List<ImageModel>> GetCuratedImagesAsync(int page, int perPage);

    Task<List<VideoModel>> GetCuratedVideosAsync(int page, int perPage);
}