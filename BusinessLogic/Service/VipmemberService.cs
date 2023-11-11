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
	public Pagination<VipMember> ToPagination(string name, int pageIndex, int pageSize, Guid stuid)
	{
		var listVip = _unitOfWork.VipMember.GetVipByName(name,stuid);
		return _unitOfWork.VipMember.ToPagination(listVip, pageIndex, pageSize);
	}
}