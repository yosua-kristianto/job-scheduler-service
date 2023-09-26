namespace etl_job_service.Exceptions.Ocr
{
    public class UploadedFileWrongExtensionException : BaseException
    {
        public UploadedFileWrongExtensionException()
        {
            this.code = "OCR0001";
            this.message = "The uploaded file must be image with type of jpg, png, or zip.";
        }
    }
}
