using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DTO
    {
    public class Offer
    {
            public int reqId { get; set; }
            public string reqPurpose { get; set; }
            public int BookId { get; set; }
            public string BookName { get; set; }
            public int? timeId { get; set; }
            public string timeDesc { get; set; }
            public DateTime? reqStartDate { get; set; }
            public DateTime? registerEndDate { get; set; }        
            public DateTime? reqEndDate { get; set; }
            public Nullable<double> payment { get; set; }
            public string extraInfo { get; set; }
            public static List<Offer> cToDTO(List<request_tbl> data)
            {

            var res = from b in data
                      select new Offer
                      {
                          reqId = b.reqId,
                          reqPurpose = b.reqPurpose,
                          BookId = b.BookId,
                          timeId = b.timeId,
                          reqStartDate = b.reqStartDate,
                          reqEndDate = (b.reqEndDate),
                          payment = b.payment,
                          extraInfo = b.extraInfo,
                          registerEndDate = b.RegisterEndDate
                      };

                return res.ToList();
            }

       
        public static List<request_tbl> DTOToc(List<Offer> data)
        {
            List<request_tbl> list=new List<request_tbl>();
            foreach (Offer item in data)
            {                
               list.Add(Offer.DTOToc(item));              
            }
            return list;
        }
        public static Offer cToDTO(request_tbl obj)
        {
            Offer res =
                      new Offer
                      {
                          reqId = obj.reqId,

                          reqPurpose = obj.reqPurpose,
                          BookId = obj.BookId,
                          timeId = obj.timeId,
                          reqStartDate = obj.reqStartDate,
                          reqEndDate = obj.reqEndDate,
                          registerEndDate = obj.RegisterEndDate,
                          payment = obj.payment,
                          extraInfo = obj.extraInfo
                      };

            return res;
        }

        public static request_tbl DTOToc(Offer obj)
            {
                request_tbl res =
                           new request_tbl
                           {
                               reqId = obj.reqId,
                               
                               reqPurpose = obj.reqPurpose,
                               BookId = obj.BookId,
                               timeId = obj.timeId,
                               reqStartDate = obj.reqStartDate,
                               reqEndDate = obj.reqEndDate,
                               RegisterEndDate = obj.registerEndDate,
                               payment = obj.payment,
                               extraInfo = obj.extraInfo
                           };

                return res;
            }
    }
}