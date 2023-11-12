using DataAccess.DataAccess;
using DataAccessObject.Utils;

namespace BusinessLogic.IService;

public interface IEquipmentService
{
	List<Equipment> Search(string name, Guid id);
}