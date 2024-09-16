using Newtonsoft.Json;
using PexelsApi.ApiContracts;

namespace PexelsApi.Services;

public class PexelsService(HttpClient httpClient) : IPexelsService
{
    public async Task<PhotoResponse?> GetCuratedImagesAsync(int page, int perPage)
    {
        try
        {
            var response = await httpClient.GetAsync($"v1/curated?page={page}&per_page={perPage}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var photoResponse = JsonConvert.DeserializeObject<PhotoResponse>(jsonResponse);
                return photoResponse;
            }
            else
            {
                throw new HttpRequestException("Failed to fetch photos.");
            }
        }
        catch (Exception)
        {
            throw new Exception("An unexpected error occurred. Please try again later.");
        }
    }

    public async Task<VideoResponse?> GetPopularVideosAsync(int page, int perPage)
    {
        try
        {
            var response = await httpClient.GetAsync($"v1/videos/popular?page={page}&per_page={perPage}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var videoResponse = JsonConvert.DeserializeObject<VideoResponse>(jsonResponse);
                return videoResponse;
            }
            else
            {
                throw new HttpRequestException("Failed to fetch videos.");
            }
        }
        catch (Exception)
        {
            throw new Exception("An unexpected error occurred. Please try again later.");
        }
    }
}