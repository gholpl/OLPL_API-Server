using OLPL_API_Server.Models.SendEMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Mail;

namespace OLPL_API_Server.Controllers
{
    public class SendEMailController : ApiController
    {
        public string Get(string id)
        {
            return "1";
        }
        public string Post(DataModelSendEMail email)
        {
            try
            {
                MailAddress from = new MailAddress(email.from, email.fromname);
                MailAddress to = new MailAddress(email.to, "None");

                //dd1.port = 5252;
                //dd1.server = "exs1.olpl.org";
                MailMessage mail = new MailMessage(from, to);
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "mail.olpl.org";
                mail.Subject = email.subject;
                mail.Body = email.body;
                client.Send(mail);
                return "OK";
            }
            catch(Exception e)
            {
                return "Not Sent " + e.Message;
            }
            
        }
    }
}
