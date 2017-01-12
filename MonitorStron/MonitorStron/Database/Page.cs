using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorStron.Database
{
    class Page
    {
        public int PageId { get; set; }
        public string Url { get; set; }

        public virtual ICollection<PersistedContent> PersistedContents { get; set; }
    }
}
