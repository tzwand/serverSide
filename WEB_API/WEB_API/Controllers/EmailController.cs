using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WEB_API.Controllers
{
    [RoutePrefix("api/email")]
    public class EmailController : ApiController
    {
       
        // GET: api/Email

       
        // GET: api/Email/5
        //[Route("sendEmail")]
        //// POST: api/Email
        //public IHttpActionResult Get()
        //{
        //    Email e = new Email();
        //    e.sendEmailViaWebApi();
        //    return Ok(" hello");
        //}

        //[Route("sendEmail")]
        //// POST: api/Email
        //public void Post([FromBody]string name)
        //{
        //    Email e = new Email(name);
        //    e.sendEmailViaWebApi(name);
        //}

        // PUT: api/Email/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Email/5
        public void Delete(int id)
        {
        }
    }
}
