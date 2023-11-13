namespace DataAccess.DataAccess;

public class Equipment
{
    public Equipment()
    {
        Bookings = new HashSet<Booking>();
    }

    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Position { get; set; }
    public Guid? StudioId { get; set; }

    public virtual Studio? Studio { get; set; }
    public virtual ICollection<Booking> Bookings { get; set; }
}