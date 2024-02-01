using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Postgres.Guest;
public class GuestRepository : IGuestRepository 
{
    private readonly HotelDbContext _db;
    public GuestRepository(HotelDbContext hotelDbContext)
    {
        _db = hotelDbContext;
    }
    public async Task<int> Create(Domain.Entities.Guest guest) 
    {
        _db.Guests.Add(guest);
        await _db.SaveChangesAsync();
        return guest.Id;
    }

    public Task<Domain.Entities.Guest> Get(int Id) 
    {
        throw new NotImplementedException();
    }
}
