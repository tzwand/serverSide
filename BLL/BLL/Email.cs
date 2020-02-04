using System.IO;
using System.Configuration;
using System.Net.Mail;

namespace BLL
{
    public class Email
    { 
        private string name;
        private string email;
        public Email(string name, string email)
        {
            this.name = name;
            this.email = email;
        }
        public Email()
        {
            
        }

        public void sendEmailViaWebApi(string pass)
        {
            StreamReader reader = new StreamReader("C:\\Users\\tzipp\\BTProject\\cheshvanProject\\BLL\\BLL\\mail.rtf");
            string subject = "קבלת סיסמא מאוצר הלימוד";
            //string s = ConfigurationManager.AppSettings["mail"];

            //FileStream fs = File.OpenRead(s);
            //FileStream fs = new FileStream(s,
            //    FileMode.Open,
            //    FileAccess.Read);
            //StreamReader reader = new StreamReader(fs);

            string body = reader.ReadToEnd()+pass;
            //string FromMail = ConfigurationManager.AppSettings["fromMail"];
            string fromMail = "otzarlimud@gmail.com";
            string emailTo = email;
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            //mail.From = new MailAddress(FromMail);
            mail.From = new MailAddress(fromMail);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential(fromMail, "169231464");
            //SmtpServer.Credentials = new System.Net.NetworkCredential("otzarlimud@gmail.com", "169231464");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }
        public void sendEmailViaWebApi(string emailTo, int pass, string subject, string body)
        {
            string FromMail = ConfigurationManager.AppSettings["fromMail"];
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(FromMail);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["fromMail"], "169231464");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }
        public void sendEmailViaWebApi(string name,string emailTo, string subject, string bodyPath, string senderName)
        {
            StreamReader reader = new StreamReader(bodyPath);
            string body = reader.ReadToEnd();
            string fromMail = "otzarlimud@gmail.com";
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(fromMail);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = "שלום " + name + body+ senderName;
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential( "otzarlimud@gmail.com", "169231464");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }
        public void sendEmailResetPassword(string emailTo, string pass)
        {
            StreamReader reader = new StreamReader("C:\\Users\\tzipp\\BTProject\\cheshvanProject\\BLL\\BLL\\ResetPassword.rtf");
            string subject = "איפוס סיסמא";
            string body = reader.ReadToEnd() + pass;
            string fromMail = "otzarlimud@gmail.com";
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(fromMail);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential(fromMail, "169231464");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }
    }
}
    


