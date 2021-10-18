using AdessoRideShare.Repository.Context.Concrete;
using AdessoRideShare.Repository.DataAccess.Concrete;
using AdessoRideShare.Repository.DataAccess.Interfaces;
using AdessoRideShare.Repository.EntityModel.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShare.Repository.DataAccess.Concrete
{
    public class TripRepository : RepositoryBase<Trip>, ITripRepository
    {
        private readonly RideShareDbContext _context;
        public TripRepository(RideShareDbContext context) : base(context)
        {
            _context = context;
        }


        public Task<List<Trip>> GetTripByFromIdToId(int fromId, int toId)
        {
            return _context.TravelPlans.Include(x => x.From)
                                        .Include(x => x.To).Where(x => x.FromId == fromId && x.ToId == toId && x.Status == 1).ToListAsync();
        }
    }
}
