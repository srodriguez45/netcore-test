using System;
using System.Net;

namespace com.redhat.netcore.models.dto
{
    public class CustomResponse
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

}
