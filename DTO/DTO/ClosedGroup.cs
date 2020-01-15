using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class ClosedGroup
    {
            public int GroupId { get; set; }
            public string groupName { get; set; }
            public Nullable<int> reqId { get; set; }
            public static List<ClosedGroup> cToDTO(List<closedGroup_tbl> data)
            {
                var res = from b in data
                          select new ClosedGroup
                          {
                              GroupId = b.GroupId,
                              groupName = b.groupName,
                              reqId = b.reqId

                          };

                return res.ToList();
            }

            public static List<closedGroup_tbl> DTOToc(List<ClosedGroup> data)
            {
                var res = from b in data
                          select new closedGroup_tbl
                          {
                              GroupId = b.GroupId,
                              groupName = b.groupName,
                              reqId = b.reqId

                          };

                return res.ToList();
            }
        }
    }

