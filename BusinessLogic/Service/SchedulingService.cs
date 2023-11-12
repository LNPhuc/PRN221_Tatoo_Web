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
    public IEnumerable<Scheduling> GetAll() => _unitOfWork.Schedule.GetAll().ToList();

    public Scheduling GetById(Guid id) => _unitOfWork.Schedule.GetById(id);

    public Scheduling Update(Scheduling scheduling) => _unitOfWork.Schedule.Update(scheduling);

    public Scheduling Delete(Scheduling scheduling) => _unitOfWork.Schedule.Delete(scheduling);

    public Scheduling Create(Scheduling scheduling) => _unitOfWork.Schedule.Create(scheduling);

    public void SaveChanges() => _unitOfWork.Schedule.SaveChanges();

    public Customer GetCustomerByID(Guid id) => _unitOfWork.Schedule.GetCustomerByID(id);

    public Account GetAccountByID(Guid id) => _unitOfWork.Schedule.GetAccountByID(id);

    public Booking GetBookingByID(Guid id) => _unitOfWork.Schedule.GetBookingByID(id);
    public void UpdateBooking(Booking booking) => _unitOfWork.Schedule.UpdateBooking(booking);
}