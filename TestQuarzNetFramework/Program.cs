using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace TestQuarzNetFramework
{
    class Program
    {
        static void Main(string[] args)
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
    }
}
