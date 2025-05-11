using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.DTOs;

namespace API.Domain.IRepos
{
    public interface IAuthRepo
    {
        Task<User?> SignUp(SignUp signUp);
        Task<User?> SignIn(SignIn signIn);
    }
}