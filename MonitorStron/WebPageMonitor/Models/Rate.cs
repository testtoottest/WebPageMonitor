using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPageMonitor.Models
{
    public class Rate
    {
        public int RateId { get; set; }
        public int PageUserMappingId { get; set; }
        public int Points { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public virtual PageUserMapping PageUserMapping { get; set; }
    }
}