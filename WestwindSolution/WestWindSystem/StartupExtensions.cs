using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WestWindSystem.BLL;
using WestWindSystem.DAL;

namespace WestWindSystem
{
   
        public static class StartupExtensions
        {
            public static void AddBackendDependencies(
                this IServiceCollection services,       // always have these parameters to be able to access service in your program.cs
                Action<DbContextOptionsBuilder> options) // this option attaches to option parameter inside program.cs after calling method addbackenddependencies
            {
                services.AddDbContext<WestwindContext>(options);

                services.AddTransient<BuildVersionServices>(serviceProvider => { //the service provider is the whole page model in index.cshtml.cs
                    var context = serviceProvider.GetRequiredService<WestwindContext>();
                    return new BuildVersionServices(context);
                });

                services.AddTransient<CategoryServices>(serviceProvider => {
                    var context = serviceProvider.GetRequiredService<WestwindContext>();
                    return new CategoryServices(context);
                });

            }
        }
    
}