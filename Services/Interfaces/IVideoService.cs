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
        Task<bool> Create(VideoViewModel viewModel);
        Task<bool> Update(VideoViewModel viewModel);
        VideoViewModel Get(int id);
        IEnumerable<VideoViewModel> GetAll(int skip = 0, int take = 0);
    }
}
