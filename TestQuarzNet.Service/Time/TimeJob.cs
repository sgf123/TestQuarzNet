using System;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Quartz;

namespace TestQuarzNet.Service.Time
{
    public class TimeJob :IJob
    {
        public static ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Factory.StartNew(() => Logger.Info(DateTime.Now + Environment.NewLine));
        }
    }
}
