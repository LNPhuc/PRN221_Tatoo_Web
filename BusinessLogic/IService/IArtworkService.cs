
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataAccess;

namespace BusinessLogic.IService
{
    public interface IArtworkService
    {
        public List<ArtWork> List(Guid Art);
    }
}
