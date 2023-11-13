using DataAccess.DataAccess;
using DataAccess.IRepository.Generic;

namespace DataAccess.IRepository;

public interface ISchedulingRepository : IGenericRepository<Scheduling>
{
    IEnumerable<Scheduling> GetAll();
    Scheduling GetById(Guid id);
    Scheduling Update(Scheduling scheduling);
    Scheduling Delete(Scheduling scheduling);
    Scheduling Create(Scheduling scheduling);
    void SaveChanges();
    Customer GetCustomerByID(Guid id);
    Account GetAccountByID(Guid id);
    Booking GetBookingByID(Guid id);
    Artist GetArtistById(Guid id);
    void UpdateBooking(Booking booking);
    List<Booking> GetBookingByStudio(Guid id);

    List<Scheduling> GetSchedulingByStudio(Guid id);
    List<Artist> GetAllArtishByStudio(Guid id);
}