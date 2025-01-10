using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Engine.DTOs.ApiResponseModel
{
    public class ApiResponse
    {

        public object Data { get; set; }

        public bool Success { get; set; }
        public List<ApiResponseMessage> ApiResponseMessages { get; set; }
        public ApiResponse(string message)
        {
            Success = false;
            ApiResponseMessages = new List<ApiResponseMessage>
            {
                new ApiResponseMessage
                {
                    Message = message,
                    MessageTypeEnum = MessageTypeEnum.Error
                }
            };
        }

        public ApiResponse()
        {
            Success = true;
            ApiResponseMessages = new List<ApiResponseMessage>();
        }

    }

}
