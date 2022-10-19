using System.Net;

namespace Core.Application.Response
{
    public interface IApiResponse
    {
        bool IsSuccess { get; set; }
        ResponseCode ResponseCode { get; set; }
        string Message { get; set; }
    }
}
