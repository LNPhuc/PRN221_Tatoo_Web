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

    public async Task<Account> GetAccount(string Email, string Pass)
    {
        var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Email.Equals(Email) && a.Password.Equals(Pass));
        return account;
    }

    public async Task<Account> GetEmail(string email)
    {
        var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Email.Equals(email));
        return account;
    }
}