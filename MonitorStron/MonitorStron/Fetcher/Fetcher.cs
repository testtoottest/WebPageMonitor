using HtmlAgilityPack;
using MonitorStron.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MonitorStron.Fetcher
{
    class Fetcher
    {
        private ContentRepository _ContentRepo { get; set; }

        public Fetcher()
        {
            _ContentRepo = new ContentRepository();
        }

        private HtmlDocument DownloadHtmlFromUrl(string url)
        {
            var _client = new WebClient();

            var htmlWeb = new HtmlWeb() { AutoDetectEncoding = false, OverrideEncoding = Encoding.GetEncoding("utf-8") };
            var pageContent = htmlWeb.Load(url);
            _ContentRepo.AddNewPersistedContext(url, pageContent.DocumentNode.OuterHtml);
            return pageContent;
        }

        private HtmlDocument GetPrevoiusVersion(string url)
        {
            var previousVersion = new HtmlDocument();
            var lastPresistedContent = _ContentRepo.GetLastPersistedContentForUrl(url)?.Content;
            if (!String.IsNullOrEmpty(lastPresistedContent))
            {
                previousVersion.LoadHtml(lastPresistedContent); 
            }
            return previousVersion;
        }

        public WebPageContentPair FetchWebPageContentForComparison(string url)
        {
            return new WebPageContentPair
            {
                StoredVersion = GetPrevoiusVersion(url),
                DownloadedVersion = DownloadHtmlFromUrl(url)
            };
        }

    }
}
