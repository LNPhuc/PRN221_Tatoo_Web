using DataAccess.IRepository;
using DataAccess.IRepository.UnitOfWork;

namespace DataAccess.Repository.UnitOfWork;

public class UnitOfWorkRepository : IUnitOfWork
{
    public readonly TatooWebContext _context;

    public UnitOfWorkRepository(TatooWebContext context)
    {
        _context = context;
        Account = new AccountRepository(_context);
        Artist = new ArtistRepository(_context);
        ArtWork = new ArtWorkRepository(_context);
        Booking = new BookingRepository(_context);
        Customer = new CustomerRepository(_context);
        Discount = new DiscountRepository(_context);
        Equipment = new EquipmentRepository(_context);
        Image = new ImageRepository(_context);
        Studio = new StudioRepository(_context);
        VipMember = new VipMemberRepository(_context);
        Schedule = new SchedulingRepository(_context);
    }

    public IAccountRepository Account { get; }
    public IArtistRepository Artist { get; }
    public IArtWorkRepository ArtWork { get; }
    public IBookingRepository Booking { get; }
    public ICustomerRepository Customer { get; }
    public IDiscountRepository Discount { get; }
    public IEquipmentRepository Equipment { get; }
    public IImageRepository Image { get; }
    public IStudioRepository Studio { get; }
    public IVipMemberRepository VipMember { get; }
    public ISchedulingRepository Schedule { get; }

    public void Save()
    {
        _context.SaveChanges();
    }
}