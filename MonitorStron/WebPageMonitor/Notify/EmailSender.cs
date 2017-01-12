using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Collections;
using Comparator;

namespace WebPageMonitor.Notify
{
    class EmailSender : Sender
    {
        private int UserId;
        private int PageId;
        private static String Name;
        private List<String> Mail;
        private String Message { get; set; }
        private List<ChangeContent> changes;

        public void send(Diff diff)
        {
            UserId = diff.pageUserMapping.UserId;
            PageId = diff.pageUserMapping.PageId;
            changes = diff.changes;
            
            setData(UserId, PageId, changes);
            foreach (String mail in Mail)
            {
                MailMessage message = new MailMessage();
                message.To.Add(new MailAddress(mail));
                message.From = new System.Net.Mail.MailAddress("testtoottest@gmail.com");
                message.Subject = "test";
                message.Body = Message;

                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("testtoottest@gmail.com", "test1234.");
                client.Host = "smtp.gmail.com";

                message.IsBodyHtml = true;
                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}",
                                ex.ToString());
                }
            }

        }

       

        private String generateMessage(List<ChangeContent> changes)
        {
            String message = "Zmiany: \n";
            foreach (ChangeContent change in changes)
            {
                message += "\tkod zmiany: " + change.ChangeCode + "\n";
                message += "\tByło wcześniej: " + change.before + "\n";
                message += "\tJest teraz: " + change.after + "\n\n";
            }

            return message;

        }
        private void setData(int UserId, int PageId, List<ChangeContent> changes)
        {
            Name = DBConnector.getName(UserId);
            Mail = DBConnector.getEmailAddressessList(UserId);
            Message = generateMessage(changes);

        }
    }
}
