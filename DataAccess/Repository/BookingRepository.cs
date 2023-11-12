using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class BookingRepository: GenericRepository<Booking>, IBookingRepository
{
    private readonly TatooWebContext _context;
    public BookingRepository(TatooWebContext context) : base(context)
    {
        _context = context;
    }

    public IEnumerable<Booking> GetAllByCusId(Guid cusid)
    {
        var artists = _context.Set<Booking>()
                .Include(c => c.Studio)
                .Include(c => c.Schedulings)
                .ToList();
        return artists;
    }
}