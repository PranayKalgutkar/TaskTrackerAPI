using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.DTOs;
using API.Domain.IRepos;
using API.Shared.Helper;
using Dapper;

namespace API.Infrastructure.Repos
{
    public class AuthRepo : IAuthRepo
    {
        private readonly QueryHelper _queryHelper;
        private readonly DbConnectionHelper _conHelper;
        public AuthRepo(DbConnectionHelper conHelper, QueryHelper queryHelper)
        {
            _queryHelper = queryHelper;
            _conHelper = conHelper;
        }

        public async Task<User?> SignUp(SignUp signUp)
        {
            var query = _queryHelper.GetQuery("SignUp");

            var parameters = new
            {
                p_full_name = signUp.FullName,
                p_email = signUp.Email,
                p_password_hash = signUp.PasswordHash,
                p_role = signUp.Role
            };

            using var connection = _conHelper.CreateConnection();
            var signedUpUser = await connection.QuerySingleOrDefaultAsync<User>(query, parameters);
            return signedUpUser;
        }
        public async Task<User?> SignIn(SignIn signIn)
        {
            var query = _queryHelper.GetQuery("SignIn");
            
            var parameters = new 
            {
                p_email = signIn.Email,
                p_password_hash = signIn.PasswordHash 
            }; 

            using var connection = _conHelper.CreateConnection();
            var signedInUser = await connection.QuerySingleOrDefaultAsync<User>(query, parameters);
            return signedInUser;
        }
    }
}