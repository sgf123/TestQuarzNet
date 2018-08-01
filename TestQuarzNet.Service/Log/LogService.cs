using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace TestQuarzNet.Service.Log
{
    public class LogService : JobService<LogJob>
    { 
        protected override string GroupName => "每隔20秒拉取日志处理"; 
        protected override string JobName => "每隔20秒拉取日志"; 
        protected override ITrigger GetTrigger()
        {
            var trigger = TriggerBuilder.Create()
                .WithIdentity("拉取日志", "作业触发器") 
                .WithCronSchedule("0/20 * * * * ?")
                .Build();
            return trigger;
        }
    }
}
