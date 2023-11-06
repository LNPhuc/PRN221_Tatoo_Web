using DataAccess.IRepository.Generic;
using DataAccess.DataAccess;

namespace DataAccess.IRepository;

public interface IAccountRepository : IGenericRepository<Account>
{
    Task<Account> GetAccount(String UserName, String Pass);
}