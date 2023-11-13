using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class SchedulingRepository : GenericRepository<Scheduling>, ISchedulingRepository
{
    private readonly TatooWebContext _context;
    public SchedulingRepository(TatooWebContext context) : base(context)
    {
        _context = context;
    }

    public IEnumerable<Scheduling> GetAll() => _context.Schedulings.Include(c => c.Booking).ToList();

    public Scheduling Create(Scheduling scheduling)
    {
        _context.Set<Scheduling>().Add(scheduling);
        return scheduling;
    }

    public Scheduling Delete(Scheduling scheduling)
    {
        scheduling.Status = "Cancel";
        Update(scheduling);
        return scheduling;

    }

    public Scheduling GetById(Guid id)
    {
        return _context.Set<Scheduling>().FirstOrDefault(c => c.Id == id);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    Scheduling ISchedulingRepository.Update(Scheduling scheduling)
    {
        _context.Set<Scheduling>().Update(scheduling);
        return scheduling;
    }
    public Customer GetCustomerByID(Guid id)
    {
        return _context.Set<Customer>().FirstOrDefault(c => c.Id == id);
    }
    public Account GetAccountByID(Guid id)
    {
        return _context.Set<Account>().FirstOrDefault(a => a.Id == id);
    }
    public Booking GetBookingByID(Guid id)
    {
        return _context.Set<Booking>().FirstOrDefault(b => b.Id == id);
    }
    public Artist GetArtistById(Guid id)
    {
        return _context.Set<Artist>().FirstOrDefault(a => a.Id == id);
    }
    public void UpdateBooking(Booking booking)
    {
        _context.Set<Booking>().Update(booking);
    }
    public List<Booking> GetBookingByStudio(Guid id)
    {
        return _context.Bookings.Where(b => b.StudioId == id).ToList();
    }
    public List<Scheduling> GetSchedulingByStudio(Guid id)
    {
        return _context.Schedulings.Include(s => s.Booking).Where(b => b.Booking.StudioId == id).ToList();
    }

    public List<Artist> GetAllArtishByStudio(Guid id)
    {
        return _context.Artists.Where(s => s.StudioId == id).ToList();

    }
}