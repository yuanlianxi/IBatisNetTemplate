using System;
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
        public object Result
        {
            get { return result; }
            set { result = value; }
        }
       
        public SqlTaskHelper(string dataConn) { this.dataConn = dataConn; }
        
        public  bool IsRuning
        {
            get { return isRuning; }
            set { isRuning = value; }
        }
        public void ExecuteScalar(string sql, int timeout,  params SqlParameter[] paras)
        {
            using (SqlConnection conn= new SqlConnection(dataConn))
            {
                command = new SqlCommand(sql, conn);
                command.Parameters.AddRange(paras);
                
                conn.Open();
                //AsyncCallback(IAsyncResult ar)
                command.BeginExecuteReader((IAsyncResult o) =>
                {
                    SqlDataReader reader= command.EndExecuteReader(o);
                    reader.Read();
                    result = reader[0];
                    IsRuning = false;
                },null);
                
                command.CommandTimeout = timeout;
            }
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
