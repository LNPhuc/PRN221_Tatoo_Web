using AutoMapper;
using BusinessLogic.IService;
using DataAccess.IRepository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataAccess;

namespace BusinessLogic.Service
{
    public class ArtworkService : IArtworkService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ArtworkService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task GetAllArtWork()
        {

        }

        public List<ArtWork> List(Guid Art)
        {
            return _unitOfWork.ArtWork.List(Art);
        }
    }
}