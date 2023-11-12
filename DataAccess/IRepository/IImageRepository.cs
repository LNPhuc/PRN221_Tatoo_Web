using DataAccess.DataAccess;
using DataAccess.IRepository.Generic;

namespace DataAccess.IRepository;

public interface IImageRepository : IGenericRepository<Image>
{
    String url(String id);
}