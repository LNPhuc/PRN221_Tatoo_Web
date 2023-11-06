using AutoMapper;
using BusinessLogic.IService;
using DataAccess.IRepository.UnitOfWork;

namespace BusinessLogic.Service;

public class CustomerService : ICustomerService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
}