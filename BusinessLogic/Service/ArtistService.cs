using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository.UnitOfWork;

namespace BusinessLogic.Service;

public class ArtistService : IArtistService
{
    private readonly IUnitOfWork _unitOfWork;

    public ArtistService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Artist GetArtistById(Guid id)
    {
        return _unitOfWork.Artist.GetById(id);
    }

    public List<Artist> SearchArtist(string name)
    {
        return _unitOfWork.Artist.SearchArtist(name);
    }

    public Artist UdpateArtist(Guid id, Artist artist)
    {
        var art = _unitOfWork.Artist.GetById(id);

        if (art.Name == artist.Name &&
            art.Experience == artist.Experience)
        {
            throw new Exception("Nothing change!");
        }
        art.Name = artist.Name;
        art.Experience = artist.Experience;
        var update = _unitOfWork.Artist.UpdateArtist(art);
        _unitOfWork.Studio.SaveChanges();
        return update;
    }
}