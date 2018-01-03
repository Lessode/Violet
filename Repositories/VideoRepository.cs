using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Violet.Entities;

namespace Violet.Repositories
{
    public interface IVideoRepository : IGenericRepository<Video>
    {
        IEnumerable<Video> GetAllWithPagination(int skip = 0, int take = 0);
        int Count();
    }

    public class VideoRepository : GenericRepository<Video>, IVideoRepository
    {
        public VideoRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Video> GetAllWithPagination(int skip = 0, int take = 0)
        {
            if(take == 0)
            {
                return Entities.Include(x => x.VideoCategory).Include(x => x.VideoType).Skip(skip).AsEnumerable();
            }

            return Entities.Include(x => x.VideoCategory).Include(x => x.VideoType).Skip(skip).Take(take).AsEnumerable();
        }

        public int Count()
        {
            return Entities.Count();
        }
    }
}
