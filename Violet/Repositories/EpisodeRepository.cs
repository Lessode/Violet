using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Violet.Entities;

namespace Violet.Repositories
{
    public interface IEpisodeRepository : IGenericRepository<Episode>
    {
        IEnumerable<Episode> GetEpisodesForVideo(int id);
    }

    public class EpisodeRepository : GenericRepository<Episode>, IEpisodeRepository
    {
        public EpisodeRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Episode> GetEpisodesForVideo(int id)
        {
            return Entities.Where(x => x.VideoId == id).AsEnumerable();
        }
    }
}
