using AdessoRideShare.Repository.Context.Concrete;
using AdessoRideShare.Repository.DataAccess.Concrete;
using AdessoRideShare.Repository.DataAccess.Interfaces;
using AdessoRideShare.Repository.EntityModel.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShare.Repository.DataAccess.Concerete
{
    public class TripUserRepository : RepositoryBase<TripUsers>, ITripUserRepository
    {
        private readonly RideShareDbContext _context;
        public TripUserRepository(RideShareDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Trip>> GetUserTripPlans(int userId) => await _context.TravelPlanUsers.Include(x => x.TravelPlan).Include(x => x.User).Where(x => x.UserId == userId).Select(x => x.TravelPlan).ToListAsync();

        public async Task<List<Trip>> GetUserTripsByFromIdToId(int userId, int fromId, int toId) => await _context.TravelPlanUsers.Include(x => x.TravelPlan).Include(x => x.User).Where(x => x.TravelPlan.FromId == fromId && x.TravelPlan.ToId == toId && x.UserId == userId && x.Status == 1).Select(x => x.TravelPlan).ToListAsync();

        public async Task<List<Trip>> GetTripTotalUsers(List<Trip> travelPlan)
        {
            foreach (var item in travelPlan)
            {
                item.TotalPassenger = await _context.TravelPlanUsers.Where(x => x.TravelPlanId == item.Id).SumAsync(x => x.SeatCount);
            }
            return travelPlan;
        }
    }
}
