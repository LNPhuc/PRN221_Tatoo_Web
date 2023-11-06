using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService
{
	internal interface IArtWorkSevice
	{
		IEnumerable<ArtWork> GetArtWorks();
	}
}
