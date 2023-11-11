using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;
using DataAccessObject.Utils;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class VipMemberRepository: GenericRepository<VipMember>, IVipMemberRepository
{
	public VipMemberRepository(TatooWebContext context) : base(context)
	{

	}

	public IEnumerable<VipMember> GetVipByName(string name, Guid id)
	{
		var list = _context.Set<VipMember>().Where(c => c.Studio.Id.Equals(id)).Include(c => c.Customer).ToList();
		return list;
	}

	public Pagination<VipMember> ToPagination(IEnumerable<VipMember> list, int pageIndex, int pageSize)
	{
		var result = new Pagination<VipMember>
		{
			PageIndex = pageIndex,
			PageSize = pageSize,
			Items = list.Skip(pageIndex * pageSize).Take(pageSize).ToList(),
			TotalItemsCount = list.Count()
		};

		return result;
	}
}