using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Domain.DTOs
{
    public class User
    {
        public Guid UserId { get; set; }  // Maps to user_id
        public string FullName { get; set; } = null!;  // Maps to full_name
        public string Email { get; set; } = null!;     // Maps to email
        public string PasswordHash { get; set; } = null!; // Maps to password_hash
        public string Role { get; set; } = "User";     // Maps to role
        public DateTime CreatedOn { get; set; }        // Maps to created_on
    }
}