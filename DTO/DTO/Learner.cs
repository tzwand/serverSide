using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{

    public class Learner
        {
            public int learnerId { get; set; }
            public string learnerName { get; set; }
            public string learnerEmail { get; set; }
            public string gender { get; set; }
            public int? occuptionId { get; set; }
            public DateTime? startDate { get; set; }
            public DateTime? endDate { get; set; }
            public int? groupId { get; set; }
            public bool? wantsToJoin { get; set; }
            public string password { get; set; }

        public static List<Learner> cToDTO(List<learners_tbl> data)
            {
                var res = from b in data
                          select new Learner
                          {
                              learnerId = b.learnerId,
                              learnerName = b.learnerName,
                              learnerEmail = b.learnerEmail,
                              gender = b.gender,
                              occuptionId = b.occuptionId,
                              startDate =  b.startDate,
                              endDate = b.endDate,
                              groupId = b.groupId,
                              wantsToJoin = b.wantsToJoin,
                              password=b.password
                          };

                return res.ToList();
            }
        public static learners_tbl DTOToc(Learner data)
        {
            
                    var res = new learners_tbl
                      {
                          learnerId = data.learnerId,
                          learnerName = data.learnerName,
                          learnerEmail = data.learnerEmail,
                          gender = data.gender,
                          occuptionId = data.occuptionId,
                          startDate = (data.startDate),
                          endDate = data.endDate,
                          groupId = data.groupId,
                          wantsToJoin = data.wantsToJoin,
                          password = data.password
                      };

            return res;
        }

        public static List<learners_tbl> DTOToc(List<Learner> data)
            {
                var res = from b in data
                          select new learners_tbl
                          {
                              learnerId = b.learnerId,
                              learnerName = b.learnerName,
                              learnerEmail = b.learnerEmail,
                              gender = b.gender,
                              occuptionId = b.occuptionId,
                              startDate = b.startDate,
                              endDate = b.endDate,
                              groupId = b.groupId,
                              wantsToJoin = b.wantsToJoin,
                              password = b.password
                          };

                return res.ToList();
            }
        }
}
