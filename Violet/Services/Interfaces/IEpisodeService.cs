using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Violet.Entities;

namespace Violet.Services.Interfaces
{
    public interface IEpisodeService
    {
        IEnumerable<Episode> GetEpisodesForVideo(int id);
        Episode GetEpisode(int id);
    }
}
