using Application.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CustomerProductOrder.API
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(o =>
                o.UseSqlServer(
                            configuration.GetConnectionString("DefaultConnection"),
                                      b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        }
    }
}
