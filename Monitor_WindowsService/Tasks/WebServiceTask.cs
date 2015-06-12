using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Monitor_WindowsService.AppCode;

namespace Monitor_WindowsService.Tasks
{
    class WebServiceTask:TaskBase
    {
        private string url;
        private string methodName;
        private object[] paras;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        
        public string MethodName
        {
            get { return methodName; }
            set { methodName = value; }
        }
        
        public object[] Paras
        {
            get { return paras; }
            set { paras = value; }
        }
        
        public override void Execute()
        {
            tokenSource = new CancellationTokenSource();

            CancellationToken token = tokenSource.Token;
            task = Task.Factory.StartNew(() =>
            {
                WebServiceTaskHelper taskHelper = new WebServiceTaskHelper();
                taskHelper.Invoke(url, methodName, paras);
                while (!token.IsCancellationRequested)
                {
                    if (taskHelper.IsRuning)
                    {
                        Thread.Sleep(OverTimeMilliSeconds / 5);
                    }
                    else
                    {
                        ReturnValue = taskHelper.Result;
                        break;
                    }
                }
            }, token);
        }

    }
}
