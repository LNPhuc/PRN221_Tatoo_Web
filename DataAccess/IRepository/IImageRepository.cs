using DataAccess.DataAccess;
using DataAccess.IRepository.Generic;

namespace DataAccess.IRepository;

public interface IImageRepository : IGenericRepository<Image>
{
    string url(string id);
}