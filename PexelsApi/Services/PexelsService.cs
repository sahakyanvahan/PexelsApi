using System.Net.Http.Headers;
using System.Text.Json;
using PexelsApi.Models;

namespace PexelsApi.Services;

public class PexelsService : IPexelsService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly string _pexelsApiKey;

    public PexelsService(IConfiguration configuration)
    {
        _configuration = configuration;
        _httpClient = new HttpClient();
    }

    public async Task<List<ImageModel>> GetCuratedImagesAsync(int page, int perPage)
    {
        try
        {
            var url = $"https://api.pexels.com/v1/curated?page={page}&per_page={perPage}";
            
            var pexelsApiKey = _configuration["PexelsApiKey"];
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", pexelsApiKey);
            
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var imageResponse = JsonSerializer.Deserialize<ImageResponse>(jsonResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                return imageResponse?.Photos ?? new List<ImageModel>();
            }

            return new List<ImageModel>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<VideoModel>> GetCuratedVideosAsync(int page, int perPage)
    {
        var url = $"https://api.pexels.com/videos/curated?page={page}&per_page={perPage}";
        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var videoResponse = JsonSerializer.Deserialize<VideoResponse>(jsonResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            return videoResponse?.Videos ?? new List<VideoModel>();
        }

        return new List<VideoModel>();
    }
}