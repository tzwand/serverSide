using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class Request
    {
        public int reqId { get; set; }
        public string donorName { get; set; }
        public string donorEmail { get; set; }
        public string reqPurpose { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int?   timeId { get; set; }
        public string timeDesc { get; set; }
        public DateTime? reqStartDate { get; set; }
        public DateTime? registerEndDate { get; set; }

        public DateTime? reqEndDate { get; set; }
        public DateTime? sosDate { get; set; }
        public Nullable<double> payment { get; set; }
        public Nullable<double> sosPayment { get; set; }
        public Nullable<int> occuptionId { get; set; }
        public string genderid { get; set; }
        public string password { get; set; }
        public string extraInfo { get; set; }
        //BLL כשיש לו שם ספר וזמן מאנגולר,וקודים שלהם מה DTO לפונקציות הבאות מגיע אובייקט ה
        public static List<Request> cToDTO(List<request_tbl> data)
        {
            
            var res = from b in data
                      select new Request
                      {
                          reqId = b.reqId,
                          donorName = b.donorName,
                          donorEmail = b.donorEmail,
                          reqPurpose = b.reqPurpose,
                          BookId =b.BookId,                  
                          timeId = b.timeId,
                          reqStartDate = b.reqStartDate,
                          reqEndDate =  b.reqEndDate,
                          registerEndDate=b.RegisterEndDate,
                          sosDate = b.sosDate,
                          payment = b.payment,
                          sosPayment = b.sosPayment,
                          occuptionId = b.occuptionId,
                          genderid = b.genderid,
                          password = b.password,
                          extraInfo =b.extraInfo
                      };

            return res.ToList();
        }

        public static List<request_tbl> DTOToc(List<Request> data)
        {
            var res = from b in data
                      select new request_tbl
                      {
                          reqId = b.reqId,
                          donorName = b.donorName,
                          donorEmail = b.donorEmail,
                          reqPurpose = b.reqPurpose,
                          BookId = b.BookId,
                          timeId = b.timeId,
                          reqStartDate = b.reqStartDate,
                          reqEndDate = b.reqEndDate,
                          RegisterEndDate = b.registerEndDate,
                          sosDate = b.sosDate,
                          payment = b.payment,
                          sosPayment = b.sosPayment,
                          occuptionId = b.occuptionId,
                          genderid = b.genderid,
                          password = b.password,
                          extraInfo = b.extraInfo
                      };

            return res.ToList();
        }
        public static Request cToDTO(request_tbl obj)
        {
             Request res = 
                       new Request
                      {
                          reqId = obj.reqId,
                          donorName = obj.donorName,
                          donorEmail = obj.donorEmail,
                          reqPurpose = obj.reqPurpose,
                          BookId = obj.BookId,
                          timeId = obj.timeId,
                          reqStartDate = obj.reqStartDate,
                           registerEndDate = obj.RegisterEndDate,
                           reqEndDate = obj.reqEndDate,
                          sosDate = obj.sosDate,
                          payment = obj.payment,
                          sosPayment = obj.sosPayment,
                          occuptionId = obj.occuptionId,
                          genderid = obj.genderid,
                          password = obj.password,
                          extraInfo = obj.extraInfo
                      };

            return res;
        }

        public static request_tbl DTOToc(Request obj)
        {
            request_tbl res = 
                       new request_tbl
                       {
                          reqId = obj.reqId,
                          donorName = obj.donorName,
                          donorEmail = obj.donorEmail,
                          reqPurpose = obj.reqPurpose,
                          BookId = obj.BookId,
                          timeId = obj.timeId,
                          reqStartDate = obj.reqStartDate,
                          reqEndDate = obj.reqEndDate,
                          RegisterEndDate = obj.registerEndDate,
                          sosDate = obj.sosDate,
                          payment = obj.payment,
                          sosPayment = obj.sosPayment,
                          occuptionId = obj.occuptionId,
                          genderid = obj.genderid,
                          password = obj.password,
                          extraInfo = obj.extraInfo
                      };

            return res;
        }
    }
}


    

