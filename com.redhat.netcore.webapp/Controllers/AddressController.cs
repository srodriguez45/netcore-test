using com.redhat.netcore.bll.logic;
using com.redhat.netcore.context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;

namespace com.redhat.netcore.webapp.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [DataContract]
    public class AddressController : AppController
    {

        protected AddressBll addressBll;

        public AddressController(DBApiContext context, IConfiguration configuration) : base(configuration)
        {
            this.addressBll = new AddressBll(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var statusCode = HttpStatusCode.BadRequest;

            try
            {
                var list = addressBll.GetAll();

                if (list.Count > 0)
                {
                    return SetResponse(list);
                }
                else
                {
                    statusCode = HttpStatusCode.NotFound;
                    this.Msg = Environment.GetEnvironmentVariable("NOTFOUND");
                }
            }
            catch (Exception e)
            {
                statusCode = HttpStatusCode.InternalServerError;
                this.Msg = e.Message;
            }

            return SetResponse(null, statusCode);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id = 0)
        {
            var statusCode = HttpStatusCode.BadRequest;

            try
            {
                var address = addressBll.GetById(id);

                if (address != null)
                {
                    return SetResponse(address);
                }
                else
                {
                    statusCode = HttpStatusCode.NotFound;
                    this.Msg = Environment.GetEnvironmentVariable("NOTFOUND");
                }
            }
            catch (Exception e)
            {
                statusCode = HttpStatusCode.InternalServerError;
                this.Msg = e.Message;
            }

            return SetResponse(null, statusCode);
        }

    }
}
