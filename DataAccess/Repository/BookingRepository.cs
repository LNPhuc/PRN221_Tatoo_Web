using DataAccess.DataAccess;
using DataAccess.DataAccess.Enum;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DataAccess.Repository;

public class BookingRepository: GenericRepository<Booking>, IBookingRepository
{
    /*private readonly TatooWebContext _context;*/
    public BookingRepository(TatooWebContext context) : base(context)
    {
        /*_context = context;*/
    }

    public IEnumerable<Booking> GetAllByCusId(Guid cusid)
    {
        var lisbooking = _context.Set<Booking>()
                .Include(c => c.Studio)
                .Where(c => c.Customer.Id == cusid && c.Status == BookingStatus.Done.ToString())
                .ToList();
        if (lisbooking.IsNullOrEmpty() )
        {
            throw new Exception("list booking khong duoc done");
        }
        return lisbooking;
    }
}