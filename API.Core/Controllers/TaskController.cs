using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        [HttpGet("AllTasks")]
        public IActionResult AllTasks()
        {
            var tasks = new List<object>
            {
                new {
                    TaskId = 1,
                    Title = "Complete Project Report",
                    Description = "Compile and finalize the project report by end of the week.",
                    AssignedTo = "John Doe",
                    Status = "In Progress",
                    DueDate = "2025-05-10"
                },
                new {
                    TaskId = 2,
                    Title = "Fix Login Bug",
                    Description = "Resolve the issue where users cannot log in with valid credentials.",
                    AssignedTo = "Jane Smith",
                    Status = "Open",
                    DueDate = "2025-05-08"
                },
                new {
                    TaskId = 3,
                    Title = "Prepare Presentation Slides",
                    Description = "Create slides for the monthly team meeting.",
                    AssignedTo = "Robert Brown",
                    Status = "Completed",
                    DueDate = "2025-05-05"
                },
                new {
                    TaskId = 4,
                    Title = "Update API Documentation",
                    Description = "Ensure all endpoints are correctly documented.",
                    AssignedTo = "Emily White",
                    Status = "In Progress",
                    DueDate = "2025-05-12"
                }
            };

            return Ok(tasks);
        }
    }
}