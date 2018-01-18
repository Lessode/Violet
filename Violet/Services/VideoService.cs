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

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task<bool> Create(Video video)
        {
            try
            {
                _videoRepository.Insert(video);
                await _videoRepository.Save();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }         
        }

        public async Task<bool> Update(Video video)
        {
            try
            {
                _videoRepository.Update(video);
                await _videoRepository.Save();

                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Video Get(int id)
        {
            return _videoRepository.GetById(id);
        }

        public IEnumerable<Video> GetAllWithPagination(int skip = 0, int take = 0)
        {
            IEnumerable<Video> videos = _videoRepository.GetAllWithPagination(skip, take);

            return videos.AsEnumerable();
        }
    }
}
