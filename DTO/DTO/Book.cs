using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
namespace DTO
{
    
  
      public  class Book
        {
            public int BookId { get; set; }
            public string BookName { get; set; }
            public double? Bookpayment { get; set; }
            public string Bookinfo { get; set; }//תאור על הלימוד בספר זה
            public int? ParentId { get; set; }
            public int? AncestorId { get; set; }

        public static List<Book> cToDTO(List<Book_tbl> data)
            {
            var res = from b in data
                      select new Book
                      {
                          BookId = b.BookId,
                          BookName = b.BookName,
                          Bookpayment = b.bookpayment,
                          Bookinfo = b.Bookinfo,
                          ParentId = b.parentBookId,
                              AncestorId = 0
                          };

                return res.ToList();
            }

            public static List<Book_tbl> DTOToc(List<Book> data)
            {
                var res = from b in data
                          select new Book_tbl
                          {
                              BookId = b.BookId,
                              BookName = b.BookName,
                              bookpayment = b.Bookpayment,
                              Bookinfo = b.Bookinfo,
                              parentBookId= b.ParentId
                          };

                return res.ToList();
            }
        }
    }


