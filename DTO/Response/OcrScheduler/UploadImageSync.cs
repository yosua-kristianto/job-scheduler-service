using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace etl_job_service.DTO.Response.OcrScheduler
{
    public class UploadImageSync
    {
        public string JobId { get; set; }
    }
}
