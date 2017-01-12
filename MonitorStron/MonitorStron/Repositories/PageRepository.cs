using MonitorStron.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorStron.repositories
{
    class PageRepository
    {
        public void AddNewWebPageWithExistanceCheck(string url)
        {
            using (var ctx = new MonitorContext())
            {
                if (!ctx.Pages.Where(x => x.Url == url).Any())
                {
                    ctx.Pages.Add(new Page
                    {
                        Url = url
                    });
                    ctx.SaveChanges(); 
                }
            }
        }
    }
}
