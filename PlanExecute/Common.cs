using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PlanExecute
{
    public static class Common
    {
        public static int YearMonthDayToInt(this DateTime date)
        {
            return date.Year * 10000 + date.Month * 100 + date.Day;
        }

        /// <summary>
        /// 获取本周的周一
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetMonday(this DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Monday)
                return date.Date;

            return date.AddDays(1 - (date.DayOfWeek == DayOfWeek.Sunday ? 7 : date.DayOfWeek.GetHashCode())).Date;
        }

        public static DateTime GetSunday(this DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday)
                return date.Date;

            return date.AddDays(7 - date.DayOfWeek.GetHashCode()).Date;
        }


        //写日志
        public static void PrintLog(string Message)
        {
            string Today = DateTime.Now.ToString("yyyy-MM-dd");
            string path = @"E:\Log" + Today + ".txt";
            FileStream fs = new FileStream(path, FileMode.Append);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("");
                sw.WriteLine("-------------------------------------------------------------------------------------" + DateTime.Now.ToString());
                sw.WriteLine(Message);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }

        //手动执行的
        //AttendanceReport.WeekReport target = new AttendanceReport.WeekReport(); // TODO: 初始化为适当的值
        //if (target.Condition)
        //    target.Execute();
    }
}