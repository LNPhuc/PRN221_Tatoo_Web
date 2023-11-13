using AutoMapper;
using BusinessLogic.DTOS.Account;
using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.DataAccess.Enum;
using DataAccess.IRepository.UnitOfWork;

namespace BusinessLogic.Service;

public class AccountService : IAccountService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Account GetById(Guid id)
    {
        return _unitOfWork.Account.GetById(id);
    }

    public IEnumerable<Account> GetAll()
    {
        return _unitOfWork.Account.GetAll().ToList();
    }

    public async Task CreateStudioAccount(CreateStudio account)
    {
        var company = _mapper.Map<Studio>(account);
        var image = new Image(Guid.NewGuid(), account.Image, company.Id.ToString());
        _unitOfWork.Image.Add(image);
        _unitOfWork.Studio.Add(company);
        _unitOfWork.Save();
    }

    public async Task CreateCustomerAccount(CreateCustomer account)
    {
        var c = _mapper.Map<Customer>(account);
        _unitOfWork.Customer.Add(c);
        _unitOfWork.Save();
    }

    public async Task<Account> Login(string Email, string Pass)
    {
        var account = await _unitOfWork.Account.GetAccount(Email, Pass);
        if (account != null) return account;
        return null;
    }

    public async Task<Account> CheckEmail(string email)
    {
        var account = await _unitOfWork.Account.GetEmail(email);
        if (account != null) return account;
        return null;
    }

    public async Task<Account> CheckStatus(string status)
    {
        var account = await _unitOfWork.Account.GetStatus(status);
        if (account != null) return account;
        return null;
    }

    public Account DisableAccount(Guid id)
    {
        var acc = _unitOfWork.Account.GetById(id);

        acc.Status = Status.INACTIVE.ToString();
        var update = _unitOfWork.Account.UpdateAccount(acc);
        _unitOfWork.Account.SaveChanges();
        return update;
    }

    public Account ActivateAccount(Guid id)
    {
        var acc = _unitOfWork.Account.GetById(id);

        acc.Status = Status.ACTIVE.ToString();
        var update = _unitOfWork.Account.UpdateAccount(acc);
        _unitOfWork.Account.SaveChanges();
        return update;
    }
}