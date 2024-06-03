using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Cdv.People.Models;

[assembly: FunctionsStartup(typeof(Cdv.People.Startup))]

namespace Cdv.People
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
            builder.Services.AddDbContext<PeopleContext>(
                options => options.UseSqlServer(connectionString));
        }
    }
}
