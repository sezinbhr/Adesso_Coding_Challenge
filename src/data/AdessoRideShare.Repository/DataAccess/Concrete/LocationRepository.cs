using AdessoRideShare.Repository.Context.Concrete;
using AdessoRideShare.Repository.EntityModel.Concrete;
using AdessoRideShare.Repository.DataAccess.Interfaces;

namespace AdessoRideShare.Repository.DataAccess.Concrete

{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        private readonly RideShareDbContext _context;
        public LocationRepository(RideShareDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
