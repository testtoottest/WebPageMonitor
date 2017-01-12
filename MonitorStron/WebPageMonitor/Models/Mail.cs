using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPageMonitor.Models
{
    public class Mail
    {
        public string MailAddress { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}