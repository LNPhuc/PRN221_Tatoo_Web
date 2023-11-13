using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface IBookingService
{
    IEnumerable<Booking> GetAll();
    IEnumerable<Booking> GetAllByCusId(Guid id);

    Task<bool> CreateBooking(Guid id, DateTime date, Guid studioID);
    /*Booking GetBookingByCusId(Guid id);*/
}