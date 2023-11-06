using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;

namespace DataAccess.Repository;

public class EquipmentRepository: GenericRepository<Equipment>, IEquipmentRepository
{
    public EquipmentRepository(TatooWebContext context) : base(context)
    {
    }
}