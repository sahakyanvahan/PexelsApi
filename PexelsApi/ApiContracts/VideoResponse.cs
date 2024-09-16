namespace PexelsApi.ApiContracts;

public class VideoResponse
{
    public int Page { get; set; }
    
    public int PerPage { get; set; }
    
    public List<Video> Videos { get; set; }
    
    public int TotalResults { get; set; }
    
    public string NextPage { get; set; } 
}