using Data.Postgres.Guest;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Data; 
public static  class Bootstrapper 
{
    public static void AddContexto(this IServiceCollection services, IConfiguration configurationManager) {
        var conectionString = configurationManager.GetSection("ConnectionStrings:PostgreSQL").Value;

        services.AddDbContext<HotelDbContext>(dbContextOptions => {
            dbContextOptions.UseNpgsql(conectionString, o => o.UseNodaTime());

        });

    }

    public static void AddInjection(this IServiceCollection services) 
    {
        services.AddScoped<IGuestRepository, GuestRepository>();
    }
}
