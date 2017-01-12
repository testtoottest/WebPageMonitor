using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPageMonitor.Models;

namespace WebPageMonitor.Repositories
{
    public class FetchingTaskRepository
    {
        private MonitorContext _ctx { get; set; }

        public FetchingTaskRepository()
        {
            _ctx = new MonitorContext();
        }

        public List<FetchingTaskDTO> GetPagesWithTimeIntervals()
        {
            var mappings = _ctx.PageUserMappings.Include("Page").ToList();
            return mappings.Select(x => new FetchingTaskDTO
                                        {
                                            Url = x.Page.Url,
                                            TimeIntervalInSeconds = x.TimeIntervalInSeconds,
                                            UserMappingId = x.PageUserMappingId
                                        }).ToList();
                                                    
        }
    }

    public struct FetchingTaskDTO
    {
        public string Url { get; set; }
        public int TimeIntervalInSeconds { get; set; }
        public int UserMappingId { get; set; }
    }
}