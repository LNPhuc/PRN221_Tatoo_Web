using DataAccess.DataAccess;
using DataAccess.IRepository.Generic;

namespace DataAccess.IRepository;

public interface IArtWorkRepository : IGenericRepository<ArtWork>
{
    ArtWork CreateArtWork(ArtWork artWork);
    ArtWork EditArtWork(ArtWork artWork);
    ArtWork GetArtWorkByID(Guid id);
    ArtWork DeleteArtWork(ArtWork artWork);
    
}