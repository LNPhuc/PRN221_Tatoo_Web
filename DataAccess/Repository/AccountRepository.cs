using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace DataAccess.Repository;

public class AccountRepository : GenericRepository<Account>, IAccountRepository
{
    public AccountRepository(TatooWebContext context) : base(context)
    {
    }

    public async Task<Account> GetAccount(string UserName, string Pass)
    {
        var account = await _context.Accounts.FirstOrDefaultAsync(a => a.UserName.Equals(UserName) && a.Password.Equals(Pass));
        return account;
    }
}