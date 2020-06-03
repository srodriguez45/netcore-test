using com.redhat.netcore.bll.logic;
using com.redhat.netcore.context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Runtime.Serialization;

namespace com.redhat.netcore.webapp.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [DataContract]
    public class UsersController : AppController
    {

        protected UserBll userBll;

        public UsersController(DBApiContext context, IConfiguration configuration) : base(configuration)
        {
            this.userBll = new UserBll(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var statusCode = HttpStatusCode.BadRequest;

            try
            {
                var list = userBll.GetAll();

                if (list.Count > 0)
                {
                    return SetResponse(list);
                }
                else
                {
                    statusCode = HttpStatusCode.NotFound;
                    this.Msg = this.Config.GetSection("Messages:NOTFOUND").Value;
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
                var user = userBll.GetById(id);

                if (user != null)
                {
                    return SetResponse(user);
                }
                else
                {
                    statusCode = HttpStatusCode.NotFound;
                    this.Msg = this.Config.GetSection("Messages:NOTFOUND").Value;
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
