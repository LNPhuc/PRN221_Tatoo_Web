using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface IBookingService
{
	IEnumerable<Booking> GetAll();

	Task<bool> CreateBooking(Guid id, DateTime date, Guid studioID);
}