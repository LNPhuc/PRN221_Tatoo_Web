using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository;

namespace BusinessLogic.Service;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;

    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }
    public String Get(Guid id)
    {
        return _imageRepository.url(id.ToString());
    }
}