using DataAccess.DataAccess;
using DataAccess.DataAccess.Enum;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class BookingRepository : GenericRepository<Booking>, IBookingRepository
{
    /*private readonly TatooWebContext _context;*/
    public BookingRepository(TatooWebContext context) : base(context)
    {
        /*_context = context;*/
    }

    public Booking CheckBookingStatusByCusId(Guid cusid, Guid StuId)
    {
        var booking = _context.Set<Booking>()
            .Include(c => c.Studio)
            .FirstOrDefault(c =>
                c.Customer.Id == cusid && c.Studio.Id == StuId && c.Status == BookingStatus.Done.ToString());
        if (booking is null) return null;
        return booking;
    }

    public IEnumerable<Booking> GetAllByCusId(Guid cusid)
    {
        var lisbooking = _context.Set<Booking>()
            .Include(c => c.Studio)
            .Include(c => c.Schedulings)
            .Where(c => c.Customer.Id == cusid)
            .ToList();

        return lisbooking;
    }
}