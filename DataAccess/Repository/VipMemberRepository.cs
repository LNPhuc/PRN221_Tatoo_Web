using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;

namespace DataAccess.Repository;

public class VipMemberRepository: GenericRepository<VipMember>, IVipMemberRepository
{
    public VipMemberRepository(TatooWebContext context) : base(context)
    {
    }
}