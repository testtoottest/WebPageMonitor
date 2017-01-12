using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPageMonitor.Models
{
    public class Page
    {
        public int PageId { get; set; }
        public string Url { get; set; }
        public string Content { get; set; }

        public virtual ICollection<PageUserMapping> UrlUserMappings { get; set; }
        public virtual ICollection<Change> Changes { get; set; }
    }
}