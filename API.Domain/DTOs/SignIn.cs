using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Domain.DTOs
{
    public class SignIn
    {
        public string Email { get; set; } = null!;
        public string? PasswordHash { get; set; } = null!;
    }
}