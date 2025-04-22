using System.Net;
using JuegoImpostor.Models;

namespace JuegoImpostor.Services
{
    public static class ResponseService
    {
        public static Task<ResponseModel> Response(string message, object? data, ErrorModel error = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            ResponseModel responseModel = new();
            responseModel.StatusCode = (int)statusCode;
            responseModel.Message = message;
            responseModel.Data = data;
            responseModel.Error = error;

            return Task.FromResult(responseModel);
        }
    }
}
