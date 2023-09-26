namespace etl_job_service.Exceptions.Ocr
{
    public class OCRWrongFileExtensionTypeException : BaseException
    {
        public OCRWrongFileExtensionTypeException(string unexpectedExtension)
        {
            this.code = "OCR0003";
            this.message = "The OCR system can only process file with extension of .jpg or .png. Getting " + unexpectedExtension;
        }
    }
}
