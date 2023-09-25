namespace etl_job_service.Exceptions.Ocr
{
    public class OCRAsynchronousInabilityException: BaseException
    {
        public OCRAsynchronousInabilityException() 
        {
            this.code = "OCR0002";
            this.message = "To enable direct OCR operation, you must not upload Zip operation or you will have the consequences.";
        }
    }
}
