using AutoMapper;
using BusinessLogic.DTOS.Artist;
using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository.UnitOfWork;

namespace BusinessLogic.Service;

public class ArtistService : IArtistService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ArtistService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public Artist CreateArtist(CreateArtist artist)
    {
        var ac = _mapper.Map<Artist>(artist);
        _unitOfWork.Artist.Add(ac);
        _unitOfWork.Save();
        return ac;
    }

    public Artist GetArtistById(Guid id)
    {
        return _unitOfWork.Artist.GetArtistById(id);
    }

    public List<Artist> GetArtistByStudioId(Guid id)
    {
        return _unitOfWork.Artist.GetArtistByStudioId(id);
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
            throw new Exception("Nothing change!");
        art.Name = artist.Name;
        art.Experience = artist.Experience;
        var update = _unitOfWork.Artist.UpdateArtist(art);
        _unitOfWork.Studio.SaveChanges();
        return update;
    }
}