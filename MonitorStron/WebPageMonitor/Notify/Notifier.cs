using Comparator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageMonitor.Notify
{
    class Notifier
    {
        private List<Sender> notificationMethods = new List<Sender>();

        public Notifier()
        {
            notificationMethods.Add(new EmailSender());
            notificationMethods.Add(new SMSSender());
        }

        public void notify(int UserId, int PageId, Diff diff) {
         
            foreach(Sender sender in notificationMethods)
            {
                sender.send(diff);
            }   
        }

        
    }
}
