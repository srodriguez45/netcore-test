using com.redhat.netcore.models.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace com.redhat.netcore.webapp.Controllers
{
    public class AppController : ControllerBase
    {
        protected CustomResponse responseDto;
        protected string Msg = null;
        protected IConfiguration Config;

        public AppController(IConfiguration configuration)
        {
            responseDto = new CustomResponse();
            this.Config = configuration;
        }

        public IActionResult SetResponse(object data, HttpStatusCode status = HttpStatusCode.OK)
        {
            responseDto.Data = data;
            responseDto.Status = status;
            responseDto.Message = Msg;

            return StatusCode((int)status, responseDto);

        }


    }

}