using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;

namespace IBatisIDAL
{
    public interface ITaskExecutionCheckLogDao
    {
        int Insert(TaskExecutionCheckLog log);
    }
}
