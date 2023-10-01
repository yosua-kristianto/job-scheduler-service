using job_scheduler_service.DTO.Request.OcrScheduler;
using job_scheduler_service.DTO.Response.OcrScheduler;

namespace job_scheduler_service.Handler
{
    public interface IOcrSchedulerControllerHandler
    {
        /**
         * @public
         * UploadImageHandler
         * 
         * This API handle Upload Image with method below:
         * 
         * 1. Determine whatever the uploaded file is png / jpg / zip
         *      1.1 If The file is png or jpg
         *          1.1.1   Generate new name for the file with this format below
         *                  {FILE_EXTENSION}#{YmdHis}
         *          1.1.2   Rename the file as the 1.1.1
         *          1.1.3   Generate `ImageProfile` class
         *          1.1.4   Set image_original_name in 1.1.3 as `request.Image.Name`
         *          1.1.5   Set image_server_name in 1.1.3 as 1.1.1
         *          1.1.6   Set expected_ouput in 1.1.3 as `ExpectedOutput`
         *          1.1.7   Prepare `JobScheduler` class
         *          1.1.8   If the `InstantUpload` is 0
         *              1.1.8.1     Set schedule_date in 1.1.7 as `ScheduleDate`          
         *              1.1.8.2     Set is_synchronous in 1.1.7 as 0
         *          1.1.9   Else
         *              1.1.9.1     Set schedule_date in 1.1.7 as NOW()
         *          1.1.10  Save the 1.1.3 and 1.1.7
         *          1.1.11  Generate `MapImageProfileJobScheduler` class
         *          1.1.12  Save `image_id` in 1.1.11 as 1.1.3
         *          1.1.13  Save `schedule_id` in 1.1.11 as 1.1.7
         *          1.1.14  Save the 1.1.11
         *          1.1.15  Move the file to location that being registered in appsettings.json as DefaultFileStoragePath 
         *          1.1.16  If the `InstantUpload` is 0
         *              1.1.16.1    Call out Tesseract Instance (Other Project)
         *      1.2 If the file is zip
         *          1.2.1   Extract the image file within zip
         *          1.2.2   For every file within the extracted zip
         *              1.2.2.1 Do 1.1 for the file
         *              
         * @throws
         * OCR0001
         * OCR0002
         */
        public UploadImageSync UploadImageHandler(UploadImageSyncAsync request);

        /**
         * @async
         * @public
         * AsyncUploadImageHandler
         * 
         * This function handle call to UploadImageHandler Asynchronously.
         */
        public Task AsyncUploadImageHandler(UploadImageSyncAsync request);
    }
}
