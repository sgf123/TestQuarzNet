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
        protected override string GroupName => "每隔30秒记录当前时间处理";
        protected override string JobName => "每隔30秒记录当前时间";
        protected override ITrigger GetTrigger()
        {
            var trigger = TriggerBuilder.Create()
                .WithIdentity("记录时间", "作业触发器")
                .WithCronSchedule("0/30 * * * * ?")
                .Build();
            return trigger;
        }
    }
}
