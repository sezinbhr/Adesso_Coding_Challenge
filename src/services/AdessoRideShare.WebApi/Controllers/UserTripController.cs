using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdessoRideShare.API.Application.Command;
using AdessoRideShare.API.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdessoRideShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTripController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public UserTripController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetUserTripQuery query)
        {
            var resp = await _mediatr.Send(query);
            if (resp == null)
                return NotFound();

            return Ok(resp);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute]GetTripUserByIdQuery query)
        {
            var resp = await _mediatr.Send(query);
            if (resp == null)
                return NotFound();

            return Ok(resp);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddUserTripCommand request)
        {
            var resp = await _mediatr.Send(request);
            return StatusCode(201, resp);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateUserTripCommand request)
        {
            return Ok(await _mediatr.Send(request));
        }

 

    }
}