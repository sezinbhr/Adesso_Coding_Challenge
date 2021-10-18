using AdessoRideShare.API.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdessoRideShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public TripController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetTripQuery query)
        {
            var resp = await _mediatr.Send(query);
            if (resp == null)
                return NotFound();

            return Ok(resp);
        }

        
    }
}