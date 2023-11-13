using System.Net.Mime;
using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface IImageService
{
    public String Get(Guid id);

}