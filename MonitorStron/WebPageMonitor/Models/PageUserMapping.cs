using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPageMonitor.Models
{
    public class PageUserMapping
    {
        public int PageUserMappingId { get; set; }
        public int UserId { get; set; }
        public int PageId { get; set; }
        public int TimeIntervalInSeconds { get; set; }

        public virtual Page Page { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<Opinion> Opinions { get; set; }
    }
}