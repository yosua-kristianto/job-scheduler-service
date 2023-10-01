using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace job_scheduler_service.DTO.Request.OcrScheduler
{
    public class UploadImageSyncAsync
    {
        [Required]
        [DataType(DataType.Upload)]
        [FromForm(Name = "image")]
        public IFormFile Image { get; set; }

        [FromForm(Name = "expected_output")]
        public string? ExpectedOutput { get; set; }


        [FromForm(Name = "schedule_time")]
        public DateTime? ScheduleTime { get; set; }

        [Required]
        [Range(0, 1, ErrorMessage = "Value for {0} must be 0 or 1")]
        [FromForm(Name = "instant_upload")]
        public int InstantUpload { get; set; }
    }
}
