using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;
using DataAccessObject.Utils;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class EquipmentRepository : GenericRepository<Equipment>, IEquipmentRepository
{
    private readonly TatooWebContext _context;

    public EquipmentRepository(TatooWebContext context) : base(context)
    {
        _context = context;
    }

    public List<Equipment> Search(string name, Guid stuid)
    {
        if (name == null)
        {
            var equipment = _context.Set<Equipment>().Include(c => c.Studio).Where(c => c.Studio.Id == stuid).ToList();
            return equipment;
        }
        else
        {
            var equipment = _context.Set<Equipment>()
                .Include(c => c.Studio)
                .Where(s => s.Name.Contains(name) && s.Studio.Id == stuid).ToList();
            return equipment;
        }
    }

    public Pagination<Equipment> ToPagination(IEnumerable<Equipment> list, int pageIndex = 0, int pageSize = 10)
    {
        var result = new Pagination<Equipment>
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            Items = list.Skip(pageIndex * pageSize).Take(pageSize).ToList(),
            TotalItemsCount = list.Count()
        };

        return result;
    }
}