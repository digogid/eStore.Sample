using eStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eStore.Configuration
{
    public static class Configuration
    {
        public static IServiceCollection AddEntityContext(this IServiceCollection services, IConfiguration cfg)
        {
            services.AddDbContext<eStoreContext>(options =>
                options.UseSqlServer(cfg.GetConnectionString("eStore")));


            return services;
        }
    }
}
