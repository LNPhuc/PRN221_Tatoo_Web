namespace DataAccess.DataAccess;

public class Studio
{
    public Studio()
    {
        Artists = new HashSet<Artist>();
        Bookings = new HashSet<Booking>();
        Discounts = new HashSet<Discount>();
        Equipment = new HashSet<Equipment>();
        VipMembers = new HashSet<VipMember>();
    }

    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? StudioPhone { get; set; }
    public string? StudioEmail { get; set; }
    public Guid? AccountId { get; set; }
    public string? Status { get; set; }

    public virtual Account? Account { get; set; }
    public virtual ICollection<Artist> Artists { get; set; }
    public virtual ICollection<Booking> Bookings { get; set; }
    public virtual ICollection<Discount> Discounts { get; set; }
    public virtual ICollection<Equipment> Equipment { get; set; }
    public virtual ICollection<VipMember> VipMembers { get; set; }
}