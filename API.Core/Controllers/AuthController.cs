using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.DTOs;
using API.Domain.IDals;
using Microsoft.AspNetCore.Mvc;

namespace API.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthDal _dal;

        public AuthController(IAuthDal authDal)
        {
            _dal = authDal;
        }
        
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] User user)
        {
            var result = await _dal.AddUser(user);
            return Ok(result);
        }
    }
}