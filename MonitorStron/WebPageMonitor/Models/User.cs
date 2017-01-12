using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPageMonitor.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PageUserMapping> PageUserMappings { get; set; }
        public virtual ICollection<Mail> Mails { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}