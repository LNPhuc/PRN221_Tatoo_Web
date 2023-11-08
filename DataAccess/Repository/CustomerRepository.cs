using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class CustomerRepository: GenericRepository<Customer>, ICustomerRepository
{
	private readonly TatooWebContext _context;

	public CustomerRepository(TatooWebContext context) : base(context)
    {
		_context = context;
    }
	public IEnumerable<Customer> GetAll() => _context.Customers.Include(c => c.Account).ToList();
	public void SaveChanges()
	{
		_context.SaveChanges();
	}
	public Customer getByAccount(Guid guid)
	{
		return _context.Customers.FirstOrDefault(c => c.AccountId == guid);
	}


	public Customer GetCusById(Guid id)
	{
		return _context.Set<Customer>().Include(c => c.Account).FirstOrDefault(c => c.AccountId == id);
	}
    public Customer UpdateCustomer(Customer customer)
    {
        _context.Set<Customer>().Update(customer);
        return customer;
    }
    public void SaveChanges()
    {

        _context.SaveChanges();
    }
}