using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBatisEntity
{
    public class TaskExecutionCheckLog
    {
   private int              id                  ;
   private int              taskId              ;
   private int              taskState           ;
   private DateTime         createDateTime      ;
   private bool             isActive;
   public int Id
   {
       get
       {
           return id;
       }
       set
       {
           id = value;
       }
   }
   public int TaskId
   {
       get
       {
           return taskId;
       }
       set
       {
           taskId = value;
       }
   }
   public int TaskState
   {
       get
       {
           return taskState;
       }
       set
       {
           taskState = value;
       }
   }
   public DateTime CreateDateTime
   {
       get
       {
           return createDateTime;
       }
       set
       {
           createDateTime = value;
       }
   }
   public bool IsActive
   {
       get
       {
           return isActive;
       }
       set
       {
           isActive = value;
       }
   }
   
    }
}
