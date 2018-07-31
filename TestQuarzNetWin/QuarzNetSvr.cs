using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using TestQuarzNet.Service;
using TestQuarzNet.Service.Log;
using TestQuarzNet.Service.Time;

namespace TestQuarzNetWin
{
    public partial class QuarzNetSvr : ServiceBase
    {
        public static ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public QuarzNetSvr()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            Logger.Info("OnStart()");
            try
            {
                //开启调度器
                ScheduleBase.Scheduler.Start();
                //把作业，触发器加入调度器
                ScheduleBase.AddSchedule(new TimeService()); 
                ScheduleBase.AddSchedule(new LogService());
            }
            catch (Exception ex)
            {
                Logger.Error("TestQuarzNetWin异常", ex);
            }
        }
        protected override void OnStop()
        {
            Logger.Info("OnOnStop()");
            ScheduleBase.Scheduler.Shutdown(true);
        }
    }
}
