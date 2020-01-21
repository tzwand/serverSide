using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;

namespace BLL
{

    public static class data
    {
        public static BTProjectEntities db = new BTProjectEntities();

        //----------GET---------------------------
        public static List<Book> getAllBooks()
        {
            List<Book> res = (Book.cToDTO(db.Book_tbl.ToList()));
            return res.Where(b => b.BookId != 1).ToList();
        }
        public static List<Book> getAllBooksWithAncester()
        {
            return logic.GetBooksWithAncestor();
        }
        //should return string or book?
        public static List<Book> GetCategories()
        {
            //all categories hold an ancester id of 1 in the way we built the table
            List<Book> categories = data.getAllBooksWithAncester().FindAll(b => b.ParentId == 1004);
            return categories;
        }

        public static List<Request> getAllRequests()
        {
            return (Request.cToDTO(db.request_tbl.ToList()));
        }
        public static List<Learner> getAllLearners()
        {
            return (Learner.cToDTO(db.learners_tbl.ToList()));
        }
        public static List<Matching> getAllMatchings()
        {
            return (Matching.cToDTO(db.Matching_tbl.AsNoTracking().ToList()));
        }
        public static List<Time> getAllTimes()
        {
            return (Time.cToDTO(db.time_tbl.ToList()));
        }
        public static List<Occupation> GetOccupations()
        {
            return (Occupation.cToDTO(db.occuption_tbl.ToList()));
        }
        ///<summary>:return the current learnings per user</summary>
        public static List<CurrentLearnings> GetCurrentLearnings(int learnerid)
        {
            List<Matching_tbl> l = new List<Matching_tbl>();
            l = db.Matching_tbl.AsNoTracking().ToList();
            List<CurrentLearnings> res = new List<CurrentLearnings>();
            l = l.Where(x => x.learnerId == learnerid).ToList();
            res = CurrentLearnings.cToDTO(l);
            //res = CurrentLearnings.cToDTO(l.Whereb(x => x.learnerId == learnerid).ToList());
            return res;
        }
        //find the learning by category and learneb, to show differently in calender
        //category Id is /bn/  a new paremeter in DTO which holds the ancestor id for a learning 
        //which is actually the category id
        public static List<CurrentLearnings> GetCurrentLearningByCategory(int learnerid, int bookId)
        {
            //create a list of all current learning
            List<CurrentLearnings> res = new List<CurrentLearnings>();
            List<CurrentLearnings> res2 = new List<CurrentLearnings>();

            res = GetCurrentLearnings(learnerid);
            //search to find the book with the same book id that was sent 
            //--which is a category and his anscestor id points to himself and all its which 
            //children have it as anscester id 
            List<Book> b = logic.GetBooksWithAncestor();
            b = b.FindAll(mybook => mybook.AncestorId == bookId);
            //find all the matching books in n/ the CurrentLearnings list
            //search throw all the keys found in nbn /n/ the book list and add all of the books from CurrentLearnings List
            foreach (Book l in b)
            {
                res2.AddRange(res.FindAll(currentB => currentB.bookId == l.BookId).ToList());
            }
            return res2;
        }

         public static string getColorForCatergory(string category)
        { 
            var myResourceSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);
            var myString = myResourceSet.GetString(category);
            return myString;
        }
 
         public static Learner GetLearnerByEmailAndPassword(string email, string password)
        {
            return getAllLearners().FirstOrDefault(l => l.learnerEmail.Equals(email) && l.password.Equals(password));

         }
        public static Request GetRequestByEmailAndPassword(string email, string password)
        {
             return getAllRequests().FirstOrDefault(l => l.donorEmail.Equals(email) && l.password.Equals(password));

        }
        public static List<Offer> getCurrentRequests()
        {
        //מחזיר את ההצעות שעדיין ניתן להרשם אליהם. 
            return (Offer.cToDTO(db.request_tbl.ToList()).Where(o => (o.registerEndDate) > DateTime.Today)).ToList();
        }
         public static Matching getMatchByDonorLearnerAndBook(string donorId, int learnerId, int bookId)
        {
          List<Matching> matchs = new List<Matching>();
            matchs = getAllMatchings();
            //filter by book id and learner id
            matchs = matchs.Where(m => m.learnerId == learnerId && m.bookId == bookId).ToList();
            //retreive the req id's
            //get only the id's for better peformance 
            List<int> ids = matchs.Select(match => match.reqId).ToList();

            //create the original list of all requests
            List<Request> allReqs = Request.cToDTO(data.db.request_tbl.ToList());
            //get all reqs with the right id's---that belong to a certain learner and donor and book
            List<Request> myresult = allReqs.Where(x => ids.Contains(x.reqId) && x.donorEmail == donorId).ToList();
            //there should be onlt one such matching
            matchs = matchs.Where(ma => ma.reqId == myresult[0].reqId).ToList();
            return matchs[0];

        }



