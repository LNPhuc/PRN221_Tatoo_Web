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

    public bool IsVip(Guid cusid, Guid studioId)
    {
        var checkvip = _unitOfWork.VipMember.IsVip(cusid, studioId);
        return checkvip;
    }

    public VipMember RegisterVip(Guid id, Guid StudioId, VipMember member)
    {
        var isallow = _unitOfWork.Booking.CheckBookingStatusByCusId(id, StudioId);
        if (isallow != null)
        {
            var add = _unitOfWork.VipMember.RegisterVipMember(member);
            _unitOfWork.Save();
            return add;
        }

        return null;
    }

    public Pagination<VipMember> ToPagination(string name, int pageIndex, int pageSize, Guid stuid)
    {
        var listVip = _unitOfWork.VipMember.GetVipByName(name, stuid);
        return _unitOfWork.VipMember.ToPagination(listVip, pageIndex, pageSize);
    }
}