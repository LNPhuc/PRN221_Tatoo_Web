using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;

namespace DataAccess.Repository;

public class BookingRepository: GenericRepository<Booking>, IBookingRepository
{
    public BookingRepository(TatooWebContext context) : base(context)
    {
    }
}