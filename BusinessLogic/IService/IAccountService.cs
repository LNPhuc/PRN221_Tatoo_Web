using BusinessLogic.DTOS.Account;
using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface IAccountService
{
    Task CreateStudioAccount(CreateStudio account);
    IEnumerable<Account> GetAll();
    Task CreateCustomerAccount(CreateCustomer account);
    Task<Account> CheckEmail(String email);
    Task<Account> CheckStatus(String status);
    Account GetById(Guid id);
    Task<Account> Login(String Email, String Pass);
    Account DisableAccount(Guid id);
    Account ActivateAccount(Guid id);
}