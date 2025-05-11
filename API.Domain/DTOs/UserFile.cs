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
    public string? FilePath { get; set; }      // Full or relative path to the file (e.g., Blob URL)
    public Guid UploadedBy { get; set; }       // User ID of the uploader
    public DateTime UploadedOn { get; set; }   // Timestamp of upload
}

}