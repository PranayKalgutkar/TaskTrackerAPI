using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Domain.DTOs
{
    public class User
    {
        public Guid UserId { get; set; }  // Maps to user_id
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = "User";
        public DateTime CreatedOn { get; set; }
    }
}