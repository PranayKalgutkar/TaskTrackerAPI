using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.DTOs;
using API.Domain.IDals;
using API.Shared.Helper;
using Microsoft.AspNetCore.Mvc;

namespace API.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthDal _dal;
        private readonly JwtTokenHelper _jwtHelper;

        public AuthController(IAuthDal authDal, JwtTokenHelper jwtTokenHelper)
        {
            _dal = authDal;
            _jwtHelper = jwtTokenHelper;
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
            if (result == null)
            {
                return Unauthorized("Invalid credentials");
            }
            var token = _jwtHelper.GenerateToken(result.UserId, result.Email, result.Role);
            return Ok(new
            {
                token,
                result
            });
        }
    }
}