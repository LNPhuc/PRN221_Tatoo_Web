using AutoMapper;
using BusinessLogic.DTOS;
using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.DataAccess.Enum;
using DataAccess.IRepository.UnitOfWork;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusinessLogic.Service;

public class BookingService : IBookingService
{
	private readonly ICustomerService _customerService;
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;

	public BookingService(IMapper mapper, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}

	public async Task<bool> CreateBooking(Guid id, DateTime date, Guid studioID)
    {
		var customer = _unitOfWork.Customer.getByAccount(id);
		var booking = new CreateBooking(customer.Id, date, studioID);
		var b = _mapper.Map<Scheduling>(booking);
		_unitOfWork.Schedule.Add(b);
		_unitOfWork.Save();
		return true;
	}
	public IEnumerable<Booking> GetAll() => _unitOfWork.Booking.GetAll().ToList();

    public IEnumerable<Booking> GetAllByCusId(Guid cusid)
    {
		var listboking = _unitOfWork.Booking.GetAllByCusId(cusid);
		return listboking;
    }

    
}