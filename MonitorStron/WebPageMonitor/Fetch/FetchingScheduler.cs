using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPageMonitor.Repositories;

namespace WebPageMonitor.Fetch
{
    public class FetchingScheduler : Registry
    {
        public FetchingScheduler()
        {
            var repo = new FetchingTaskRepository();
            foreach (var page in repo.GetPagesWithTimeIntervals())
            {
                Schedule(new FetchingTask(page.Url,page.UserMappingId)).ToRunEvery(page.TimeIntervalInSeconds).Seconds();
            }
        }

        public void ScheduleFethingTask(string url, int userMappingId, TimeSpan repeatDelay)
        {
            JobManager.AddJob(new FetchingTask(url, userMappingId), s => s.ToRunEvery(repeatDelay.Seconds).Seconds());
        }
    }
}