using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using Monitor_WindowsService.Tasks;

namespace Monitor_WindowsService
{
    public partial class Monitor : ServiceBase
    {
        Timer timer;
        public Monitor()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Execute();
        }

        protected override void OnStop()
        {
        }

        public void Execute(){
            
            timer = new Timer(ExecuteRegular, null, (long)0, (long)System.Threading.Timeout.Infinite);
        }

        private void ExecuteRegular(object obj) {
            TaskManager manager = new TaskManager();
            manager.Execute();
            timer.Change(5 * 60000, System.Threading.Timeout.Infinite);
        }
    }
}
