using DataAccess.DataAccess;
using DataAccess.IRepository.Generic;
using DataAccessObject.Utils;

namespace DataAccess.IRepository;

public interface IVipMemberRepository : IGenericRepository<VipMember>
{
	IEnumerable<VipMember> GetVipByName(string name, Guid id);
	Pagination<VipMember> ToPagination(IEnumerable<VipMember> list, int pageIndex, int pageSize);
	VipMember RegisterVipMember(VipMember vp);
	bool IsVip(Guid cusid, Guid stuid);
}