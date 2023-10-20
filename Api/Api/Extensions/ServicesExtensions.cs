using Business.Abstract;
using Business.Concrete;
using Data.RepoContext;
using Data.Repositories.Abstract;
using Data.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void DatabaseConnection(this IServiceCollection services, IConfiguration configuration)
        =>
            services.AddDbContext<RepositoryContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureBookRepository(this IServiceCollection services)
            => services.AddScoped<IBookRepository, BookRepository>();
        public static void ConfigureServiceManager(this IServiceCollection services)
            => services.AddScoped<IBookService, BookManager>();

     
        public static void ConfigureAutoMapper(this IServiceCollection services)
            => services.AddAutoMapper(typeof(Program));

    }
}
