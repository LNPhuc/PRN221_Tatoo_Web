using DataAccess.DataAccess;
using DataAccessObject.Utils;

namespace BusinessLogic.IService;

public interface IEquipmentService
{
	Pagination<Equipment> Search(string name, int pageIndex, int pageSize);
}