using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;

namespace IBatisIBLL
{
    public interface ITaskExecutionResultLogService
    {
        int Insert(TaskExecutionResultLog log);
    }
}
