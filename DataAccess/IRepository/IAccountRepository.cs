using DataAccess.DataAccess;
using DataAccess.IRepository.Generic;

namespace DataAccess.IRepository;

public interface IAccountRepository : IGenericRepository<Account>
{
    Task<Account> GetAccount(string Email, string Pass);
    IEnumerable<Account> GetAll();
    Task<Account> GetEmail(string Email);
    Account GetById(Guid id);
    Account UpdateAccount(Account account);
    Task<Account> GetStatus(string status);
    void SaveChanges();
}