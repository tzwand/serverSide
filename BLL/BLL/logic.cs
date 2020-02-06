using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public static class logic
    {

        ///// <summary>return a random password with 6 digits,that not exist in our database.</summary>
        public static int getRandomPassword()
        {
            //יוצר מופעים לטבלאות הרלוונטיות כדי שנוכל לשמור בהם רשומה שנמצאה (וכך נדע שהיא קימת)ונמשיך להגריל סיסמא נוספת
            learners_tbl learner = new learners_tbl();
            request_tbl req = new request_tbl();
            Random r = new Random();
            int pass = 0;
            //בפעם הראשונה א"א לשאול אם המופע הוא נאל כיון שהוא מאותחל
            //ןלכך נועדו שני התנאים הראשונים. 
            //שני התנאים האחרונים נועדו למקרה הרצוי שבו הסיסמא לא נמצאה והמופעים הופכים להיות נאל
            while (learner != null && req != null && learner.learnerId == 0 && req.reqId == 0)
            {
                //מגריל סיסמא ראשונית, הלולאה בודקת האם היא קימת, ואם כן מגרילה שוב
                pass = r.Next(100000, 999999);
                //בודק אם הסיסמא קימת בטבלת לומדים
                learner = data.db.learners_tbl.
                     FirstOrDefault(l => l.password.Equals(pass.ToString()));
                //בודק אם הסיסמא קימת בטבלת בקשות
                req = data.db.request_tbl.
                     FirstOrDefault(l => l.password.Equals(pass.ToString()));
            }
            return pass;
        }

        /// <summary>
        /// return the forgotten password according the params  
        /// </summary>
        /// <param name="type">if you looking for learner enter false,for donor enter true</param>
        /// <param name="email">enter the email of the user</param>
        /// <param name="year">enter the year of the start date</param>
        /// <param name="month">enter the month of the start date</param>
        /// <returns>the forgotten password </returns>
        public static string resetPassword(string type,string email,string year,string month)
        {
            //restores the password
            string password="";
            if (type == "learner")
            {
                   password = data.db.learners_tbl.
                 FirstOrDefault(l => l.learnerEmail.Equals(email)
                 && l.startDate.Value.Year.Equals(year)
                 && l.startDate.Value.Month.Equals(month)).password;
            }
            else if(type=="donor")
            {
                password = data.db.request_tbl.
                     FirstOrDefault(r => r.donorEmail.Equals(email)
                     && r.reqStartDate.Value.Year.Equals(year)
                     && r.reqStartDate.Value.Month.Equals(month)).password;
            }
            //if(password==null)
            //{ return "we didn't find user with this parameters"; }
            SendNewPassword(email, password, type);
            //do we need to return?
            return password;

        }
        /// <summary>
        /// return the forgotten password according the params  
        /// </summary>
        /// <param name="type">if you looking for learner enter false,for donor enter true</param>
        /// <param name="email">enter the email of the user</param>
        
        /// <returns>the forgotten password </returns>
        public static string resetPasswordByEmail(string type, string email)
        {
            //restores the password
            string password = "";
            if (type == "learner")
            {
                password = data.db.learners_tbl.
              FirstOrDefault(l => l.learnerEmail.Equals(email)).password;
              
            }
            else if (type == "donor")
            {
                password = data.db.request_tbl.
                     FirstOrDefault(r => r.donorEmail.Equals(email)
                     ).password;
            }
            //if(password==null)
            //{ return "we didn't find user with this parameters"; }
            SendNewPassword(email, password, type);
            //do we need to return?
            return password;

        }
        public static void SendNewPassword(string email,string password,string type)
        {
            //create a new email instance
            Email e = new Email();


            ////change the password in db according to the recovered one found
            ////find the right object and modify it
            ////used syntex to modify only the password prop
            //if(type=="learner")

            //{

            //    var l = data.db.learners_tbl.ToList();
            //    var learner = l.FirstOrDefault(le => le.learnerEmail == email);
            //    learner.learnerEmail = email;
            //    data.db.learners_tbl.Attach(learner);
            //    data.db.Entry(learner).Property(x => x.learnerEmail).IsModified = true; 
            //}
            //if(type=="donor")
            //{
            //    var r =data.db.request_tbl.ToList();
            //    var re = r.FirstOrDefault(le => le.donorEmail == email);
            //    data.db.request_tbl.Attach(re);
            //    data.db.Entry(re).Property(x => x.donorEmail).IsModified = true;
            //}

            //data.db.SaveChanges();
            //Email the new password
            e.sendEmailViaWebApi("", email, "איפוס סיסמא", "C:\\Users\\tzipp\\BTProject\\cheshvanProject\\BLL\\BLL\\ResetPassword.rtf", "");



        }
        private static List<Book> books { get; set; }
        static logic()
        {
            books = Book.cToDTO(data.db.Book_tbl.ToList());
        }
        public static List<Book> GetBooksWithAncestor()
        {
            foreach (var book in books)
            {
                //if the book doesn't have parent:
                //his AncestorId is 1,
                //and put his id in AncestorId of all his children.
                if (book.ParentId == 1004)
                {
                    getAncestorId(book, book.BookId);
                }

            }
            return books;
        }
        static void getAncestorId(Book book, int idToUpdate)
        {
            //if the book have AncestorId
            if (book.AncestorId != 0)
                return;
            book.AncestorId = idToUpdate;

            //כל הילדים הראשונים שלו
            var children = books.Where(b => b.ParentId == book.BookId && b.AncestorId == 0);
            foreach (var child in children)
            {
                getAncestorId(child, idToUpdate);
                child.AncestorId = idToUpdate;

            }
            return;
        }



    }
}
