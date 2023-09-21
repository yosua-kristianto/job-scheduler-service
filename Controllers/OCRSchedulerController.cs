using etl_job_service.DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace etl_job_service.Controllers
{
    [Route("api/ocr")]
    [ApiController]
    public class OCRSchedulerController : ControllerBase
    {
        [HttpPost("test")]
        public BaseResponse<int?> Test()
        {
             return BaseResponse<int?>.Ok("Successfully running your first API using .NET Core", 100);
        }

    }
}
