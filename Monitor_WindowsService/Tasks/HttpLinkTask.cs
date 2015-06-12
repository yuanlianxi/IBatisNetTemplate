﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Monitor_WindowsService.AppCode;

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
        public HttpLinkTask(string url,int timeout)
        {
            this.url = url;
            this.OverTimeMilliSeconds = timeout;
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
                        ReturnValue = taskHelper.Result;
                        break;
                    }
                }
                taskHelper.Cancel();
            }, token);
        }

    }
}