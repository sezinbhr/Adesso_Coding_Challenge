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
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public UsersController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute]GetUserByIdQuery request)
        {
            var resp = await _mediatr.Send(request);
            if (resp == null)
                return NotFound();

            return Ok(resp);
        }


   
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddUserCommand request)
        {
            var resp = await _mediatr.Send(request);
            return StatusCode(201, resp);
        }
    }
}