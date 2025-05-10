using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.DTOs;
using API.Domain.IRepos;

namespace API.Infrastructure.Repos
{
    public class TaskRepo : ITaskRepo
    {
        public Task<string> AddUserTask(UserTask userTask)
        {
            throw new NotImplementedException();
        }
    }
}