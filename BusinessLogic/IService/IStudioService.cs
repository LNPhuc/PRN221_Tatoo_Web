using BusinessLogic.DTOS.Studio;
using DataAccess.DataAccess;
using DataAccessObject.Utils;

namespace BusinessLogic.IService;

public interface IStudioService
{
    Pagination<Studio> Search(string name, int pageIndex, int pageSize);
    Studio GetById(Guid id);
    Studio Update(Guid id, Studio studio);
    Studio Delete(Guid id);
    Studio Create(Studio studio);
    Studio GetStudioByAccountId(Guid id);

    List<StudioItem> GetAllItem(string name);
}