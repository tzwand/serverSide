using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class SingleLearner
    {
        /// <summary>
        /// פונקציה לשליפת כל הספרים--- הבקשות של תורם מסוים
        /// </summary>
        /// <param name="donorEmail"></param>
        /// <returns></returns>
        public static List<Request> getReqsByDonor(string donorEmail)
        {
            using (BTProjectEntities db = new BTProjectEntities())
            {
                return Request.cToDTO(db.request_tbl.Where(r => r.donorEmail.Equals(donorEmail)).ToList());
            }
        }
        public static List<Book> getBooksByDonor(string donorEmail)
        {
            using (BTProjectEntities db = new BTProjectEntities())
            {
                List<Request> reqsResult = Request.cToDTO(db.request_tbl.Where(r => r.donorEmail.Equals(donorEmail)).ToList());
                return getBooksByReqs(reqsResult);
            }
        }
        public static List<Book> getBooksByReqs(List<Request> reqs)
        {
            using (BTProjectEntities db = new BTProjectEntities())
            {
                //get only the id's for better peformance 
                List<int> ids = reqs.Select(book => book.BookId).ToList();
                //create the original list of all books
                List<Book> allBooks = Book.cToDTO(db.Book_tbl.ToList());
                //get all books associated with the reqs --- contained in the id list we generated
                List<Book> booksResult = allBooks.Where(x => ids.Contains(x.BookId)).ToList();
                return booksResult;
            }
        }
        //לא הולך לי..........
        ///// <summary> 
        /////,פונקציה לשליפת כל הבקשות של תורם מסוים
        ///// </summary>
        ///// <param name="donorEmail"></param>
        ///// <returns></returns>
        //public static List<Request> getRequestsByDonor(string donorEmail)
        //{
        //    var r= Request.cToDTO(data.db.request_tbl.Where(r => r.donorEmail.Equals(donorEmail)).ToList());
        //    var res;
        //    foreach
        //}

        /// <summary>
        ///פונקציה למציאת כל הספרים שלומד מסוים לומד אותם עבור תורם מסוים
        /// </summary>
        /// 
        //why does the function get reqId and not donor Id---maybe that is the donor's Id 
        //but it does't make sense because we are trying to find the reqID
        public static List<Request> SingleLearnerForSingleDonorReqs(int learnerId, string donorId)
        {
            using (BTProjectEntities db = new BTProjectEntities())
            {
                //first create a list of matchings thst are associated with the given learner
                List<Matching> matchRes = new List<Matching>();
                matchRes = Matching.cToDTO(db.Matching_tbl.AsNoTracking().Where(m =>
                   m.learnerId == learnerId).ToList());
                //get only the id's for better peformance 
                List<int> ids = matchRes.Select(match => match.reqId).ToList();

                //create the original list of all requests
                List<Request> allReqs = Request.cToDTO(db.request_tbl.ToList());
                //get all reqs with the right id's---that belong to a certain learner and donor
                List<Request> myresult = allReqs.Where(x => ids.Contains(x.reqId) && x.donorEmail == donorId).ToList();

                return myresult;
            }
        }
        //expanding the previous function
        public static List<Book> SingleLearnerForSingleDonorBooks(int learnerId, string donorId)
        {
            //function call -- returns matching requests for the donor and learner
            List<Request> reqsResult = SingleLearnerForSingleDonorReqs(learnerId,donorId);

            return getBooksByReqs(reqsResult);
        }



        ///<summary>פונקציה לשליפת כל הלומדים של ספר מסוים לתורם מסוים=כל הלומדים מבקשה מסוימת.</summary>
        ///<param>the id of the relevant request</param>
        ///<returns>list of the learners that are connected to this request</returns>
        public static List<Learner> GetLearnesForBookByReq(int requestId)
        {
            using (BTProjectEntities db = new BTProjectEntities())
            {
                List<Learner> allLearners = Learner.cToDTO(db.learners_tbl.ToList());

                List<int> correntIDs = SingleLearner.GetMatchingsPerRequest(requestId);
                List<Learner> res = new List<Learner>();
                foreach (Learner l in allLearners)
                {
                    if (correntIDs.Contains(l.learnerId))
                    {
                        res.Add(l);
                    }
                }
                return res;
            }
        }
        public static List<Learner> GetLearnesForBookByDonor(int bookId, string donorId)
        {
            using (BTProjectEntities db = new BTProjectEntities())
            {
                //get reqs for donor
                List<Request> allRequests = Request.cToDTO(db.request_tbl.ToList());
                allRequests = allRequests.Where(req => req.donorEmail == donorId).ToList();

                //generate an id list of the the reqs
                List<int> ids = allRequests.Select(req => req.reqId).ToList();

                //create the original list of all matchings
                List<Matching> allMatchings = Matching.cToDTO(db.Matching_tbl.AsNoTracking().ToList());

                //get all matchings associated with the reqs --- contained in the id list we generated
                allMatchings = allMatchings.Where(x => ids.Contains(x.reqId)).ToList();

                //generate an id list of the the matchings
                List<int> matchIds = allMatchings.Select(m => m.learnerId).ToList();

                //create the original list of all learners
                List<Learner> allLearners = Learner.cToDTO(db.learners_tbl.ToList());

                //get all learners associated with the donor --- contained in the id list we generated
                allLearners = allLearners.Where(x => matchIds.Contains(x.learnerId)).ToList();

                return allLearners;
            }
        }
        //public static List<T> getListByRelationship(int id)
        //{

        //}

        ///<summary>פונקציה לשליפת כל הלומדים  לתורם מסויםsummary>
        ///<param>the id of the relevant donor</param>
        ///<returns>list of the learners that are connected to this donor</returns>
        public static List<Learner> GetLearnersByDonor(string donorId)
        {
            using (BTProjectEntities db = new BTProjectEntities())
            {
                // calles the function above, but for all the donor's reqeusts.

                List<Request> allRequests = Request.cToDTO(db.request_tbl.ToList());
                allRequests = allRequests.Where(r => r.donorEmail == donorId).ToList();

                List<Learner> res = new List<Learner>();
                foreach (Request ra in allRequests)
                {
                    res.AddRange(SingleLearner.GetLearnesForBookByReq(ra.reqId));
                }
                return res;
            }
        }

        /// <summary>
        /// collect the id's of all the learners that joined to this request.
        /// </summary>
        /// <param name="requestId"></param>

        private static List<int> GetMatchingsPerRequest(int requestId)
        {
            using (BTProjectEntities db = new BTProjectEntities())
            {
                var l = Matching.cToDTO(db.Matching_tbl.AsNoTracking().Where(m => m.reqId == requestId).ToList());
                var learnerIdList = new List<int>();
                foreach (Matching learner in l)
                {
                    learnerIdList.Add(learner.learnerId);
                }
                return learnerIdList;
            }
        }
        //הפונקציות הבאות מחשבות כמה לומדים יש כבר לספר מסוים מתוך כמה שצריך.

        /// <summary>
        /// ניתן לשלוח את הקוד עצמו
        /// הפונקציה מקבלת קוד ספר בודד ומחזירה את מספר השיבוצים שלו
        /// </summary>
        public static int getCountMatchingsForRequest(int book)
        {
            using (BTProjectEntities db = new BTProjectEntities())
            {
                return db.Matching_tbl.AsNoTracking().Count(x => x.bookId == book);
            }
        }
        /// <summary>
        /// ניתן לשלוח את האוביקט כולו
        /// הפונקציה מקבלת ספר בודד ומחזירה את מספר השיבוצים שלו
        /// </summary>
        public static int getCountMatchingsForRequest(Book book)
        {
            using (BTProjectEntities db = new BTProjectEntities())
            {
                int id = db.Book_tbl.FirstOrDefault(b => b.BookId == book.BookId).BookId;
                return db.Matching_tbl.AsNoTracking().Count(x => x.bookId == id);
            }
        }
        ///// <summary>
        /////הפונ' מחזירה את כמות הלומדים הרצויה שמוגדרת בטבלת הבקשה 
        ///// </summary>
        //public static int getCountActiveLearningForBook(Request req)
        //{

        //    return data.db.request_tbl.FirstOrDefault(x => x.reqId == req.reqId).?
        //}
        //פונקציה שתציג את כל הלומדים של ספר מסוים. (מחפשת בכל הבקשות.
        //אך מחזירה גם אם זה אותו בקשה או לא כדי שיהיה אפשר להציג זאת.
        //—יש ענין ב2 פונקציות אחרות?)
        public static int getActiveLearningForBook()
        {
            return 0;
        }

    }
}

