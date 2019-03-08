using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanExecute
{
    //每天8点钟执行
    public class PlanToday : IExecutor
    {
        private static bool canExecuteNext = true;
        private static int LastExecuteTime = DateTime.Now.AddDays(-1).YearMonthDayToInt();

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public bool Condition
        {
            get
            {
                return canExecuteNext && (LastExecuteTime < DateTime.Now.AddHours(-8).YearMonthDayToInt());
            }
        }

        public void Execute()
        {
            canExecuteNext = false;
            try
            {
                //DateTime now = DateTime.Now.AddDays(-7);
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