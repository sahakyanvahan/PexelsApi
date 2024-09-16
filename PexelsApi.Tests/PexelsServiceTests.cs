using System.Net;
using System.Text.Json;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
using Newtonsoft.Json;
using NSubstitute;
using PexelsApi.ApiContracts;
using PexelsApi.Services;

namespace PexelsApi.Tests;


[TestFixture]
public class PexelsServiceTests
{
    private IPexelsService _pexelsService;
    private HttpClient _mockHttpClient;
    private IHttpClientFactory _httpClientFactory;
    private IFixture _fixture;

    [SetUp]
    public void Setup()
    {
        _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
        _mockHttpClient = Substitute.For<HttpClient>(Substitute.For<HttpMessageHandler>());
        _httpClientFactory = Substitute.For<IHttpClientFactory>();
        _httpClientFactory.CreateClient().Returns(_mockHttpClient);
        //_mockHttpClient.BaseAddress = new Uri("https://api.pexels.com/");

        _pexelsService = new PexelsService(_mockHttpClient);
    }

    [Test]
    public async Task GetPopularVideosAsync_ShouldReturnValidResponse_WhenApiResponseIsValid()
    {
        // Arrange
        var videoResponse = _fixture.Create<VideoResponse>();
        var jsonResponse = JsonConvert.SerializeObject(videoResponse);

        var mockResponse = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(jsonResponse)
        };

        // Mocking the GetAsync method, using an absolute URI
        _mockHttpClient
            .GetAsync(Arg.Is<string>(s => s == "https://api.pexels.com/v1/videos/popular?page=1&per_page=15"))
            .Returns(Task.FromResult(mockResponse));

        // Act
        var result = await _pexelsService.GetPopularVideosAsync(1, 15);

        // Assert
        result.Should().NotBeNull();
        result.Videos.Should().NotBeEmpty();
        result.Videos[0].Id.Should().Be(videoResponse.Videos[0].Id);

        // Verifying that GetAsync was called with the expected URL
        await _mockHttpClient.Received(1).GetAsync(Arg.Is<string>(s => s == "https://api.pexels.com/v1/videos/popular?page=1&per_page=15"));
    }
}