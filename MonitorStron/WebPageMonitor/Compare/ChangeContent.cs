using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPageMonitor.Models;

namespace Comparator
{
    class ChangeContent
    {
        public ChangeContent(Opinion o, string before, string after)
        {
            ChangeCode = o.OpinionId;
            this.before = before;
            this.after = after;
        }

        public int ChangeCode { get; set; }
        public string before { get; set; }
        public string after { get; set; }

        public override string ToString()
        {
            return "code: " + ChangeCode + " before: " + before + " after: " + after;
        }
    }
}
