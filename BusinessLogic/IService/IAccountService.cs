using BusinessLogic.DTOS.Account;
using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface IAccountService
{
    Task CreateStudioAccount(CreateStudio account);
    Task CreateCustomerAccount(CreateCustomer account);
    Task<Account> CheckEmail(String email);
    Account GetById(Guid id);
    Task<Account> Login(String Email, String Pass);
}