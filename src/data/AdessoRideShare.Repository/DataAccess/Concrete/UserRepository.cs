using AdessoRideShare.Repository.Context.Concrete;
using AdessoRideShare.Repository.DataAccess.Concrete;
using AdessoRideShare.Repository.DataAccess.Interfaces;
using AdessoRideShare.Repository.EntityModel.Concrete;

namespace AdessoRideShare.Repository.DataAccess.Concerete
{
    public class UserRepository : RepositoryBase<User>,IUserRepository
    {
        private readonly RideShareDbContext _context;
        public UserRepository(RideShareDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
