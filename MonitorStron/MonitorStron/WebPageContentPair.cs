using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MonitorStron
{
    class WebPageContentPair
    {
        public HtmlDocument StoredVersion { get; set; }
        public HtmlDocument DownloadedVersion { get; set; }
    }
}
