using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPageMonitor.Models
{
    public class Phone
    {
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}