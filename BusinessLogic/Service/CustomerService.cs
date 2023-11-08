using AutoMapper;
using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository.UnitOfWork;

namespace BusinessLogic.Service;

public class CustomerService : ICustomerService
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;

	public CustomerService(IMapper mapper, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}



	public IEnumerable<Customer> GetAll() => _unitOfWork.Customer.GetAll().ToList();

	public Customer GetCusById(Guid id)
	{
		return _unitOfWork.Customer.GetCusById(id);
	}

}