using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorStron.Database
{
    class PersistedContent
    {
        public int PersistedContentId { get; set; }
        public int PageId { get; set; }
        public string Content { get; set; }
        public DateTime AccessDate { get; set; }

        public virtual Page WebPage { get; set; }
    }
}
