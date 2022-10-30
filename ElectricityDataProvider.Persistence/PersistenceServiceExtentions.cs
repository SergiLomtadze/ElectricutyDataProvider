using ElectricityDataProvider.BusinessLogic.Interfaces;
using ElectricityDataProvider.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricityDataProvider.Persistence
{
    public static class PersistenceServiceExtentions
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>((s, option) =>
                option.UseSqlServer(s.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection")));            
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
        }
    }
}
