using AdessoRideShare.Repository.EntityModel.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdessoRideShare.Repository.DataAccess.Interfaces
{
    public interface ITripRepository :IRepositoryBase<Trip>
    {
        Task<List<Trip>> GetTripByFromIdToId(int fromId, int toId);
    }
}
