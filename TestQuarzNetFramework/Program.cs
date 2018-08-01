using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using log4net.Repository.Hierarchy;
using TestQuarzNet.Service;
using Topshelf;
using static System.Console;

namespace TestQuarzNetFramework
{
    class Program
    {
        public static ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        //测试Task
        static void Main2(string[] args)
        {
            try
            {
                WriteLine("Main.ThreadId:" + Thread.CurrentThread.ManagedThreadId);
                Task.Run(() =>
                {
                    WriteLine("Main.ThreadId2:" + Thread.CurrentThread.ManagedThreadId);
                    throw new Exception("任务并行编码中产生的未知异常");
                }).Wait();
                new Thread(h =>
                {
                    WriteLine("Main.ThreadId3:" + Thread.CurrentThread.ManagedThreadId);
                }).Start();
            }
            catch (Exception e)
            {
                WriteLine("Exception InnerException.Message:{0}", e.InnerException?.Message);
                WriteLine("Exception外部" + e.Message);
            }
            ReadKey();
        }
        //测试Topshelf
        static void Main3(string[] args)
        {
            var rc = HostFactory.Run(x =>
            {
                x.Service<QuarzNetSvr>(s =>
                {
                    s.ConstructUsing(name => new QuarzNetSvr());
                    s.WhenStarted(tc => tc.OnStart());
                    s.WhenStopped(tc => tc.OnStop());
                });
                x.RunAsLocalSystem();
                x.SetDescription("测试TopShelf安装部署系统服务");
                x.SetDisplayName("TopShelf");
                x.SetServiceName("TopShelf"); 
            });
            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;

        }
        //测试使用配置文件方式
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>
            {
                x.Service<QuarzNetSvr>(s =>
                {
                    s.ConstructUsing(name => new QuarzNetSvr());
                    s.WhenStarted(tc => tc.OnStart());
                    s.WhenStopped(tc => tc.OnStop());
                });
                x.RunAsLocalSystem();
                x.SetDescription("测试TopShelf安装部署系统服务");
                x.SetDisplayName("TopShelf");
                x.SetServiceName("TopShelf");
            });
            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}
