using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DTO
{
    public class Time //: IDtoAble<Time, time_tbl>
    {
        public int timeId { get; set; }
        public string timeDesc { get; set; }

        public Time cToDTO(time_tbl obj)
        {
            Time res = new Time
                      {
                          timeId = obj.timeId,
                          timeDesc = obj.timeDesc
                      };

            return res;
        }

        public time_tbl DTOToC(Time obj)
        {
            time_tbl res = 
                       new time_tbl
                      {
                          timeId = obj.timeId,
                          timeDesc = obj.timeDesc
                      };
            return res;
           
        }
        public static List<Time> cToDTO(List<time_tbl> data)
        {
            var res = from t in data
                      select new Time
                      {
                          timeId = t.timeId,
                          timeDesc = t.timeDesc
                      };

            return res.ToList();
        }
        public static List<time_tbl> DTOToC(List<Time> data)
        {
            var res = from t in data
                      select new time_tbl
                      {
                          timeId = t.timeId,
                          timeDesc = t.timeDesc
                      };

            return res.ToList();
        }
        //כרגע לא לשימוש
        //פונקציות אלה יועדו לשימוש עם האינטרפיס הגנרי שכרגע התיאשתי ממנו
        //   public List<Time> cToDTO(List<time_tbl> data)
        //    {
        //        var res = from t in data
        //                  select new Time
        //                  {
        //                      timeId = t.timeId,
        //                      timeDesc = t.timeDesc
        //                  };

        //        return res.ToList();
        //    }
        //    public List<time_tbl> DTOToC(List<Time> data)
        //    {
        //        var res = from t in data
        //                  select new time_tbl
        //                  {
        //                      timeId = t.timeId,
        //                      timeDesc = t.timeDesc
        //                  };

        //        return res.ToList();
        //    }  
        //}
    }
}