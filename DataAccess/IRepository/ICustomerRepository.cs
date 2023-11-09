using DataAccess.DataAccess;
using DataAccess.IRepository.Generic;

namespace DataAccess.IRepository;

public interface ICustomerRepository : IGenericRepository<Customer>
{
	Customer getByAccount(Guid guid);
	IEnumerable<Customer> GetAll();
	Customer GetCusById(Guid id);
	Customer GetCusById2(Guid id);
	Customer UpdateCustomer(Customer customer);
	void SaveChanges();
}