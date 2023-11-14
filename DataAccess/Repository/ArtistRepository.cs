using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
{
    private readonly TatooWebContext _context;

    public ArtistRepository(TatooWebContext context) : base(context)
    {
        _context = context;
    }

    public void DeleteArtist(Guid id)
    {
        var artist = _context.Set<Artist>().Include(c => c.ArtWorks).FirstOrDefault(c => c.Id == id);
        _context.Artists.Remove(artist);
    }

    public Artist GetArtistById(Guid id)
    {
        var artist = _context.Set<Artist>().Include(c => c.Studio).FirstOrDefault(c => c.Id == id);
        return artist;
    }

    public List<Artist> GetArtistByStudioId(Guid id)
    {
        var artists = _context.Set<Artist>()
            .Include(c => c.Studio)
            .Where(s => s.StudioId == id)
            .ToList();
        return artists;
    }

    public List<Artist> SearchArtist(string name)
    {
        if (name == null)
        {
            var artists = _context.Set<Artist>().Include(c => c.Studio).ToList();
            return artists;
        }
        else
        {
            var artists = _context.Set<Artist>()
                .Include(c => c.Studio)
                .Where(s => s.Name.Contains(name))
                .ToList();
            return artists;
        }
    }

    public Artist UpdateArtist(Artist artist)
    {
        _context.Set<Artist>().Update(artist);
        return artist;
    }
}