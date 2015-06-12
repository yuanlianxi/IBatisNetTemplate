using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBatisBLL
{
    public class ServiceContext
    {
        public static IBatisBLL.TaskAcquisitionLogService TaskAcquisitionLogService { get { return IBatisBLL.TaskAcquisitionLogService.Instance; } }
        public static IBatisBLL.TaskExecutionCheckLogService TaskExecutionCheckLogService { get { return IBatisBLL.TaskExecutionCheckLogService.Instance; } }
        public static IBatisBLL.TaskExecutionResultLogService TaskExecutionResultLogService { get { return IBatisBLL.TaskExecutionResultLogService.Instance; } }
        public static IBatisBLL.TaskInfoService TaskInfoService { get { return IBatisBLL.TaskInfoService.Instance; } }
        public static IBatisBLL.TaskValueLimitsService TaskValueLimitsService { get { return IBatisBLL.TaskValueLimitsService.Instance; } }
        public static IBatisBLL.TaskWarningLogService TaskWarningLogService { get { return IBatisBLL.TaskWarningLogService.Instance; } }
    }
}
