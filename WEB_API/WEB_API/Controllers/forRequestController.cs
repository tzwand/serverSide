using DTO;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEB_API.Controllers
{
    [RoutePrefix("api/forRequest")]
    public class forRequestController : ApiController
    {
       
        // GET: api/forRequest
        [Route("GetBooksWithAncestor")]
        public List<Book> GetBooksWithAncestor()
        {
            return data.getAllBooksWithAncester().ToList();
        }

 [Route("GetTimes")]
        public List<Time> GetTimes()
        {
            return data.getAllTimes().ToList();
        }
        [Route("GetOccupations")]
        //  GET: api/forRequest
        public List<Occupation> GetOccupations()
        {
            
            return data.GetOccupations().ToList();

        }
        [Route("GetBooks")]
        //  GET: api/forRequest
        public List<Book> GetBooks()
        {

        return data.getAllBooks().ToList();

        }
        //[Route("getRegularSum/{bookName}")]
        //public int getRegularSum(string bookName)
        //{

        //    return 100000;
        //}


        // POST: api/forRequest
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/forRequest/5
        public void Put(int id, [FromBody]string value)
        {
        }
        //post: api/ForRequest/request
        [Route ("addRequest")]
        [HttpPost]
        public void Post([FromBody]Request request)
        {
            data.addRequest(request);

        }
        [Route("addRequestList")]
        [HttpPost]
        public void addRequestListPost([FromBody]Request[] request)
        {
            foreach(Request r in request)
            {
            data.addRequest(r);
            }


        }

        // DELETE: api/forRequest/5
        public void Delete(int id)
        {
        }
    }
}
