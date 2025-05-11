using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Domain.DTOs;
using API.Domain.IDals;
using API.Domain.IRepos;
using API.Shared.Helper;

namespace API.Infrastructure.Dals
{
    public class AuthDal : IAuthDal
    {
        private readonly IAuthRepo _repo;
        public AuthDal(IAuthRepo authRepo)
        {
            _repo = authRepo;
        }

        public async Task<User?> SignUp(SignUp signUp)
        {
            return await _repo.SignUp(signUp);
        }

        public async Task<User?> SignIn(SignIn signIn)
        {
            return await _repo.SignIn(signIn);
        }
    }
}