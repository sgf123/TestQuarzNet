using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace TestQuarzNet.Service.Time
{
    public class TimeService : JobService<TimeJob>
    {
        private const int IntervalInSeconds = 1 * 60;
        protected override string GroupName => "每隔1分钟记录当前时间处理"; 
        protected override string JobName => "每隔1分钟记录当前时间"; 
        protected override ITrigger GetTrigger()
        {
            var trigger = TriggerBuilder.Create()
                .WithIdentity("每隔1分钟记录当前时间", "作业触发器")
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(IntervalInSeconds)
                    .RepeatForever())
                .Build();
            return trigger;
        }
    }
}
