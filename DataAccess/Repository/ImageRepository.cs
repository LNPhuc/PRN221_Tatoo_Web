using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class ImageRepository: GenericRepository<Image>, IImageRepository
{
    public ImageRepository(TatooWebContext context) : base(context)
    {
    }

    public string url(String id)
    {
        return _context.Images.FirstOrDefault(i => i.EntityId == id).Source;
    }
}