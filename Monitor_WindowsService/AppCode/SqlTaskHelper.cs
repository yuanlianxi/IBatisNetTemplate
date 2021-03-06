﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Monitor_WindowsService.AppCode
{
    public class SqlTaskHelper
    {
        private string dataConn;
        private volatile bool isRuning = true;
        private volatile object result;
        private SqlCommand command;
        private  DateTime endDateTime;
        public SqlTaskHelper(string dataConn) { this.dataConn = dataConn; }
        
        public  bool IsRuning
        {
            get { return isRuning; }
            set { isRuning = value; }
        }
        public DateTime EndDateTime
        {
            get { return endDateTime; }
            set { endDateTime = value; }
        }
        public object Result
        {
            get { return result; }
            set { result = value; }
        }
        public void ExecuteScalar(string sql, int timeout,  params SqlParameter[] paras)
        {
            SqlConnection conn = new SqlConnection(dataConn);
            
                command = new SqlCommand(sql, conn);
                if (paras != null)
                {
                    command.Parameters.AddRange(paras);
                }
                conn.Open();
                //AsyncCallback(IAsyncResult ar)
                command.CommandTimeout = timeout;
                
                command.BeginExecuteReader((IAsyncResult o) =>
                {                    
                    SqlDataReader reader= command.EndExecuteReader(o);
                    reader.Read();
                    result = reader[0];
                    IsRuning = false;
                    EndDateTime = DateTime.Now;
                    reader.Close();
                },null,System.Data.CommandBehavior.CloseConnection);
                
            
        }
        public void Cancel()
        {
            if (command != null)
            {
                command.Cancel();
                
            }
        }
    }
}
