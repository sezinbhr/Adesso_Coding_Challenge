using AdessoRideShare.Repository.EntityModel.Interface;
using System.Collections.Generic;

namespace AdessoRideShare.Repository.EntityModel.Concrete
{
    public class User : BaseEntityModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
