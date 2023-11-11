using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository.UnitOfWork;
using DataAccessObject.Utils;

namespace BusinessLogic.Service;

public class VipmemberService : IVipmemberService
{
    private readonly IUnitOfWork _unitOfWork;
    public VipmemberService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public VipMember RegisterVip(Guid id, VipMember member)
    {
        _unitOfWork.Booking.GetAllByCusId(id);
        var add = _unitOfWork.VipMember.RegisterVipMember(member);
        _unitOfWork.Save();
        return add;


    }

    public Pagination<VipMember> ToPagination(string name, int pageIndex, int pageSize, Guid stuid)
    {
        var listVip = _unitOfWork.VipMember.GetVipByName(name, stuid);
        return _unitOfWork.VipMember.ToPagination(listVip, pageIndex, pageSize);
    }
}