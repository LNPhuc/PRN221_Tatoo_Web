using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;

namespace DataAccess.Repository;

public class ArtWorkRepository: GenericRepository<ArtWork>, IArtWorkRepository
{
    public ArtWorkRepository(TatooWebContext context) : base(context)
    {
    }

    public List<ArtWork> List(Guid Artist)
    {
        return _context.ArtWorks.Where(src => src.ArtistId == Artist).ToList();
    }
}