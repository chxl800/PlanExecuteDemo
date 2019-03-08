using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace PlanExecute
{
    public class WinService
    {
        private ChiefExecutor chiefExecutor;
        private Thread thread;

        public void Start(string[] args)
        {
            #region 手动的依赖注入代码
            
            chiefExecutor = new ChiefExecutor();

            List<IExecutor> list = new List<IExecutor>();
            #region list添加  
            //执行一天多点 PlanDatayTimes执行具体代码
            list.Add(new PlanDatayTimes());
            #endregion

            chiefExecutor.Executors = list;
            #endregion

            thread = new Thread(new ThreadStart(delegate
            {
                chiefExecutor.Execute();
            }));
            thread.IsBackground = true;
            thread.Start();
        }

        public void Stop()
        {
            if (chiefExecutor != null)
            {
                chiefExecutor.Dispose();
                thread.Abort();
            }
        }
    }
}