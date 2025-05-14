using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        public async Task<IActionResult> AddTask([FromForm] string taskJson, [FromForm] List<IFormFile> files)
        {
            var userTask = JsonSerializer.Deserialize<UserTask>(taskJson);
            if (userTask == null) return BadRequest("Invalid task data.");

            // Upload files and collect metadata
            var uploadedFiles = new List<UserFile>();

            foreach (var file in files)
            {
                // Upload to blob
                var blobUrl = "blob account url"; //await _fileService.UploadFileAsync(file); // Assume this uploads and returns the file URL

                uploadedFiles.Add(new UserFile
                {
                    FileName = file.FileName,
                    FilePath = blobUrl,
                    UploadedBy = userTask.CreatedBy,
                    UploadedOn = DateTime.UtcNow
                });
            }

            userTask.UserFile = uploadedFiles;

            // Save to DB
            var response = await _dal.AddUserTask(userTask);

            return Ok(response);

            // var userTask = JsonSerializer.Deserialize<UserTask>(taskJson);
            // var response = await _dal.AddUserTask(userTask);
            // return Ok(response);
        }
    }
}