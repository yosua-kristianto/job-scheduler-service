using Microsoft.AspNetCore.Mvc;

namespace etl_job_service.DataTransferObject
{
    /**
     * BaseResponse
     * 
     * This data transfer object (DTO) used for standardizing the response.
     */
    public class BaseResponse<T>
    {
        public bool status { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public T data { get; set; }

        public BaseResponse(bool status, int code, string message, T data) 
        { 
            this.status = status;
            this.code = code;
            this.message = message;
            this.data = data;
        }

        public static BaseResponse<T> Ok(string message, T data)
        {
            return new BaseResponse<T>(true, 200, message, data);
        }

        public static BaseResponse<T> Error(string message, T data) 
        {
            return new BaseResponse<T> (false, 500, message, data);
        }
    }
}
