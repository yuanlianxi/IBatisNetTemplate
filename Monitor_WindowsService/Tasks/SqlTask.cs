﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCommon;
using System.Threading;
using Monitor_WindowsService.AppCode;

namespace Monitor_WindowsService.Tasks
{
    class SqlTask:TaskBase
    {
        private string sql;
        private string dataConn;

        public string Sql
        {
            get { return sql; }
            set { sql = value; }
        }
        
        public string DataConn
        {
            get { return dataConn; }
            set { dataConn = value; }
        }
        
        public SqlTask(string sql, string dataConn)
        {
            this.sql = sql;
            this.dataConn = dataConn;
        }
        public override void Execute()
        {
            tokenSource = new CancellationTokenSource();

            CancellationToken token = tokenSource.Token;

            
            task = Task.Factory.StartNew(() =>
            {
                SqlTaskHelper sqlHelper = new SqlTaskHelper(dataConn);
                sqlHelper.ExecuteScalar(sql, OverTimeMilliSeconds, null);
                while (!token.IsCancellationRequested)
                {
                    object s = task.Status;
                    if (sqlHelper.IsRuning)
                    {
                        Thread.Sleep(OverTimeMilliSeconds / 20);    
                    }
                    else
                    {
                        this.ReturnValue = Converter.ConvertToInt(sqlHelper.Result);
                        this.EndDateTime = sqlHelper.EndDateTime;
                        break;
                    }
                }
                sqlHelper.Cancel();
            }, token);
        }

        


    }
}
