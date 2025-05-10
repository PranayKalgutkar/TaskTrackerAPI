using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Domain.DTOs
{
    public class UserTask
    {
        public int TaskId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<UserFile>? UserFile { get; set; }
        public Guid AssignedTo { get; set; }
        public int Status { get; set; }
        public DateTime DueDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}