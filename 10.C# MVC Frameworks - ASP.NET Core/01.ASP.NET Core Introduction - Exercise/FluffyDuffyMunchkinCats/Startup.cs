namespace FluffyDuffyMunchkinCats
{
    using Data;
    using FluffyDuffyMunchkinCats.Infrastructures.Extentions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CatsDbContext>(options =>
                options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CatsDb;Integrated Security=True;"));
        }

        public void Configure(IApplicationBuilder app)
            => app
                .UseDatabaseMigration()
                .UseStaticFiles()
                .UseHtmlContentType()
                .UseRequestHandlers()
                .UseNotFoundHandler();
    }
}