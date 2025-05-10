using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.DTOs;
using API.Domain.IDals;
using API.Shared.Helper;

namespace API.Infrastructure.Dals
{
    public class TaskDal : ITaskDal
    {
        public Task<ApiResponse<string>> AddUserTask(UserTask userTask)
        {
            throw new NotImplementedException();
        }
    }
}