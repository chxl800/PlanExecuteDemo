using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanExecute
{
    //每月一执行
    public class WeekReportDeptMonth : IExecutor
    {

        private static bool canExecuteNext = true;
        private static int LastExecuteTime = DateTime.Now.AddMonths(-1).YearMonthDayToInt();

        public string Name
        {
            get { return "部门月考勤汇总报表"; }
        }

        public bool Condition
        {
            get
            {
                if (canExecuteNext)
                {
                    return LastExecuteTime < new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).YearMonthDayToInt();
                }

                return false;
            }
        }

        public void Execute()
        {
            canExecuteNext = false;
            try
            {
                //执行代码
            }
            catch (Exception ex) { }
            canExecuteNext = true;
            LastExecuteTime = DateTime.Now.YearMonthDayToInt();
        }

        public event Action<string, string, int, int> ReportProgress;

        public event Action<Exception> ReportException;

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        
    }
}