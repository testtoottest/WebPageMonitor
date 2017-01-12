using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPageMonitor.Models
{
    public class Change
    {
        public int ChangeId { get; set; }
        public int PageId { get; set; }

        public virtual Page Page { get; set; }
        public virtual ICollection<ChangeInfo> ChangeInfos { get; set; }
        public virtual ICollection<Opinion> Opinions { get; set; }
    }
}