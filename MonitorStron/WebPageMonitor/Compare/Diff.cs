using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPageMonitor.Models;

namespace Comparator
{
     class Diff
    {
        public Diff() { }

        public PageUserMapping pageUserMapping { get; set; }
        public List<ChangeContent> changes = new List<ChangeContent>();

        public Diff(PageUserMapping pageUserMapping)
        {
            this.pageUserMapping = pageUserMapping;
        }

        public override string ToString()
        {
            var sb = new StringBuilder("pageid: " + pageUserMapping.PageId + ", userid: " + pageUserMapping.UserId + "\n");
            foreach(var c in changes)
                sb.Append("\t").Append(c.ToString()).Append("\n");
            return sb.ToString();
        }
    }
}
