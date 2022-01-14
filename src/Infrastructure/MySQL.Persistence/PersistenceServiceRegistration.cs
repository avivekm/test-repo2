using MySQL.Application.Contracts.Persistence;
using MySQL.Infrastructure.EncryptDecrypt;
using MySQL.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MySQL.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(configuration.GetConnectionString("ApplicationConnectionString"),
            new MySqlServerVersion(new Version(8, 0, 11))
            ));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            return services;
        }
    }
}
