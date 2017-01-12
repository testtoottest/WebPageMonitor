using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPageMonitor.Models;

namespace WebPageMonitor.Notify
{
    class DBConnector
    {
        private static MonitorContext monitorContext;
               
        public DBConnector() {
            monitorContext = new MonitorContext();
     
        }
       
        public static String getName(int UserID) {
            var firstName = (from user in monitorContext.Users where user.UserId == UserID select user.Name);
            return firstName.ToString();
        }
     
        public static List<String> getPhoneNumberList(int UserId) {
            List<String> phoneNumbers = new List<String>();
            var phoneNumberList = (from phone in monitorContext.Phones where phone.UserId == UserId select phone.PhoneNumber).ToList();
            foreach(var phoneNumber in phoneNumberList)
            {
                phoneNumbers.Add(phoneNumber);            }

            return phoneNumbers;


        }

        public static List<String> getEmailAddressessList(int UserId) {
            List<string> emailAddresses = new List<String>();
            emailAddresses = (from mail in monitorContext.Mails where mail.UserId == UserId select mail.MailAddress).ToList();
            return emailAddresses;
       } 

    }
}
