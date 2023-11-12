using DataAccess.DataAccess;
using DataAccess.IRepository.Generic;
using DataAccessObject.Utils;

namespace DataAccess.IRepository;

public interface IEquipmentRepository : IGenericRepository<Equipment>
{
	List<Equipment> Search(String name, Guid stuid);
	Pagination<Equipment> ToPagination(IEnumerable<Equipment> list, int pageIndex, int pageSize);

}