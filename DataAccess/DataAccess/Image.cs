namespace DataAccess.DataAccess;

public class Image
{
    public Image(Guid id, string? source, string? entityId)
    {
        Id = id;
        Source = source;
        EntityId = entityId;
    }

    public Guid Id { get; set; }
    public string? Source { get; set; }
    public string? EntityId { get; set; }
}