using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.DTOs;
using API.Shared.Helper;

namespace API.Domain.IDals
{
    public interface ITaskDal
    {
        Task<UserTask> AddUserTask(UserTask userTask);

    }
}