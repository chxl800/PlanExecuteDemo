using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanExecute
{
    //每天几个点钟执行
    public class PlanDatayTimes : IExecutor
    {
        private static bool canExecuteNext = true;
        private static int LastExecuteTime = DateTime.Now.AddDays(-1).YearMonthDayToInt();
        private static List<KeyValue<string, bool>> list = new List<KeyValue<string, bool>>() { new KeyValue<string, bool>() { Key = "09:31", Value = false }, new KeyValue<string, bool>() { Key = "15:00", Value = false }, new KeyValue<string, bool>() { Key = "23:31", Value = false } };
        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public bool Condition
        {
            get
            {
                if (canExecuteNext)
                {
                    //每个一天初始化默认值为 true
                    if (LastExecuteTime < DateTime.Now.Date.YearMonthDayToInt())
                    {
                        foreach (KeyValue<string, bool> item in list)
                        {
                            item.Value = true;
                        }
                    }

                    foreach (KeyValue<string, bool> item in list)
                    {
                        DateTime time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + item.Key); //大于上面设置的时间点
                        if (DateTime.Now >= time && item.Value)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }


        }

        public void Execute()
        {
            canExecuteNext = false;
            LastExecuteTime = DateTime.Now.Date.YearMonthDayToInt();
            //执行之后 这个点为false
            foreach (KeyValue<string, bool> item in list)
            {
                DateTime time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + item.Key); //大于上面设置的时间点
                if (DateTime.Now >= time && item.Value)
                {
                    item.Value = false;
                }
            }

           //执行代码

            canExecuteNext = true;
        }

        public event Action<string, string, int, int> ReportProgress;

        public event Action<Exception> ReportException;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

     

    }
}