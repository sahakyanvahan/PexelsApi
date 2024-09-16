namespace PexelsApi.ApiContracts;

public class Photo
{
    public int Id { get; set; }
    
    public int Width { get; set; }
    
    public int Height { get; set; }
    
    public string Url { get; set; }
    
    public string Photographer { get; set; }
    
    public string PhotographerUrl { get; set; }
    
    public long PhotographerId { get; set; }
    
    public string AvgColor { get; set; }
    
    public Src Src { get; set; }
    
    public bool Liked { get; set; }
    
    public string Alt { get; set; }
}