using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Yue3.Model.Result
{
    public class HttpResponse : Result
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.Unused;

        public Exception? Exception { get; set; }

        public string? Message { get; set; }

        public System.Net.Http.Headers.HttpResponseHeaders? Headers { get; set; }
    }

    public class HttpResponse<T> : HttpResponse
    {
        public T? Data { get;set; }

        public static implicit operator HttpResponse<T>(HttpResponse<Yue3.Model.OpenFrp.Response.BaseResponse<T>> @base)
        {
            if (@base.Data is { } data) 
            {
                return new HttpResponse<T>
                {
                    Exception = @base.Exception,
                    StatusCode = @base.StatusCode,
                    Headers = @base.Headers,
                    Data = data.Data,
                    Message = !data.Flag ? $"{data.Message}" : default,
                };
            }
            return new HttpResponse<T> { Exception = @base.Exception, StatusCode = @base.StatusCode };
        }
        public static implicit operator HttpResponse<T>(HttpResponse<Yue3.Model.NatayarkAuth.Response.BaseResponse<T>> @base)
        {
            if (@base.Data is { } data)
            {
                return new HttpResponse<T>
                {
                    Exception = @base.Exception,
                    StatusCode = @base.StatusCode,
                    Headers = @base.Headers,
                    Data = data.Data,
                    Message = data.Code is not HttpStatusCode.OK ? $"{data.Message}" : default,
                };
            }
            return new HttpResponse<T> { Exception = @base.Exception, StatusCode = @base.StatusCode };
        }

        public static implicit operator HttpResponse<T>(HttpResponse<Yue3.Model.OpenFrp.Response.BaseResponse2<T>> @base)
        {
            if (@base.Data is Yue3.Model.OpenFrp.Response.BaseResponse2<T> { } data)
            {
                
                return new HttpResponse<T>
                {
                    Exception = @base.Exception,
                    StatusCode = @base.StatusCode,
                    Headers = @base.Headers,
                    Data = data.Data,
                    Message = @base.Data.Code is not HttpStatusCode.OK ? $"{data.Message}" : default,
                };
            }
            return new HttpResponse<T> { Exception = @base.Exception, StatusCode = @base.StatusCode };
        }
    }
}
