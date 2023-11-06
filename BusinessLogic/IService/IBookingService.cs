using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface IBookingService
{
    Task<bool> CreateBooking(Guid id, DateTime? date, Guid studioID);
}