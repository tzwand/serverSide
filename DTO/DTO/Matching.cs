using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DTO
{
   public class Matching
    {
            public int learnerId { get; set; }
            public int bookId { get; set; }
            public int reqId { get; set; }
            public Nullable<int> amount { get; set; }
            public static List<Matching> cToDTO(List<Matching_tbl> data)
            {
                var res = from b in data
                          select new Matching
                          {
                              learnerId = b.learnerId,
                              bookId = b.bookId,
                              reqId = b.reqId,
                              amount = b.amount
                          };

                return res.ToList();
            }

            public static List<Matching_tbl> DTOToc(List<Matching> data)
            {
                var res = from b in data
                          select new Matching_tbl
                          {
                              learnerId = b.learnerId,
                              bookId = b.bookId,
                              reqId = b.reqId,
                              amount = b.amount
                          };

                return res.ToList();

        }
        public static Matching cToDTO(Matching_tbl obj)
        {
            var res = new Matching
                      {
                          learnerId = obj.learnerId,
                          bookId = obj.bookId,
                          reqId = obj.reqId,
                          amount = obj.amount
                      };

            return res;
        }

        public static Matching_tbl DTOToc(Matching obj)
        {
            var res = new Matching_tbl
                      {
                          learnerId = obj.learnerId,
                          bookId = obj.bookId,
                          reqId = obj.reqId,
                          amount = obj.amount
                      };

            return res;
        }
    }
}

