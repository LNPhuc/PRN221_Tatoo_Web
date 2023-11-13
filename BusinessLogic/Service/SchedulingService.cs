using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository.UnitOfWork;

namespace BusinessLogic.Service;

public class SchedulingService : ISchedulingService
{
    private readonly IUnitOfWork _unitOfWork;

    public SchedulingService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Scheduling> GetAll()
    {
        return _unitOfWork.Schedule.GetAll().ToList();
    }

    public Scheduling GetById(Guid id)
    {
        return _unitOfWork.Schedule.GetById(id);
    }

    public Scheduling Update(Scheduling scheduling)
    {
        return _unitOfWork.Schedule.Update(scheduling);
    }

    public Scheduling Delete(Scheduling scheduling)
    {
        return _unitOfWork.Schedule.Delete(scheduling);
    }

    public Scheduling Create(Scheduling scheduling)
    {
        return _unitOfWork.Schedule.Create(scheduling);
    }

    public void SaveChanges()
    {
        _unitOfWork.Schedule.SaveChanges();
    }

    public Customer GetCustomerByID(Guid id)
    {
        return _unitOfWork.Schedule.GetCustomerByID(id);
    }

    public Account GetAccountByID(Guid id)
    {
        return _unitOfWork.Schedule.GetAccountByID(id);
    }

    public Booking GetBookingByID(Guid id)
    {
        return _unitOfWork.Schedule.GetBookingByID(id);
    }

    public void UpdateBooking(Booking booking)
    {
        _unitOfWork.Schedule.UpdateBooking(booking);
    }

    public List<Booking> GetBookingByStudio(Guid id)
    {
        return _unitOfWork.Schedule.GetBookingByStudio(id);
    }

    public List<Scheduling> GetSchedulingByStudio(Guid id)
    {
        return _unitOfWork.Schedule.GetSchedulingByStudio(id);
    }

    public List<Scheduling> GetByBooking(Guid id)
    {
        return _unitOfWork.Schedule.GetByBooking(id);
    }
}