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
        public async Task<IActionResult> SignUp([FromBody] SignUp signUp)
        {
            var result = await _dal.SignUp(signUp);
            return Ok(result);
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignIn signIn)
        {
            var result = await _dal.SignIn(signIn);
            return Ok(result);
        }
    }
}