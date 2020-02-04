using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
   public class CurrentLearnings
    {



        public int learnerId { get; set; }
        public string learnerName { get; set; }
        //req start date
        public DateTime start { get; set; }
        //req end date
        public DateTime end { get; set; }
        //book name
        public string title { get; set; }
        public string extraInfo { get; set; }
        public int? bookId { get; set; }
        public int reqId { get; set; }
        public string donorName { get; set; }
        public string reqPurpose { get; set; }
        public DateTime? registerEndDate { get; set; }
        public Nullable<double> payment { get; set; }
        public Nullable<int> occuptionId { get; set; }
        public string genderid { get; set; }
        public int? timeId { get; set; }
        public string timeDesc { get; set; }

        public static List<CurrentLearnings> cToDTO(List<Matching_tbl>data)
        {
            var res = from p in data
                      select new CurrentLearnings
                      {
                          //reqId = p.request_tbl.reqId,
                          //donorName = p.request_tbl.donorName,
                          //reqPurpose = p.request_tbl.reqPurpose,
                          //registerEndDate = p.request_tbl.RegisterEndDate,
                      
                          //payment = p.request_tbl.payment,

                          //occuptionId = p.request_tbl.occuptionId,
                          //genderid = p.request_tbl.genderid,

                          timeId = p.request_tbl.timeId,
         timeDesc = p.request_tbl.time_tbl.timeDesc,
                          learnerName  = p.learners_tbl.learnerName,
                          start = (DateTime)p.request_tbl.reqStartDate,
                           end =(DateTime) p.request_tbl.reqEndDate,
                           title=p.Book_tbl.BookName,
                          extraInfo=  p.request_tbl.extraInfo,
                          bookId = p.Book_tbl.BookId
                      };
            return res.ToList();
        }

    }
}
