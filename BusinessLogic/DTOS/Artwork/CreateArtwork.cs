namespace BusinessLogic.DTOS.Artwork;

public class CreateArtwork
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Position { get; set; }
    public string? Size { get; set; }
    public TimeSpan? Time { get; set; }

    public Guid? ArtistId { get; set; }
    /*public Image? image { get; set; }*/
}