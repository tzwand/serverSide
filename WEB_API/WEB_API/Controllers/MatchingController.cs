using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEB_API.Controllers
{
    [RoutePrefix("api/matching")]
    public class MatchingController : ApiController
    {


        [Route("deleteMatching")]
        [HttpDelete]
        public void deleteMatch(Matching m)
        {
            //in case we receive a match without an amount which isn't significant in this case
            Matching matching;
            matching = data.getAllMatchings().FirstOrDefault(match => match.learnerId == m.learnerId &&
              match.reqId == m.reqId && match.bookId == m.bookId);

            if (matching != null)
                BLL.data.deleteMatch(m);
            else
                return;
        }
        [Route("GetAllMatchings")]
        //  GET: api/forRequest
        public List<Matching> getAllMatchings()
        {

            return data.getAllMatchings().ToList();

        }
        [Route("getMatchByDonorLearnerAndBook/{donorId}/{learnerId}/{bookId}")]
        [HttpGet]
        //  GET: api/forRequest
        public Matching getMatchByDonorLearnerAndBook(string donorId,int learnerId,int bookId)
        {
            Matching m= data.getMatchByDonorLearnerAndBook(donorId+".com",learnerId,bookId);
            //delete the matching
            data.deleteMatch(m);
            return m;

        }
    }
}
