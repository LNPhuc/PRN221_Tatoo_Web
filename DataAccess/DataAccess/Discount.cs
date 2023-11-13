namespace DataAccess.DataAccess;

public class Discount
{
    public Guid Id { get; set; }
    public Guid? StudioId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Status { get; set; }

    public virtual Studio? Studio { get; set; }
}