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
                ////开启调度器
                //ScheduleBase.Scheduler.Start();
                ////把作业，触发器加入调度器
                //ScheduleBase.AddSchedule();
                //调度器构造工厂
                ISchedulerFactory factory = new StdSchedulerFactory();

                //第一步：构造调度器
                IScheduler scheduler = factory.GetScheduler().Result;
                scheduler.Start();//启动调度器
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
