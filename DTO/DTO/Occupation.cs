using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class Occupation
    {

        public int occuptionId { get; set; }
        public string occupationName { get; set; }
        public string gender { get; set; }
        public static List<Occupation> cToDTO(List<occuption_tbl> data)
        {
            var res = from p in data
                      select new Occupation
                      {
                          occuptionId = p.occuptionId,
                          occupationName = p.occupationName,
                          gender= p.gender
                      };

            return res.ToList();
        }
        public static List<occuption_tbl> DTOToC(List<Occupation> data)
        {
            var res = from p in data
                      select new occuption_tbl
                      {
                          occuptionId = p.occuptionId,
                          occupationName = p.occupationName,
                          gender = p.gender
                      };

            return res.ToList();
        }
    }
}