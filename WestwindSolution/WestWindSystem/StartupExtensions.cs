using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WestwindSystem.BLL;
using WestWindSystem.BLL;
using WestWindSystem.DAL;

namespace WestWindSystem
{
   
        public static class StartupExtensions
        {
            public static void AddBackendDependencies(   //extension methods always need to be in static class
                this IServiceCollection services,       // always have these parameters to be able to access service in your program.cs
                Action<DbContextOptionsBuilder> options) // this option attaches to option parameter inside program.cs after calling method addbackenddependencies
            {
                services.AddDbContext<WestwindContext>(options);

                services.AddTransient<BuildVersionServices>(serviceProvider => 
                { //the service provider is the whole page model in index.cshtml.cs
                    var context = serviceProvider.GetRequiredService<WestwindContext>();
                    return new BuildVersionServices(context);
                });

                services.AddTransient<CategoryServices>(serviceProvider => 
                {
                    var context = serviceProvider.GetRequiredService<WestwindContext>();
                    return new CategoryServices(context);
                });

                services.AddTransient<ProductServices>(serviceProvider =>
                {
                    var context = serviceProvider.GetRequiredService<WestwindContext>();
                    return new ProductServices(context);
                });

                services.AddTransient<RegionServices>(serviceProvider =>
                {
                    var context = serviceProvider.GetRequiredService<WestwindContext>();
                    return new RegionServices(context);
                });

                services.AddTransient<TerritoryServices>(serviceProvider =>
                {
                    var contetxt = serviceProvider.GetRequiredService<WestwindContext>();
                    return new TerritoryServices(contetxt);
                });

        }
        }
    
}