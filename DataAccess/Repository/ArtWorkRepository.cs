using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class ArtWorkRepository: GenericRepository<ArtWork>, IArtWorkRepository
{
    private readonly TatooWebContext _context;
    public ArtWorkRepository(TatooWebContext context) : base(context)
    {
        _context = context;
    }
    public ArtWork CreateArtWork(ArtWork artWork)
    {
        _context.ArtWorks.Add(artWork);
        return artWork; 
    }

    public ArtWork DeleteArtWork(ArtWork artWork)
    {
        _context.ArtWorks.Remove(artWork);
        return null;
    }

    public ArtWork EditArtWork(ArtWork artWork)
    {      
        _context.ArtWorks.Update(artWork);
        return artWork;
    }

    public List<ArtWork> getAllArtwork()
    {
        var list = _context.Set<ArtWork>().Include(c => c.Artist).ToList();
        return list;
    }

    public List<ArtWork> getAllArtworkByStuId(Guid stuid)
    {
        var list = _context.Set<ArtWork>().Include(c => c.Artist).Where(c => c.Artist.StudioId == stuid).ToList();
        return list;
    }

    public ArtWork GetArtWorkByID(Guid id)
    {
        if (id == null || _context.ArtWorks == null)
        {
            return null;
        }

        var artwork =  _context.ArtWorks.Include(c=>c.Artist).FirstOrDefault(m => m.Id == id);
        return artwork;


    }
}