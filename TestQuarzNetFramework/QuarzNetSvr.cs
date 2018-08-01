using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using TestQuarzNet.Service;
using TestQuarzNet.Service.Log;
using TestQuarzNet.Service.Time;

namespace TestQuarzNetFramework
{
    public class QuarzNetSvr
    {
        public static ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public void OnStart()
        {
            Logger.Info("OnStart()");
            try
            {
                //开启调度器
                ScheduleBaseByXml.Scheduler.Start();
                //把作业，触发器加入调度器
                //ScheduleBaseByXml.AddSchedule(new TimeService());
                //ScheduleBaseByXml.AddSchedule(new LogService());
            }
            catch (Exception ex)
            {
                Logger.Error("TestQuarzNetWin异常", ex);
            }
        }
        public void OnStop()
        {
            Logger.Info("OnOnStop()");
            ScheduleBase.Scheduler.Shutdown(true);
        }
    }
}
