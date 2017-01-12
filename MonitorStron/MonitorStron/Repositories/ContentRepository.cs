using MonitorStron.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorStron.Repositories
{
    class ContentRepository
    {
        public void AddNewWebPage(string url)
        {
            using (var ctx = new MonitorContext())
            {
                ctx.Pages.Add(new Page
                {
                    Url = url
                });
                ctx.SaveChanges();
            }
        }

        public void AddNewPersistedContext(string pageUrl, string content)
        {
            using (var ctx = new MonitorContext())
            {
                var pageId = ctx.Pages.Single(x => x.Url == pageUrl).PageId;
                ctx.PersistedContents.Add(new PersistedContent
                {
                    PageId = pageId,
                    Content = content,
                    AccessDate = DateTime.Now
                });
                ctx.SaveChanges();
            }
        }
        public PersistedContent GetLastPersistedContentForUrl(string pageUrl)
        {
            using (var ctx = new MonitorContext())
            {
                var result = ctx.PersistedContents
                            .Where(x => x.WebPage.Url == pageUrl)
                            .OrderByDescending(x => x.AccessDate)
                            .FirstOrDefault();
                return result;
            }
        }
    }
}
