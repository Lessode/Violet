using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Violet.Entities;
using Violet.Models;

namespace Violet.Services.Interfaces
{
    public interface IVideoService
    {
        Task<bool> Create(Video viewModel);
        Task<bool> Update(Video viewModel);
        Video Get(int id);
        IEnumerable<Video> GetAllWithPagination(int skip = 0, int take = 0);
    }
}
