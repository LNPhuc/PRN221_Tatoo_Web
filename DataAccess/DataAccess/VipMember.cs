namespace DataAccess.DataAccess;

public class VipMember
{
    public Guid Id { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? StudioId { get; set; }

    public virtual Customer? Customer { get; set; }
    public virtual Studio? Studio { get; set; }
}