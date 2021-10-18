using AdessoRideShare.Repository.EntityModel.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdessoRideShare.Repository.DataAccess.Interfaces
{
    public interface ITripUserRepository : IRepositoryBase<TripUsers>
    {
        Task<List<Trip>> GetTripTotalUsers(List<Trip> travelPlan);
        Task<List<Trip>> GetUserTripPlans(int userId);
        Task<List<Trip>> GetUserTripsByFromIdToId(int userId, int fromId, int toId);
    }
}
