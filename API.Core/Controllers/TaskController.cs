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
    public class TaskController : ControllerBase
    {
        private readonly ITaskDal _dal;
        public TaskController(ITaskDal dal)
        {
            _dal = dal;
        }
        [HttpPost, Route("addtask")]
        public async Task<IActionResult> AddTask([FromBody] UserTask userTask)
        {
            var response = await _dal.AddUserTask(userTask);
            return Ok(response);
        }
    }
}