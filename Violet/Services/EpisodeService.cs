using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Violet.Entities;
using Violet.Repositories;
using Violet.Services.Interfaces;

namespace Violet.Services
{
    public class EpisodeService : IEpisodeService
    {
        IEpisodeRepository _episodeRepository;

        public EpisodeService(IEpisodeRepository episodeRepository)
        {
            _episodeRepository = episodeRepository;
        }

        public Episode GetEpisode(int id)
        {
            return _episodeRepository.GetById(id);
        }

        public IEnumerable<Episode> GetEpisodesForVideo(int id)
        {
            return _episodeRepository.GetEpisodesForVideo(id);
        }
    }
}
