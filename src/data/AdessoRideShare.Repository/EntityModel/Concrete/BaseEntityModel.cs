using AdessoRideShare.Repository.EntityModel.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdessoRideShare.Repository.EntityModel.Concrete
{
    public class BaseEntityModel : IBaseEntityModel
    {
        public int Id { get; set; }
    }
}
