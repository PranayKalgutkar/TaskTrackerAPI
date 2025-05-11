using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.DTOs;
using API.Shared.Helper;

namespace API.Domain.IDals
{
    public interface IAuthDal
    {
        Task<User?> SignUp(SignUp signUp);
        Task<User?> SignIn(SignIn signIn);
    }
}