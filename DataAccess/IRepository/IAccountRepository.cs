using DataAccess.IRepository.Generic;
using DataAccess.DataAccess;

namespace DataAccess.IRepository;

public interface IAccountRepository : IGenericRepository<Account>
{
    Task<Account> GetAccount(String Email, String Pass);
    IEnumerable<Account> GetAll();
    Task<Account> GetEmail(String Email);
    Account GetById(Guid id);
    Account UpdateAccount(Account account);
    Task<Account> GetStatus(String status);
    void SaveChanges();
}