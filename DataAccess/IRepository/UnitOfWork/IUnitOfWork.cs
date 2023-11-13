namespace DataAccess.IRepository.UnitOfWork;

public interface IUnitOfWork
{
    IAccountRepository Account { get; }
    IArtistRepository Artist { get; }
    IArtWorkRepository ArtWork { get; }
    IBookingRepository Booking { get; }
    ICustomerRepository Customer { get; }
    IDiscountRepository Discount { get; }
    IEquipmentRepository Equipment { get; }
    IImageRepository Image { get; }
    IStudioRepository Studio { get; }
    IVipMemberRepository VipMember { get; }
    ISchedulingRepository Schedule { get; }

    void Save();
}