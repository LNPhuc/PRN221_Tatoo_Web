using DataAccess.DataAccess;
using DataAccess.IRepository.Generic;

namespace DataAccess.IRepository;

public interface ICustomerRepository : IGenericRepository<Customer>
{
	IEnumerable<Customer> GetAll();
	Customer GetCusById(Guid id);
	Customer UpdateCustomer(Customer customer);
	void SaveChanges();
}