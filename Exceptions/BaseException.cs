namespace job_scheduler_service.Exceptions
{
    public class BaseException: Exception
    {
        public string code {  get; set; }
        public string message { get; set; }
    }
}
