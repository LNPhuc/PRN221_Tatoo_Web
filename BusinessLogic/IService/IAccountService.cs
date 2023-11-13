using BusinessLogic.DTOS.Account;
using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface IAccountService
{
    Task CreateStudioAccount(CreateStudio account);
    IEnumerable<Account> GetAll();
    Task CreateCustomerAccount(CreateCustomer account);
    Task<Account> CheckEmail(string email);
    Task<Account> CheckStatus(string status);
    Account GetById(Guid id);
    Task<Account> Login(string Email, string Pass);
    Account DisableAccount(Guid id);
    Account ActivateAccount(Guid id);
}