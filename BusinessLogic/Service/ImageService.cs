using BusinessLogic.IService;
using DataAccess.IRepository;

namespace BusinessLogic.Service;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;

    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public string Get(Guid id)
    {
        return _imageRepository.url(id.ToString());
    }
}