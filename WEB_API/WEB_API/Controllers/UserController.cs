using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;


namespace WEB_API.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        // GET: api/User
        [Route("GetAll")]
        public IHttpActionResult Get()
        {
            return Ok(BLL.data.getAllRequests());
        }



        //-------------------------// POST: api/User--------------------------------------------------
        ///<summary>מחזיר את הלומד שלו מייל וסיסמא מתאימים</summary>
        [Route("findLearnerByEmailAndPassword")]
        public Learner PostLearnerByEmailAndPassword([FromBody]string[] arr)
        {
            return BLL.data.GetLearnerByEmailAndPassword(arr[0], arr[1]);
        }

        //מחזיר את התורם (מטבלת בקשות) שלו מייל וסיסמא מתאימים
        [Route("findDonorByEmailAndPassword")]
        [HttpPost]
        public Request PostDonorByEmailAndPassword([FromBody]string[] arr )
        {
            var y= BLL.data.GetRequestByEmailAndPassword(arr[0], arr[1]);
            return y;
        }
        [Route("resetPasswordPost")]
        [HttpPost]
        public string resetPasswordPost([FromBody]string[] arr)
        {
            string pass = BLL.logic.resetPassword(arr[0],arr[1],arr[2],arr[3]);
            return pass;
        }

        [Route("resetPasswordPostByEmail")]
        [HttpPost]
        public string resetPasswordPostByEmail([FromBody]string[] arr)
        {
            string pass = BLL.logic.resetPasswordByEmail(arr[0], arr[1]);
            return pass;
        }


        [Route("addLearner")]
        [HttpPost]
        public void addLearnerPost([FromBody]string[] arr)
        {
            data.addLearner(arr[0], arr[1]);
        }
        [Route("addDonor")]
        [HttpPost]
        public void addDonorPost([FromBody]string[] arr)
        {
            data.addDonor(arr[0], arr[1]);
        }
        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }
        [Route("PutDonor")]
        [HttpPut]

        public void PutDonor([FromBody]Request value)
        {
            data.editDonor(value);
        }
        [Route("PutLearner")]
        [HttpPut]
        public void PutLearner( [FromBody]Learner value)
        {
            data.editLearner(value);
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
