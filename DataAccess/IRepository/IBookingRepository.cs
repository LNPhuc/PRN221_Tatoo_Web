using DataAccess.DataAccess;
using DataAccess.IRepository.Generic;

namespace DataAccess.IRepository;

public interface IBookingRepository : IGenericRepository<Booking>
{
    IEnumerable<Booking> GetAllByCusId(Guid cusid);
    Booking CheckBookingStatusByCusId(Guid cusid, Guid StuId);
}