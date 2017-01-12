using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPageMonitor.Fetch
{
    public static class HtmlParsingExtensions
    {
        public static HtmlDocument AsHtmlDocument(this string html)
        {
            var HtmlDoc = new HtmlDocument();
            HtmlDoc.LoadHtml(html);
            return HtmlDoc;
        }
    }
}