using DataAccess.DataAccess;
using DataAccess.IRepository.Generic;
using DataAccessObject.Utils;

namespace DataAccess.IRepository;

public interface IStudioRepository : IGenericRepository<Studio>
{
    List<Studio> Search(string name);
    Studio GetById(Guid id);
    Studio Update(Studio studio);
    Studio Delete(Studio studio);
    Studio Create(Studio studio);
    void SaveChanges();
    bool IsEmailExist(string email);
    bool IsNameExist(string name);
    bool IsPhoneExist(string phone);
    bool IsChange(Studio stu1, Studio stu2);
    Pagination<Studio> ToPagination(IEnumerable<Studio> list, int pageIndex, int pageSize);
    Studio GetStudioByAccountId(Guid accountId);
}