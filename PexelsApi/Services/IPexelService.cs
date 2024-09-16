using PexelsApi.ApiContracts;

namespace PexelsApi.Services;

public interface IPexelsService
{
    Task<PhotoResponse?> GetCuratedImagesAsync(int page, int perPage);

    Task<VideoResponse?> GetPopularVideosAsync(int page, int perPage);
}