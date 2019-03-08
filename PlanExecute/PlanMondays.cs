using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanExecute
{

    //每周一，异常可以执行多次 执行
    public class PlanMondays : IExecutor
    {
  
        private static bool canExecuteNext = true;
        private static int StarTime = -8;
        private static int LastExecuteTime = DateTime.Now.AddDays(-7).GetMonday().YearMonthDayToInt();
        //private static int LastExecuteTime = DateTime.Now.AddDays(-1).YearMonthDayToInt();
        public string Name
        {
            get { return "周一执行"; }
        }

        public bool Condition
        {
            get
            {
                if (canExecuteNext)
                {
                    return LastExecuteTime < DateTime.Now.AddHours(StarTime).GetMonday().YearMonthDayToInt();
                    //return LastExecuteTime < DateTime.Now.AddHours(StarTime).Date.YearMonthDayToInt();
                }

                return false;
            }
        }

        public void Execute()
        {
            //设置是否执行的标志
            canExecuteNext = false;
            //LastExecuteTime = DateTime.Now.YearMonthDayToInt();
            LastExecuteTime = DateTime.Now.GetMonday().YearMonthDayToInt();
            try
            {
                for (int i = 0; i < 7; i++)
                {
                    //DateTime now = DateTime.Now.AddDays(-1); //用于前一天的
                    //当前日期
                    //DateTime now = DateTime.Now.AddDays(-7).GetMonday().AddDays(i);
                   

                    //执行代码
                    
                }
                StarTime = -8;
            }
            catch (Exception ex)
            {
                StarTime = StarTime - 1;
                //LastExecuteTime = DateTime.Now.AddDays(-1).YearMonthDayToInt();
                LastExecuteTime = DateTime.Now.AddDays(-7).GetMonday().YearMonthDayToInt();
                if (StarTime < -12)
                {
                    StarTime = -8;
                    //LastExecuteTime = DateTime.Now.YearMonthDayToInt();
                    LastExecuteTime = DateTime.Now.GetMonday().YearMonthDayToInt();
                }

            }

            //设置是否执行的标志
            canExecuteNext = true;
        }

        public event Action<string, string, int, int> ReportProgress;

        public event Action<Exception> ReportException;

        public void Dispose()
        {
        }
      
    }
}