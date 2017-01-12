using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPageMonitor.Models;

namespace Comparator
{
    class UsersInterestedInChangeGetter
    {
        public UsersInterestedInChangeGetter(Page page)
        {
            this.page = page;
        }

        public Page page { get; set; }
        public List<PageUserMapping> GetUsersInterestedInChange(HtmlNode n)
        {
            // TODO: move to DBO function GetUsersTrackingPage
            return new List<PageUserMapping> { new PageUserMapping(), new PageUserMapping() };
        }
    }
}
