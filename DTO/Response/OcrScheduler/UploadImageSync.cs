using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace job_scheduler_service.DTO.Response.OcrScheduler
{
    public class UploadImageSync
    {
        public string JobId { get; set; }
    }
}
