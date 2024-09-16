namespace PexelsApi.ApiContracts;

public class Video
{
    public int Id { get; set; }
    
    public int Width { get; set; }
    
    public int Height { get; set; }
    
    public int Duration { get; set; }
    
    public string Url { get; set; }
    
    public string Image { get; set; }
    
    public string AvgColor { get; set; }
    
    public User User { get; set; }
    
    public List<VideoFile> VideoFiles { get; set; }
    
    public List<VideoPicture> VideoPictures { get; set; }
    
    public List<string> Tags { get; set; }
}