using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository.UnitOfWork;
using DataAccessObject.Utils;

namespace BusinessLogic.Service;

public class EquipmentService : IEquipmentService
{
	private readonly IUnitOfWork _unitOfWork;
	public EquipmentService(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public Pagination<Equipment> Search(string name, int pageIndex, int pageSize)
	{
		var stu = _unitOfWork.Equipment.Search(name);
		return _unitOfWork.Equipment.ToPagination(stu, pageIndex, pageSize);
	}
}