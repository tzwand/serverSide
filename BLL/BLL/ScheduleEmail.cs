using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class ScheduleEmail
    {

        public void scheduleEndOfRegisterEmail(Request req, string learnerEmail)
        {

            //email donor
            Email e = new Email();
            string bodyPath = "C:\\Users\\tzipp\\BTProject\\cheshvanProject\\BLL\\BLL\\ConfirmLearners.rtf";


            e.sendEmailViaWebApi("",req.donorEmail,"אישור משתתפים בתוכנית הלימוד",bodyPath,"",""," מזהה תוכנית הלימוד:"+req.reqId+"ספר הלימוד "+req.BookName+"מטרת הלימוד "+req.reqPurpose+"תאריך אחרון להרשמה: "+req.registerEndDate);

            //email learner
            string bodyPathLearner = "C:\\Users\\tzipp\\BTProject\\cheshvanProject\\BLL\\BLL\\ConfirmLearningLearner.rtf";
            e.sendEmailViaWebApi("", learnerEmail, "אישור השתתפות בתוכנית הלימוד", bodyPathLearner, "", "", " מזהה תוכנית הלימוד:" + req.reqId +" מייל היזם"+req.donorEmail+ "ספר הלימוד " + req.BookName + "מטרת הלימוד " + req.reqPurpose + "תאריך אחרון להרשמה: " + req.registerEndDate);

        }
    }
}
