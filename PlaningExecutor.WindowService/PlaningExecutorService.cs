using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace PlaningExecutor.WindowService
{
    public partial class PlaningExecutorService : ServiceBase
    {
        private static PlanExecute.WinService winService = new PlanExecute.WinService();

        public PlaningExecutorService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            winService.Start(args);
        }

        protected override void OnStop()
        {
            base.OnStop();
            winService.Stop();
        }
    }
}
