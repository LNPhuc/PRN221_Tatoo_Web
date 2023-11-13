using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface IEquipmentService
{
    List<Equipment> Search(string name, Guid id);
}