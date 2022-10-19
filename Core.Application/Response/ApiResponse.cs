using System.Runtime.Serialization;

namespace Core.Application.Response
{
    [DataContract]
    public class ApiResponse<T> : IApiResponse
    {
        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]
        public ResponseCode ResponseCode { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public T Data { get; set; }

        private ApiResponse()
        {
        }

        public ApiResponse(bool isSuccess, ResponseCode responseCode, T data = default) : this(isSuccess, responseCode, null, data)
        {

        }

        public ApiResponse(bool isSuccess, ResponseCode responseCode, string message, T data = default)
        {
            this.IsSuccess = isSuccess;
            this.ResponseCode = responseCode;
            this.Message = message;
            this.Data = data;
        }
    }
    public enum ResponseCode
    {
        Ok = 200,
        Created = 201,
        NoContent = 204,
        ResetContent = 205
    }
}
