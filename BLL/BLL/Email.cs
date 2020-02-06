using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using System.Net.Mail;

namespace BLL
{
    public class Email
    { 
        //build with default name and email.
        private string name;
        private string email;
        public Email(string name, string email)
        {
            this.name = name;
            this.email = email;
        }

        //empty c-tor
        public Email()
        {
            
        }

        //specific. left it because it it used 3 times, so there is some reason for the function .
        public void sendEmailViaWebApi(string pass)
        {
            StreamReader reader = new StreamReader("C:\\Users\\tzipp\\BTProject\\cheshvanProject\\BLL\\BLL\\mail.rtf");
            string subject = "קבלת סיסמא מאוצר הלימוד";
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
        //template for sending string as body
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

        //template for sending body path
        public void sendEmailViaWebApi(string name,string emailTo, string subject, string bodyPath, string senderName,string dynamicBeginString="",string dynamicEndString="")
        {
            StreamReader reader = new StreamReader(bodyPath);
            string body = reader.ReadToEnd();
            string fromMail = "otzarlimud@gmail.com";
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(fromMail);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = "שלום "+ dynamicBeginString + name + "/br"+ body + senderName + dynamicEndString;
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("otzarlimud@gmail.com", "169231464");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }




    }
}
    


