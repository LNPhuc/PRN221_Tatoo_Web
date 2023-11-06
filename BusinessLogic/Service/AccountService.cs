using AutoMapper;
using BusinessLogic.DTOS.Account;
using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository;
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

    
    public async Task CreateStudioAccount(CreateStudio account)
    {
        var company = _mapper.Map<Studio>(account);
        _unitOfWork.Studio.Add(company);
        _unitOfWork.Save();
    }
    
    public async Task CreateCustomerAccount(CreateCustomer account)
    {
        var c = _mapper.Map<Customer>(account);
        _unitOfWork.Customer.Add(c);
        _unitOfWork.Save();
    }

    public async Task<Account> Login(string UserName, string Pass)
    {
        var account =  await _unitOfWork.Account.GetAccount(UserName, Pass);
        if (account != null)
        {
            return account;
        }
        return null;
    }
}