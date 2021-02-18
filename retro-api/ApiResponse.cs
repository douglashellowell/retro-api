using System;
using Newtonsoft.Json;

namespace retro_api
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        [JsonProperty]
        public string Message { get; }


        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return "Resource not found";
                case 500:
                    return "Internal server error";
                default:
                    return "an error occured";
            }
        }
    }
}
