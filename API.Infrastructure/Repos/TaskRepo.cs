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
    public class TaskRepo : ITaskRepo
    {
        private readonly QueryHelper _queryHelper;
        private readonly DbConnectionHelper _conHelper;
        public TaskRepo(DbConnectionHelper conHelper, QueryHelper queryHelper)
        {
            _queryHelper = queryHelper;
            _conHelper = conHelper;
        }

        public async Task<UserTask> AddUserTask(UserTask userTask)
        {
            var query = _queryHelper.GetQuery("add_user_task");

            var parameters = new
            {
                p_title = userTask.Title,
                p_description = userTask.Description,
                p_user_files = userTask.UserFile,
                p_assigned_to = userTask.AssignedTo,
                p_status = userTask.Status,
                p_due_date = userTask.DueDate,
                p_created_by = userTask.CreatedBy,
                p_created_on = userTask.CreatedOn
            };

            using (var connection = _conHelper.CreateConnection())
            {
                var taskId = await connection.QuerySingleOrDefaultAsync<int>(query, parameters);

                userTask.TaskId = taskId;

                return userTask;
            }
        }
    }
}