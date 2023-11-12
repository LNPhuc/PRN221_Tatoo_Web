using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace DataAccess.Repository;

public class AccountRepository : GenericRepository<Account>, IAccountRepository
{
    private readonly TatooWebContext _context;
    public AccountRepository(TatooWebContext context) : base(context)
    {
        _context= context;
    }
    public IEnumerable<Account> GetAll() => _context.Accounts.ToList();
	public Account GetById(Guid id)
	{
		return _context.Set<Account>().Include(c => c.Customers).Include(c => c.Studios).FirstOrDefault(c => c.Id == id);
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
    public async Task<Account> GetStatus(String status)
    {
        var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Status.Equals(status));
        return account;
    }
    public Account UpdateAccount(Account account)
    {
        _context.Set<Account>().Update(account);
        return account;
    }
    public void SaveChanges()
    {

        _context.SaveChanges();
    }
}