﻿
using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService
{
    public interface IArtworkService
    {
        List<ArtWork> getAllartwork();
        List<ArtWork> getAllawByStuId(Guid stuid);
        ArtWork CreateArtWork(ArtWork artwork);
        ArtWork UpdateArtWork(ArtWork artwork);
        ArtWork GetArtWorkByID(Guid id);
        ArtWork DeleteArtWork(ArtWork artWork);
    }
}
