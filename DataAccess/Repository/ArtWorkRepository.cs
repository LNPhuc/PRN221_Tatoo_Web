using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;

namespace DataAccess.Repository;

public class ArtWorkRepository: GenericRepository<ArtWork>, IArtWorkRepository
{
    public ArtWorkRepository(TatooWebContext context) : base(context)
    {
    }
}