using etl_job_service.DTO;
using etl_job_service.Entity.Img;
using etl_job_service.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace etl_job_service.Controllers
{
    /**
     * OCRSchedulerController
     * 
     * This controller supposed to used for OCR Scheduler related functionalities
     */ 
    [Route("api/ocr")]
    [ApiController]
    public class OCRSchedulerController : ControllerBase
    {
        private readonly IImageProfileRepository repository;

        public OCRSchedulerController(IImageProfileRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("test")]
        public BaseResponse<List<ImageProfile>> Test()
        {
             return BaseResponse<List<ImageProfile>>.Ok(
                 "Successfully running your first API using .NET Core", 
                 repository.GetAll()
             );
        }

    }
}
