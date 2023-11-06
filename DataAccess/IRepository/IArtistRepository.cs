using DataAccess.DataAccess;
using DataAccess.IRepository.Generic;

namespace DataAccess.IRepository;

public interface IArtistRepository : IGenericRepository<Artist>
{
    List<Artist> SearchArtist(string name);  
    Artist UpdateArtist(Artist artist);
    
}