using CVFilter.Domain.Core.ServiceResponse.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Domain.Core.ServiceResponse
{
    public class ServiceResponse<T> : IServiceResponse<T> where T : class
    {
        public int HttpResponse { get; set; }
        public bool Status { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public ServiceResponse(int httpResponse, bool status, T data, string message)
        {
            HttpResponse = httpResponse;
            Status = status;
            Data = data;
            Message = message;
        }

        public ServiceResponse(int httpResponse, bool status,string message)
        {
            HttpResponse = httpResponse;
            Status = status;
            Message = message;
        }

        public ServiceResponse(int httpResponse, bool status, T data)
        {
            HttpResponse = httpResponse;
            Status = status;
            Data = data;
        }

        public ServiceResponse(int httpResponse, bool status)
        {
            HttpResponse = httpResponse;
            Status = status;
        }

    }
}
