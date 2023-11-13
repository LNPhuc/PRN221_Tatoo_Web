using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;
using DataAccessObject.Utils;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class VipMemberRepository : GenericRepository<VipMember>, IVipMemberRepository
{
    public VipMemberRepository(TatooWebContext context) : base(context)
    {
    }

    public IEnumerable<VipMember> GetVipByName(string name, Guid id)
    {
        var list = _context.Set<VipMember>().Where(c => c.Studio.Id.Equals(id)).Include(c => c.Customer).ToList();
        return list;
    }

    public bool IsVip(Guid cusid, Guid stuid)
    {
        var vipmem = _context.Set<VipMember>().FirstOrDefault(c => c.CustomerId == cusid && c.StudioId == stuid);
        if (vipmem == null) return false;
        return true;
    }

    public VipMember RegisterVipMember(VipMember vp)
    {
        _context.VipMembers.Add(vp);
        return vp;
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