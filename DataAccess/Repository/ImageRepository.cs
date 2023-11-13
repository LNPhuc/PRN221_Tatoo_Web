using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;

namespace DataAccess.Repository;

public class ImageRepository : GenericRepository<Image>, IImageRepository
{
    public ImageRepository(TatooWebContext context) : base(context)
    {
    }

    public string url(string id)
    {
        return _context.Images.FirstOrDefault(i => i.EntityId == id).Source;
    }
}