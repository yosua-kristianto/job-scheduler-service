using etl_job_service.DTO;
using etl_job_service.DTO.Request.OcrScheduler;
using etl_job_service.DTO.Response.OcrScheduler;
using etl_job_service.Handler;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

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
        private readonly IOcrSchedulerControllerHandler handler;

        public OCRSchedulerController(IOcrSchedulerControllerHandler handler)
        {
            this.handler = handler;
        }

        /**
         * @public
         * @api
         * @multipart
         * @post
         * 
         * UploadImageSync
         *  This API will upload image with extension of jpg or png. Or can just straight to upload zip file to begin with.
         *  You also expect response return from this API.
         * 
         * @header
         * Content-Type: multipart/form-data
         * 
         * @request
         * - image => file
         * - expected_output => string? (Not mandatory if you're not expecting the cer)
         * - schedule_time => string Date String Y-m-dTH:i:s (Only mandatory if instant_upload is 0)
         * - instant_upload => 1 | 0
         * 
         * @response
         * ```json
         * {
         *   "job_id": "some-uuid",
         * }
         * ```
         * response message: "The job will scheduled for {schedule_time}"
         */
        [HttpPost("file-upload-sync")]
        public BaseResponse<UploadImageSync> UploadImageSync([FromForm] UploadImageSyncAsync request)
        {
            UploadImageSync response = this.handler.UploadImageHandler(request);

            return BaseResponse<UploadImageSync>.Ok(("The job will scheduled for {Please add the schedule time}"), response);
        }

        /**
         * @public
         * @api
         * @multipart
         * @post
         * @async
         * 
         * UploadImageAsync
         *  Same as the sync one. But this thing more into asynchronous approach.
         *  
         * @header
         * Content-Type: multipart/form-data
         * 
         * @request
         * - image => file
         * - expected_output => string? (Not mandatory if you're not expecting the cer)
         * - schedule_time => string Date String Y-m-d H:i (Only mandatory if instant_upload is 0)
         * - instant_upload => 1 | 0
         * 
         * @response
         * response message: "Trust me bro"
         */
        [HttpPost("file-upload-async")]
        public void UploadImageAsync()
        {

        }

    }
}
