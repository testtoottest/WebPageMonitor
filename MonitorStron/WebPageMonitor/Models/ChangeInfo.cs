using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPageMonitor.Models
{
    public class ChangeInfo
    {
        public int ChangeInfoId { get; set; }
        public int ChangeId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public virtual Change Change { get; set; }
    }
}