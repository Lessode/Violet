using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Violet.Entities;

namespace Violet.Repositories
{
    public interface ISettingsRepository : IGenericRepository<Settings>
    {
        Settings GetSettings();
    }

    public class SettingsRepository : GenericRepository<Settings>, ISettingsRepository
    {
        public SettingsRepository(DbContext context) : base(context)
        {
        }

        public Settings GetSettings()
        {
            return Entities.LastOrDefault();
        }
    }
}
