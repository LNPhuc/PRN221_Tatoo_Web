﻿using AutoMapper;
using BusinessLogic.DTOS.Artwork;
using BusinessLogic.IService;
using DataAccess.DataAccess;
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
        public ArtWork CreateArtWork(CreateArtwork artWork)
        {
            var art = _mapper.Map<ArtWork>(artWork);
            _unitOfWork.ArtWork.Add(art);
            _unitOfWork.Save();
            return art;
        }

        public ArtWork UpdateArtWork(Guid id ,ArtWork artwork)
        {
            var aw =_unitOfWork.ArtWork.GetArtWorkByID(id);
            if (aw.Title == artwork.Title &&
                aw.Position == artwork.Position &&
                aw.Size == artwork.Size && 
                aw.Time == artwork.Time &&
                aw.ArtistId == artwork.ArtistId)
            {
                throw new Exception("Nothing change!");
            }
            aw.Title = artwork.Title;
            aw.Position = artwork.Position;
            aw.Size = artwork.Size;
            aw.Time = artwork.Time;
            aw.ArtistId = artwork.ArtistId;
            var update = _unitOfWork.ArtWork.EditArtWork(aw);
            _unitOfWork.Save();
            return update;
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

        public List<ArtWork> List(Guid Art)
        {
            return _unitOfWork.ArtWork.List(Art);
        }
    }
}