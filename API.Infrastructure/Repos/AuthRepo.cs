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

        public async Task<User> AddUser(User user)
        {
            var query = _queryHelper.GetQuery("AddUser"); // Fetch INSERT INTO users(...) query

            var parameters = new
            {
                p_full_name = user.FullName,
                p_email = user.Email,
                p_password_hash = user.PasswordHash,
                p_role = user.Role,
                p_created_on = user.CreatedOn
            };

            using var connection = _conHelper.CreateConnection();

            var createdUserId = await connection.QuerySingleOrDefaultAsync<Guid>(query, parameters);

            user.UserId = createdUserId;

            return user;
        }
    }
}