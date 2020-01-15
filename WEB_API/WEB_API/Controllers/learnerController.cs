using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using BLL;
namespace WEB_API.Controllers
{

    [RoutePrefix("api/learner")]
    public class learnerController : ApiController
    {
        [Route("getAll")]
        // GET: api/learner
        public IHttpActionResult Get()
        {
            return Ok(data.getAllLearners());
        }
        //[Route("getCurrentRequests")]
        //[HttpGet]
        ////GET: api/learner
        //public List<Offer> getCurrentRequests()
        //{

        //    List<Offer> res = data.getCurrentRequests();
        //    if (res.Count == 0)
        //    {
        //        return res;
        //    }
        //    else
        //        return res;
        //}
        [Route("GetCurrentLearningDates/{learnerid}")]
       // GET: api/learner
        public List<CurrentLearnings> getCurrentLearnings(int learnerid)

        {
            List<CurrentLearnings> res = data.GetCurrentLearnings(learnerid);
            return res;
}
        [Route("GetCategories")]
        public  List<Book> GetCategories()
        {
            List<Book> res = data.GetCategories();
            return res;
        }

        [Route("GetCurrentLearningDatesByCategory/{learnerid}/{bookId}")]
        public  List<CurrentLearnings> GetCurrentLearningByCategory(int learnerid, int bookId)
        {
            List<CurrentLearnings> res = data.GetCurrentLearningByCategory(learnerid,bookId);
            return res;
        }
        [Route("getColorForCategory/{category}")]
        public string getColorForCatergory(string category)
        {
            return data.getColorForCatergory(category);
        }

//[Route("addLearner")]
////POST: api/learner
//public void Post(Learner l)
//{
//    data.addLearner(l);
//    data.db.SaveChanges();
//    return;
//}
        [Route("addLearningPost")]
        //POST: api/learner
        [HttpPost]
        public string addLearningPost([FromBody]Matching newMatch)
        {
              data.addLearning(newMatch);
                
            data.db.SaveChanges();
            return "it's ok";
        }

        [Route("getCurrentRequestsPerLearner/{learnerId}")]
        [HttpGet]
        //post: api/learner
        public List<Offer> getCurrentRequestsPerLearner(int learnerId)
        {
            List<Offer> res = data.getCurrentRequests();
            if (res.Count == 0)
            {
                return res;
            }
            else
                return res;
        }


        [Route("getBooksForLearnerByDonorReqs/{learnerId}/{donorId}")]
        [HttpGet]
        public List<Request> getBooksForLearnerByDonorReqs(int learnerId, string donorId)
        {
            return BLL.SingleLearner.SingleLearnerForSingleDonorReqs(learnerId, donorId  + ".com");
        }

        [Route("getBooksForLearnerByDonorBooks/{learnerId}/{donorId}")]
        [HttpGet]
        public List<Book> getBooksForLearnerByDonorBooks(int learnerId, string donorId)
        {
            return BLL.SingleLearner.SingleLearnerForSingleDonorBooks(learnerId, donorId + ".com");
        }

        [Route("getLearnesForBookByReq/{rId}")]
        [HttpGet]
        public List<Learner> GetLearnesForBookByReq(int rId)
        {
            return BLL.SingleLearner.GetLearnesForBookByReq(rId);
        }

        [Route("getLearnesForBookByDonor/{bookId}/{donorId}")]
        [HttpGet]
        public List<Learner> GetLearnesForBookByDonor(int bookId,string donorId)
        {
            return BLL.SingleLearner.GetLearnesForBookByDonor(bookId,donorId+".com");
        }

        [Route("getLearnersByDonor/{donorEmail}")]
        [HttpGet]
        public List<Learner> GetLearnersByDonor(string donorEmail)
        {
           return BLL.SingleLearner.GetLearnersByDonor(donorEmail + ".com");
        }

        [Route("getBooksByDonor/{donorEmail}")]
        [HttpGet]
        public List<Book> getBooksByDonor(string donorEmail)
        {
            return BLL.SingleLearner.getBooksByDonor(donorEmail+".com");
        }
        [Route("getReqsByDonor/{donorEmail}")]
        [HttpGet]
        public List<Request> getReqsByDonor(string donorEmail)
        {
            return BLL.SingleLearner.getReqsByDonor(donorEmail + ".com");
        }



        [Route("editLearner")]
        // PUT: api/learner
        public string Put([FromBody]Learner l)
        {
            if (l == null)
            {
                return "no object was sent";
            }

            data.editLearner(l);
            data.db.SaveChanges();
            return "edit succeeded";
        }

        // DELETE: api/learner/5
        public void Delete(int id)
        {
            if (data.getAllLearners().Exists(l => l.learnerId == id))
                BLL.data.deleteLearner(id);
            else
                return;
        }


        [Route("check")]
        public bool checkGet(Learner l)
        {
            // compareTo צריך לברר לפי מה הוא מחפש ,אולי לדרוס את 
            if (data.getAllLearners().Contains(l))
            {
                return true;
                
            }
            return false;
        }
    }
}
