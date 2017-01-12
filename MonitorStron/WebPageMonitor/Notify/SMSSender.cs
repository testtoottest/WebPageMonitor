using Comparator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageMonitor.Notify
{
    class SMSSender : Sender
    {
        private int UserId;
        private int PageId;
        private static String Name;
        private String Message { get; set; }
        private List<ChangeContent> changes;
        private List<String> PhoneNumbers;

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
            PhoneNumbers = DBConnector.getPhoneNumberList(UserId);
            Message = generateMessage(changes);

        }

        public void send(Diff diff)
        {
            UserId = diff.pageUserMapping.UserId;
            PageId = diff.pageUserMapping.PageId;
            changes = diff.changes;

            setData(UserId, PageId, changes);

            //TODO implement text message sending 

        }

    }
}
