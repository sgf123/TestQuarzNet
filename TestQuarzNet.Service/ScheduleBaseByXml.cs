using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace TestQuarzNet.Service
{
    public class ScheduleBaseByXml
    {
        private static IScheduler _scheduler;
        public static IScheduler Scheduler
        {
            get
            {
                if (_scheduler != null)
                {
                    return _scheduler;
                }
                _scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;
                return _scheduler;
            }
        }
        public static void AddSchedule<T>(JobService<T> service) where T : IJob
        {
            service.AddJobToSchedule(Scheduler);
        }
    }
}