        //-----------DELETE---------------------------
        public static void deleteLearner(int id)
        {
            db.learners_tbl.Remove(db.learners_tbl.Find(id));
            db.SaveChanges();
        }
        public static void deleteMatch(Matching m)
        {
            //db.Matching_tbl.Remove(Matching.DTOToc(m));
            //this is becuse we nee dto mark the object in the context as deleted
            // ef will afterwards compare the context and find the changes and update as we have marked
            //we only need to use this way if we generate the object on our own
            //otherwise we can simply use remove() if retrieved from dbcontext
            bool oldValidateOnSaveEnabled = db.Configuration.ValidateOnSaveEnabled;

            try
            {
                db.Configuration.ValidateOnSaveEnabled = false;

                db.Entry(Matching.DTOToc(m)).State = EntityState.Deleted;
                //db.Matching_tbl.Attach(Matching.DTOToc(m));

                db.SaveChanges();
            }
            finally
            {
                db.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
            }
            //db.Entry(Matching.DTOToc(m)).State = EntityState.Deleted;
            //db.SaveChanges();
        }
        //-----------Edit----------------------------
        public static void editLearner(Learner l)
        {
            List<learners_tbl> learners = db.learners_tbl.Where(r => r.learnerId == l.learnerId).ToList();
            learners.ForEach(le =>
            {
                le.password = l.password;
                le.learnerName = l.learnerName;

                le.occuptionId = l.occuptionId;
                le.startDate = l.startDate;
                le.endDate = l.endDate;
                le.gender = l.gender;
                db.Entry(le).State = System.Data.Entity.EntityState.Modified;
            });

            db.SaveChanges();

        }
        public static void editDonor(Request d)
        {
            //can change donor email
            List<request_tbl> reqs = db.request_tbl.Where(r => r.donorEmail == d.donorEmail).ToList();
            //reqs.ForEach( req => req.donorEmail = d.donorEmail);
            reqs.ForEach(req =>
            {
                req.password = d.password;
                req.donorName = d.donorName;
                db.Entry(req).State = System.Data.Entity.EntityState.Modified;
            });
            db.SaveChanges();

        }
        //-----------Add-----------------------------
        public static void addLearning(Matching newMatch)
        {
            db.Matching_tbl.Add(DTO.Matching.DTOToc(newMatch));
            //db.SaveChanges();
        }
        public static void addLearner(string name, string email)
        {
            //יצירת מופע של מחלקת מייל ,עם הנתונים הספציפיים שהתקבלו בפונקציה
            Email e = new Email(name, email);
            //קבלת סיסמא רנדומלית,סיסמא זו תשלח ללומד החדש דרך המייל
            int pass = logic.getRandomPassword();
            e.sendEmailViaWebApi(pass.ToString());
            //שמירת הלומד החדש במסד
            //עם הסיסמא הרנדומלית איתה יצטרך להכנס בפעם הבאה ,ואז יוכל גם להחליפה
            db.learners_tbl.Add(DTO.Learner.DTOToc(new Learner() { learnerName = name, learnerEmail = email, password = pass.ToString() }));
            db.SaveChanges();
        }
        public static void addLearner(Learner l)
        {
            db.learners_tbl.Add(Learner.DTOToc(l));
            db.SaveChanges();
        }
        public static List<Offer> getCurrentRequests(Learner learner)
        {
            //if the learner is a vulunteer 

            if (learner.groupId != null)
            {
                //he can only watch his req
                //find the req id
                var group = ClosedGroup.cToDTO(db.closedGroup_tbl.Where(cg => cg.GroupId == learner.groupId).ToList());
                var groupReqId = group[0].reqId;
                return (Offer.cToDTO(db.request_tbl
                .Where(r => r.reqId == groupReqId
                && r.RegisterEndDate > DateTime.Today) //ההרשמה עדייין פתוחה
                .ToList()));
            }
            //מחזיר את ההצעות שעדיין ניתן להרשם אליהם. 
            return (Offer.cToDTO(db.request_tbl
                .Where(r => //בדיקה שכל הפרמטרים של הבקשה מתאימים לתנאי הלומד
                 r.genderid == learner.gender //המין מתאים
              && r.occuptionId == learner.occuptionId //העיסוק מתאים
              && r.RegisterEndDate > DateTime.Today //ההרשמה עדייין פתוחה
              && r.reqEndDate < learner.endDate  //זמן הלימוד המבוקש אינו מתארך מעבר למה שהלומד מעונין
              && r.reqStartDate > learner.startDate//זמן הלימוד המבוקש אינו מתחיל לפני התאריך שממנו והלאה הלומד מעונין ללמוד
              ).ToList()));


        }
        public static void addDonor(string name, string email)
        {
            //יצירת מופע של מחלקת מייל ,עם הנתונים הספציפיים שהתקבלו בפונקציה
            Email e = new Email(name, email);
            //קבלת סיסמא רנדומלית,סיסמא זו תשלח לתורם החדש דרך המייל
            int pass = logic.getRandomPassword();
            e.sendEmailViaWebApi(pass.ToString());
            //שמירת התורם החדש במסד
            db.request_tbl.Add(DTO.Request.DTOToc(new Request() { donorEmail = email, donorName = name, password = pass.ToString(), BookId = 1 }));
            db.SaveChanges();
        }
        public static void addRequest(Request r)
        {


            {
                r.BookId = db.Book_tbl.FirstOrDefault(b => b.BookName == r.BookName).BookId;
                r.timeId = db.time_tbl.FirstOrDefault(t => t.timeDesc == r.timeDesc).timeId;

                db.request_tbl.Add(DTO.Request.DTOToc(r));
                db.SaveChanges();
            }
        }
    }
}
