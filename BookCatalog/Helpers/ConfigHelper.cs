using BookCatalog.Common.Helper;
using BookCatalog.Data.Repository.Contract;
using BookCatalog.Data.Repository.Implementation;
using BookCatalog.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options; 
using BookCatalog.Data.Entities;
using BookCatalog.Data;
namespace BookCatalog.Helpers
{
    public class ConfigHelper
    {
        public static void ConfigureService(WebApplicationBuilder builder)
        {
            var serviceProvider = builder.Services.AddOptions().Configure<AppSettings>(builder.Configuration.GetSection("AppSettings")).BuildServiceProvider();
            // Set the value in AppSettings
            var appSettings = serviceProvider.GetRequiredService<IOptions<AppSettings>>().Value;
            // Add your DbContext and other services here        
            builder.Services.AddDbContext<LibraryContext>(options =>
                           options.UseSqlServer(appSettings.ConnectionString));
            builder.Services.AddScoped<IConnectionStringProvider, ConnectionStringProvider>();           
            serviceProvider.Dispose();           
            builder.Services.UseOneTransactionPerHttpCall(appSettings);
        }
    }
}
