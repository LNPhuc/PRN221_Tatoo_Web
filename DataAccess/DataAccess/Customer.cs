namespace DataAccess.DataAccess;

public class Customer
{
    public Customer()
    {
        Bookings = new HashSet<Booking>();
        VipMembers = new HashSet<VipMember>();
    }

    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public Guid? AccountId { get; set; }

    public virtual Account? Account { get; set; }
    public virtual ICollection<Booking> Bookings { get; set; }
    public virtual ICollection<VipMember> VipMembers { get; set; }
}