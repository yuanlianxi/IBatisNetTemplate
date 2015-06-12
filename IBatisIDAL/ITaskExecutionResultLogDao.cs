using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;

namespace IBatisIDAL
{
    public interface ITaskExecutionResultLogDao
    {
        int Insert(TaskExecutionResultLog log);
    }
}
