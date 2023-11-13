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

	public Customer GetCusByAccountId(Guid id)
	{
		return _unitOfWork.Customer.GetCusById(id);
	}
    public Customer UdpateCustomer(Guid id, Customer customer)
    {
        var cus = _unitOfWork.Customer.GetCusById2(id);

        if (cus.Account.UserName == customer.Account.UserName &&
            cus.Account.Password == customer.Account.Password &&
            cus.FirstName == customer.FirstName &&
            cus.LastName == customer.LastName &&
            /*cus.Account.Email == customer.Account.Email &&*/
            cus.Account.Phone == customer.Account.Phone &&
            cus.Address == customer.Address)
        {
            throw new Exception("Nothing change!");
        }
        cus.Account.UserName = customer.Account.UserName;
        cus.Account.Password = customer.Account.Password;
        cus.FirstName = customer.FirstName;
        cus.LastName = customer.LastName;
        /*cus.Account.Email = customer.Account.Email;*/
        cus.Account.Phone = customer.Account.Phone;
        cus.Address = customer.Address;

        if(customer.Account.UserName == null || customer.Account.Password == null || customer.FirstName == null || customer.LastName == null || customer.Account.Phone == null || customer.Address == null )
        {
            throw new Exception("Please Enter Empty Place!");
        }
        var update = _unitOfWork.Customer.UpdateCustomer(cus);
        _unitOfWork.Customer.SaveChanges();
        return update;
    }
}