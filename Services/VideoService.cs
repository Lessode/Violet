using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Violet.Entities;
using Violet.Helpers;
using Violet.Models;
using Violet.Repositories;
using Violet.Services.Interfaces;

namespace Violet.Services
{
    public class VideoService : IVideoService
    {
        private IVideoRepository _videoRepository;
        private Mapper<Video, VideoViewModel> _mapper;

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
            _mapper = new Mapper<Video, VideoViewModel>();
        }

        public async Task<bool> Create(VideoViewModel viewModel)
        {
            Video entity = _mapper.ViewModelToEntity(new Video(), viewModel);

            try
            {
                _videoRepository.Insert(entity);
                await _videoRepository.Save();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }         
        }

        public async Task<bool> Update(VideoViewModel viewModel)
        {
            Video entity = _mapper.ViewModelToEntity(new Video(), viewModel);

            try
            {
                _videoRepository.Update(entity);
                await _videoRepository.Save();

                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public VideoViewModel Get(int id)
        {
            Video entity = _videoRepository.GetById(id);

            return _mapper.EntityToViewModel(new VideoViewModel(), entity);
        }

        public IEnumerable<VideoViewModel> GetAll(int skip = 0, int take = 0)
        {
            IEnumerable<Video> videos = _videoRepository.GetAllWithPagination(skip, take);
            List<VideoViewModel> viewModels = new List<VideoViewModel>();

            if(videos.Any())
            {
                foreach (var item in videos)
                {
                    viewModels.Append(_mapper.EntityToViewModel(new VideoViewModel(), item));
                }
            }

            return viewModels.AsEnumerable();
        }
    }
}
