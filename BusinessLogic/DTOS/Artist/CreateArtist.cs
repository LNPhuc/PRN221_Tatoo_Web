namespace BusinessLogic.DTOS.Artist
{
    public class CreateArtist
    {
        public string? Name { get; set; }
        public Guid? StudioId { get; set; }

        public int? Experience { get; set; }

    }
}
