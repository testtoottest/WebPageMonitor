using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPageMonitor.Models
{
    public class Opinion
    {
        public int OpinionId { get; set; }
        public int ChangeId { get; set; }
        public int PageUserMappingId { get; set; }

        public virtual PageUserMapping PageUserMapping { get; set; }
        public virtual Change Change { get; set; }
    }
}