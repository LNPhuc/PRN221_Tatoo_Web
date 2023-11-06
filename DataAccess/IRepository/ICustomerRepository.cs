using DataAccess.DataAccess;
using DataAccess.IRepository.Generic;

namespace DataAccess.IRepository;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    
}