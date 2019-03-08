using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace PlanExecute
{
    /// <summary>
    /// 总的执行器
    /// </summary>
    public class ChiefExecutor : IDisposable
    {
        public IEnumerable<IExecutor> Executors { get; set; }

        /// <summary>
        /// 执行任务
        /// </summary>
        public void Execute()
        {
            while (true)
            {
                if (Executors != null)
                {
                    foreach (IExecutor e in Executors)
                    {
                        if (e.Condition)
                        {
                            try
                            {
                                e.Execute();
                            }
                            catch (Exception ex)
                            {
                                // LogHelper.LogError(ex);
                            }
                        }
                    }
                }

                Thread.Sleep(200);
            }
        }

        /// <summary>
        /// 添加事件
        /// </summary>
        public void AddEvents()
        {
            if (Executors != null)
            {
                foreach (IExecutor e in Executors)
                {
                    e.ReportProgress += new Action<string, string, int, int>(e_ReportProgress);
                }
            }
        }

        /// <summary>
        /// 执行器执行过程中报告进度
        /// </summary>
        /// <param name="name">执行器的名称</param>
        /// <param name="message">消息</param>
        /// <param name="step">执行到第几个步骤</param>
        /// <param name="totalSteps">共多少个步骤</param>
        void e_ReportProgress(string name, string message, int step, int totalSteps)
        {
            // LogHelper.LogInformation(name + " " + message + "[" + step + "/" + totalSteps + "]");
        }

        /// <summary>
        /// 销毁所有执行器
        /// </summary>
        public void Dispose()
        {
            if (Executors != null)
            {
                foreach (IExecutor e in Executors)
                {
                    try
                    {
                        e.Dispose();
                    }
                    catch (Exception ex)
                    {
                        //LogHelper.LogError(ex);
                    }
                }
            }
        }


        //   //写日志
        //public static void PrintLog(string Message)
        //{
        //    string Today = DateTime.Now.ToString("yyyy-MM-dd");
        //    string path = @"E:\Log" + Today + ".txt";
        //    FileStream fs = new FileStream(path, FileMode.Append);
        //    using (StreamWriter sw = new StreamWriter(fs))
        //    {
        //        sw.WriteLine("");
        //        sw.WriteLine("-------------------------------------------------------------------------------------" + DateTime.Now.ToString());
        //        sw.WriteLine(Message);
        //        sw.Flush();
        //        sw.Close();
        //        fs.Close();
        //    }
        //}

    }
}