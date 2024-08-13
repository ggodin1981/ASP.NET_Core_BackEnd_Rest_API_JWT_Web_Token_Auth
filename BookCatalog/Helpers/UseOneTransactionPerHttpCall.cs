using BookCatalog.Common.Helper;
//using BookCatalog.Data.Repository;
using BookCatalog.Services;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data.SqlTypes;
using Microsoft.Extensions.Configuration;

namespace BookCatalog.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static void UseOneTransactionPerHttpCall(this IServiceCollection serviceCollection, AppSettings _appSettings, IsolationLevel level = IsolationLevel.ReadUncommitted)
        {
             
            serviceCollection.AddDbContext<AuthorizeContexts>(options => options.UseSqlServer(_appSettings.ConnectionString));
            serviceCollection.AddMvc();
             
        }
    }
}
