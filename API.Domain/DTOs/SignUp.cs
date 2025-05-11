using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Domain.DTOs
{
    public class SignUp : User
    {
        public string PasswordHash { get; set; } = null!;
        public string ConfirmedPasswordHash { get; set; } = null!;
    }
}