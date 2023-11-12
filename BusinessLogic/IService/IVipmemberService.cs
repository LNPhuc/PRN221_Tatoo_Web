using DataAccess.DataAccess;
using DataAccessObject.Utils;

namespace BusinessLogic.IService;

public interface IVipmemberService
{
	Pagination<VipMember> ToPagination(string name, int pageIndex, int pageSize,Guid stuId);
	VipMember RegisterVip(Guid id,Guid StudioId, VipMember member);
    bool IsVip(Guid id, Guid studioId);
}