using Microsoft.AspNetCore.Mvc;

namespace etl_job_service.DTO
{
    /**
     * BaseResponse
     * 
     * This data transfer object (DTO) used for standardizing the response.
     * 
     * @public boolean status
     * This attribute marking the status of the API. Return true if the response is not negative clause, and false for the error scenario
     * 
     * @public int code
     * This attribute marking the return code of the API. See http.cat for more information.
     * 
     * @public string message
     * This attribute contains the message of the response. 
     * 
     * @public T data
     * This attribute is the actual data response for the API.
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

        /**
         * @static
         * Ok
         * 
         * Use this function whatever you need fast Ok response with message.
         */ 
        public static BaseResponse<T> Ok(string message, T data)
        {
            return new BaseResponse<T>(true, 200, message, data);
        }

        /**
         * @static
         * Error
         * 
         * Use this function whatever you need fast error response with message.
         */
        public static BaseResponse<T> Error(string message, T data) 
        {
            return new BaseResponse<T> (false, 500, message, data);
        }
    }
}
