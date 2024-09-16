namespace PexelsApi.ApiContracts;

public class VideoFile
{
    public int Id { get; set; }
    
    public string Quality { get; set; }
    
    public string FileType { get; set; }
    
    public int Width { get; set; }
    
    public int Height { get; set; }
    
    public double Fps { get; set; }
    
    
    public string Link { get; set; }
    
    public long Size { get; set; }
}