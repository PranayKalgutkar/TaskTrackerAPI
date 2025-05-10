using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Domain.DTOs
{
    public class UserFile
    {
        public int FileId { get; set; }
        public string? FileName { get; set; }
    }
}