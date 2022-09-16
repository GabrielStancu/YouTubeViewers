namespace YouTubeViewers.EntityFramework.DTOs;
public class YouTubeViewerDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public bool IsSubscribed { get; set; }
    public bool IsMember { get; set; }
}
