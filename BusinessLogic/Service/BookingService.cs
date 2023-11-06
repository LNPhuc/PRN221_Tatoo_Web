using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.DataAccess.Enum;
using DataAccess.IRepository.UnitOfWork;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusinessLogic.Service;

public class BookingService : IBookingService
{
    private readonly IUnitOfWork _unitOfWork;

    public BookingService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<bool> CreateBooking(Guid id, DateTime? date, Guid studioID)
    {
        Booking booking = new Booking();
        booking.Id = new Guid();
        booking.StudioId = studioID;
        booking.CustomerId = id;
        booking.Status = BookingStatus.Pending.ToString();
        _unitOfWork.Booking.Add(booking);

        Scheduling scheduling = new Scheduling();
        scheduling.Id = new Guid();
        scheduling.BookingId = booking.Id;
        scheduling.Date = date;
        _unitOfWork.Schedule.Add(scheduling);

        return true;
    }
}