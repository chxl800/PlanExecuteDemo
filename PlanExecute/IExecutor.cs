using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanExecute
{
    /// <summary>
    /// 执行器的接口
    /// </summary>
    public interface IExecutor : IDisposable
    {
        /// <summary>任务的名称</summary>
        string Name { get; }
        /// <summary>执行的条件</summary>
        bool Condition { get; }
        /// <summary>执行任务</summary>
        void Execute();

        /// <summary>报告进度,参数顺度为：执行器的名称，执行的步骤名称，执行到第几个步骤，共多少个步骤</summary>
        event Action<string, string, int, int> ReportProgress;

        /// <summary>异常输出</summary>
        event Action<Exception> ReportException;
    }     
}