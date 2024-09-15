namespace PexelsApi.Models;

public class ImageModel
{
    public string Id { get; set; }
    
    public string Photographer { get; set; }
    
    public string Url { get; set; }
    
    public Src Src { get; set; }
}