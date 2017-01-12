using FluentScheduler;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Hosting;

namespace WebPageMonitor.Fetch
{
    public class FetchingTask : IJob, IRegisteredObject
    {
        private string _url { get; set; }
        private int _pageUserMappingId { get; set; }
        private bool _shuttingDown { get; set; }

        private readonly object _lock = new object();

        public FetchingTask(string url, int pageUserMappingId)
        {
            _url = url;
            _pageUserMappingId = pageUserMappingId;
            HostingEnvironment.RegisterObject(this);
        }

        public void Execute()
        {
            lock (_lock)
            {
                if (_shuttingDown)
                {
                    return;
                }

                var comparator = new Comparator();
                var webPageContent = DownloadHtmlFromUrl(_url);
                comparator.Compare(_pageUserMappingId, webPageContent);
            }
        }

        public void Stop(bool immediate)
        {
            lock (_lock)
            {
                _shuttingDown = true;
            }

            HostingEnvironment.UnregisterObject(this);

        }

        private HtmlDocument DownloadHtmlFromUrl(string url)
        {
            var _client = new WebClient();

            var htmlWeb = new HtmlWeb() { AutoDetectEncoding = false, OverrideEncoding = Encoding.GetEncoding("utf-8") };
            var pageContent = htmlWeb.Load(url);
            return pageContent;
        }


    }
}