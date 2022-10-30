using ElectricityDataProvider.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityDataProvider.BusinessLogic.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<AggregatedElData> AggregatedElDatas { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
