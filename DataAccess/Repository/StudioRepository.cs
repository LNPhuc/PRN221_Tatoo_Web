using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;
using DataAccessObject.Utils;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repository;

public class StudioRepository: GenericRepository<Studio>, IStudioRepository
{
    private readonly TatooWebContext _context;
    public StudioRepository(TatooWebContext context) : base(context)
    {
        _context = context;     
    }

    public Studio Create(Studio studio)
    {
        _context.Set<Studio>().Add(studio);
        return studio;
    }

    public Studio Delete(Studio studio)
    {
        _context.Set<Studio>().Update(studio);
        return studio;
    }

    public Studio GetById(Guid id)
    {
        return _context.Set<Studio>().Include(Art => Art.Artists).FirstOrDefault(c => c.Id == id);
    }

    public bool IsChange(Studio stu1, Studio stu2)
    {
        var studio1 = _context.Set<Studio>().Entry(stu1);
        var studio2 = _context.Set<Studio>().Entry(stu2);
        if (studio1 == studio2)
        {
            return false;
        }
        return true;
    }

    public bool IsEmailExist(string email)
    {
        var check = _context.Set<Studio>().FirstOrDefault(c => c.StudioEmail == email);
        if(check == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool IsNameExist(string name)
    {
        var check = _context.Set<Studio>().FirstOrDefault(c => c.Name == name);
        if (check == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool IsPhoneExist(string phone)
    {
        var check = _context.Set<Studio>().FirstOrDefault(c => c.StudioPhone == phone);
        if (check == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void SaveChanges()
    {
        
        _context.SaveChanges();
    }

    public List<Studio> Search(string name)
    {
        
        if (name == null)
        {
            var studios = _context.Set<Studio>().Include(art => art.Artists).ToList();
            return studios;
        }
        else
        {
            var studios = _context.Set<Studio>()
                .Where(s => s.Name.Contains(name)).Include(art => art.Artists)
                .ToList();
            return studios;
        }
    }

    Studio IStudioRepository.Update(Studio studio)
    {
        _context.Set<Studio>().Update(studio);
        return studio;
    }

    public Pagination<Studio> ToPagination(IEnumerable<Studio> list, int pageIndex = 0, int pageSize = 10)
    {
        

        var result = new Pagination<Studio>
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            Items = list.Skip(pageIndex * pageSize).Take(pageSize).ToList(),
            TotalItemsCount = list.Count()
        };

        return result;
    }

    public Studio GetStudioByAccountId(Guid accountId)
    {
        var studio = _context.Set<Studio>().FirstOrDefault(s => s.AccountId == accountId);
        return studio;
    }
}