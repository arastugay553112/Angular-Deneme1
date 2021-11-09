using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode,String messsage=null)
        {
            this.StatusCode = statusCode;
            this.Message = messsage ?? GetDefaultMessageForStatus(statusCode);
        }

    
        public int StatusCode { get; set; }
        public String Message { get; set; }
        private string GetDefaultMessageForStatus(int statusCode)
        {
            String errorMessage = String.Empty;
            switch (statusCode)
            {
                case 400:
                    errorMessage = "A bad request,you have made";
                    break;
                case 401:
                    errorMessage = "Authorized error";
                    break;
                case 404:
                    errorMessage = "Resource not found";
                    break;
                case 500:
                    errorMessage = "Server Error";
                    break;

            }
            return errorMessage;

        }

    }
}
