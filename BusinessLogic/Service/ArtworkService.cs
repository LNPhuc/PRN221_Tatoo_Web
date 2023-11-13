using AutoMapper;
using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ArtWork CreateArtWork(ArtWork artWork)
        {
            var art = _mapper.Map<ArtWork>(artWork);
            _unitOfWork.ArtWork.Add(art);
            _unitOfWork.Save();
            return artWork;
        }

        public ArtWork UpdateArtWork(ArtWork artwork)
        {
            _unitOfWork.ArtWork.EditArtWork(artwork);
            _unitOfWork.Save();
            return artwork;
        }

        public ArtWork GetArtWorkByID(Guid id)
        {
            var artwork = _unitOfWork.ArtWork.GetArtWorkByID(id);
            return artwork;
              
        }

        public ArtWork DeleteArtWork(ArtWork artWork)
        {
            _unitOfWork.ArtWork.DeleteArtWork(artWork);
            _unitOfWork.Save();
            return null;
        }

        public List<ArtWork> getAllartwork()
        {
            return _unitOfWork.ArtWork.getAllArtwork();
        }

        public List<ArtWork> getAllawByStuId(Guid stuid)
        {
            return _unitOfWork.ArtWork.getAllArtworkByStuId(stuid);
        }
    }
}