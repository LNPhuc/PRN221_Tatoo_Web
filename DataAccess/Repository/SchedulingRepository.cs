using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;

namespace DataAccess.Repository;

public class SchedulingRepository: GenericRepository<Scheduling>, ISchedulingRepository
{
    public SchedulingRepository(TatooWebContext context) : base(context)
    {
    }
}