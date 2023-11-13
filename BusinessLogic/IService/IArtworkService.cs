using BusinessLogic.DTOS.Artwork;
using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface IArtworkService
{
    List<ArtWork> getAllartwork();
    List<ArtWork> getAllawByStuId(Guid stuid);
    ArtWork CreateArtWork(CreateArtwork artwork);
    ArtWork UpdateArtWork(Guid id, ArtWork artwork);
    ArtWork GetArtWorkByID(Guid id);
    ArtWork DeleteArtWork(ArtWork artWork);

    public List<ArtWork> List(Guid Art);
}