using etl_job_service.Config;
using etl_job_service.DTO.Request.OcrScheduler;
using etl_job_service.DTO.Response.OcrScheduler;
using etl_job_service.Entity.Img;
using etl_job_service.Entity.Job;
using etl_job_service.Exceptions.Ocr;
using etl_job_service.Repository.Img;
using etl_job_service.Repository.Job;

namespace etl_job_service.Handler
{
    public class OcrSchedulerControllerHandler : IOcrSchedulerControllerHandler
    {
        private readonly IImageProfileRepository imageRepository;
        private readonly IJobRepository jobRepository;
        private readonly IJobSchedulerRepository jobSchedulerRepository;

        public OcrSchedulerControllerHandler(IImageProfileRepository imageRepository, IJobSchedulerRepository jobSchedulerRepository, IJobRepository jobRepository)
        {
            this.imageRepository = imageRepository;
            this.jobSchedulerRepository = jobSchedulerRepository;
            this.jobRepository = jobRepository;
        }

        /**
         * @public
         * OneByOneFileOperation
         * 
         * This function will actually do the operation one by one as stated on the Interface regarding the UploadImageHandler
         * 
         * @param
         *  request
         *      => Taken from controller
         *  fileExtension
         *      => Taken from UploadImageHandler function.
         */
        private UploadImageSync OneByOneFileOperation(UploadImageSyncAsync request, string fileExtension)
        {
            // Call out 1.1.3 to 1.1.6
            ImageProfile imageProfile;
            
            string fileServerName = fileExtension.ToUpper() + "#" + DateTime.Now.ToString("YMdHms") + "." + fileExtension;
            if (request.ExpectedOutput != null)
            {
                imageProfile = this.imageRepository.Create(request.Image.FileName, fileServerName, request.ExpectedOutput);
            }else
            {
                imageProfile = this.imageRepository.Create(request.Image.FileName, fileServerName);
            }

            // Call out 1.1.7 to 1.1.10
            DateTime scheduleTime = DateTime.Now;

            if(request.InstantUpload == 1 && request.ScheduleTime != null)
            {
                scheduleTime = (DateTime) request.ScheduleTime;
            }

            JobScheduler jobScheduler = this.jobSchedulerRepository.Create(scheduleTime, request.InstantUpload == 1);

            // Call out 1.1.14
            MapImageProfileJobScheduler job = this.jobRepository.Create(jobScheduler.id, imageProfile.id);

            // Call out 1.1.15
            string pathToStorage = EnvironmentVariables.GetInstance().Key("default-file-storage-path");

            FileStorage.WriteFile(pathToStorage, request.Image, (fileServerName));

            return new UploadImageSync() { JobId = job.id };
        }

        public async Task AsyncUploadImageHandler(UploadImageSyncAsync request)
        {
            this.UploadImageHandler(request);
        }

        public UploadImageSync UploadImageHandler(UploadImageSyncAsync request)
        {
            string fileExtension = Path.GetExtension(request.Image.FileName).ToLower();

            switch (fileExtension)
            {
                case ".png":
                case ".jpg":
                    this.OneByOneFileOperation(request, fileExtension);
                    break;

                case ".zip":
                    throw new Exception("Zip operation is not implemented yet.");
                    break;
                default:
                    throw new UploadedFileWrongExtensionException();
            }

            return null;
        }
    }
}
