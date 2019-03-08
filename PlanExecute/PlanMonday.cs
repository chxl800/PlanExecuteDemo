using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanExecute
{

    //每周一执行
    public class PlanMonday : IExecutor
    {
        private static bool canExecuteNext = true;
        private static int LastExecuteTime = DateTime.Now.AddDays(-7).GetMonday().YearMonthDayToInt();

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public bool Condition
        {
            get
            {
                return canExecuteNext && (LastExecuteTime < DateTime.Now.GetMonday().YearMonthDayToInt());
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
            LastExecuteTime = DateTime.Now.GetMonday().YearMonthDayToInt();
        }

        public event Action<string, string, int, int> ReportProgress;

        public event Action<Exception> ReportException;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

       

    }
}