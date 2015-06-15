using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Monitor_WindowsService.AppCode;
using ApplicationCommon;

namespace Monitor_WindowsService.Tasks
{
    class HttpLinkTask:TaskBase
    {
        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        public HttpLinkTask(string url)
        {
            this.url = url;
        }
        public override void Execute()
        {
            tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;


            task = Task.Factory.StartNew(() =>
            {
                HttpLinkTaskHelper taskHelper = new HttpLinkTaskHelper();
                taskHelper.GetString(url, OverTimeMilliSeconds);
                while (!token.IsCancellationRequested)
                {
                    if (taskHelper.IsRuning)
                    {
                        Thread.Sleep(OverTimeMilliSeconds / 5);
                    }
                    else
                    {
                        ReturnValue = Converter.ConvertToInt(taskHelper.Result);
                        this.EndDateTime = taskHelper.EndDateTime;
                        break;
                    }
                }
                taskHelper.Cancel();
            }, token);
        }

    }
}
