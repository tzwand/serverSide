using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO

    {
    public class LearningMaterial
        {
            public int learnerId { get; set; }
            public int bookId { get; set; }
            public Nullable<int> amount { get; set; }
            public static List<LearningMaterial> cToDTO(List<learningMaterial_tbl> data)
            {
                var res = from b in data
                          select new LearningMaterial
                          {
                              learnerId = b.learnerId,
                              bookId = b.bookId,
                              amount = b.amount

                          };

                return res.ToList();
            }

            public static List<learningMaterial_tbl> DTOToc(List<LearningMaterial> data)
            {
                var res = from b in data
                          select new learningMaterial_tbl
                          {
                              learnerId = b.learnerId,
                              bookId = b.bookId,
                              amount = b.amount
                          };

                return res.ToList();
            }
        }
}

