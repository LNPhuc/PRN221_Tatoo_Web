using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface ICustomerService
{
    IEnumerable<Customer> GetAll();
    Customer GetCusByAccountId(Guid id);
    Customer UdpateCustomer(Guid id, Customer customer);
}