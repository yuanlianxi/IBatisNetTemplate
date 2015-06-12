use Practise
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TaskExecutionCheckLog') and o.name = 'FK_TASKEXEC_REFERENCECHECK_TASKINFO')
alter table TaskExecutionCheckLog
   drop constraint FK_TASKEXEC_REFERENCECHECK_TASKINFO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TaskExecutionResultLog') and o.name = 'FK_TASKEXECRESULT_REFERENCE_TASKINFO')
alter table TaskExecutionResultLog
   drop constraint FK_TASKEXECRESULT_REFERENCE_TASKINFO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TaskValueLimits') and o.name = 'FK_TASKVALU_REFERENCE_TASKINFO')
alter table TaskValueLimits
   drop constraint FK_TASKVALU_REFERENCE_TASKINFO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TaskWarningLog') and o.name = 'FK_TASKWARN_REFERENCE_TASKINFO')
alter table TaskWarningLog
   drop constraint FK_TASKWARN_REFERENCE_TASKINFO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TaskAcquisitionLog')
            and   type = 'U')
   drop table TaskAcquisitionLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TaskExecutionCheckLog')
            and   type = 'U')
   drop table TaskExecutionCheckLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TaskExecutionResultLog')
            and   type = 'U')
   drop table TaskExecutionResultLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TaskInfo')
            and   type = 'U')
   drop table TaskInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TaskValueLimits')
            and   type = 'U')
   drop table TaskValueLimits
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TaskWarningLog')
            and   type = 'U')
   drop table TaskWarningLog
go

/*==============================================================*/
/* Table: TaskAcquisitionLog                                    */
/*==============================================================*/
create table TaskAcquisitionLog (
   Id                   int                  not null,
   TaskTotalCount       int                  null,
   TaskValidCount       int                  null,
   AcquisitionDateTime  datetime             null,
   IsActive             bit                  null,
   CreateDateTime       datetime             null,
   constraint PK_TASKACQUISITIONLOG primary key (Id)
)
go

/*==============================================================*/
/* Table: TaskExecutionCheckLog                                 */
/*==============================================================*/
create table TaskExecutionCheckLog (
   Id                   int                  identity(1,1),
   TaskId               int                  null,
   TaskState            int                  null,
   CreateDateTime       datetime             null,
   IsActive             bit                  null,
   constraint PK_TASKEXECUTIONCHECKLOG primary key (Id)
)
go

/*==============================================================*/
/* Table: TaskExecutionResultLog                                */
/*==============================================================*/
create table TaskExecutionResultLog (
   Id                   int                  identity(1,1),
   TaskId               int                  null,
   TaskExecuteStartTime datetime             null,
   TaskExecuteEndTime   datetime             null,
   TaskDuringMilliSeconds int                  null,
   TaskMaxDuringMilliSeconds int                  null,
   TaskReturnValueLimitMax int                  null,
   TaskReturnValue      int                  null,
   TaskReturnValueLimitMin int                  null,
   IsWarn               bit                  null,
   IsExcept             bit                  null,
   ExceptionInfo        nvarchar(Max)        null,
   ExceptionType        nvarchar(1024)       null,
   CreateDateTime       datetime             null,
   IsActive             bit                  null,
   constraint PK_TASKEXECUTIONRESULTLOG primary key (Id)
)
go

/*==============================================================*/
/* Table: TaskInfo                                              */
/*==============================================================*/
create table TaskInfo (
   Id                   int                  not null,
   Method               int                  null,
   Content              nvarchar(max)        null,
   Extend               nvarchar(max)        null,
   OverTimeSeconds      int                  null,
   CreateDateTime       datetime             null,
   LastUpdateDateTime   datetime             null,
   IsActive             bit                  null,
   constraint PK_TASKINFO primary key (Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TaskInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TaskInfo', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '任务ID',
   'user', @CurrentUser, 'table', 'TaskInfo', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TaskInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Method')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TaskInfo', 'column', 'Method'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '任务类型',
   'user', @CurrentUser, 'table', 'TaskInfo', 'column', 'Method'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TaskInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Content')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TaskInfo', 'column', 'Content'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '任务内容',
   'user', @CurrentUser, 'table', 'TaskInfo', 'column', 'Content'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TaskInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Extend')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TaskInfo', 'column', 'Extend'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '扩展属性',
   'user', @CurrentUser, 'table', 'TaskInfo', 'column', 'Extend'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TaskInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OverTimeSeconds')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TaskInfo', 'column', 'OverTimeSeconds'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '超时时间',
   'user', @CurrentUser, 'table', 'TaskInfo', 'column', 'OverTimeSeconds'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TaskInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateDateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TaskInfo', 'column', 'CreateDateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', @CurrentUser, 'table', 'TaskInfo', 'column', 'CreateDateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TaskInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LastUpdateDateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TaskInfo', 'column', 'LastUpdateDateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '上次更新时间',
   'user', @CurrentUser, 'table', 'TaskInfo', 'column', 'LastUpdateDateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TaskInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsActive')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TaskInfo', 'column', 'IsActive'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否删除',
   'user', @CurrentUser, 'table', 'TaskInfo', 'column', 'IsActive'
go

/*==============================================================*/
/* Table: TaskValueLimits                                       */
/*==============================================================*/
create table TaskValueLimits (
   Id                   int                  identity(1,1),
   TaskId               int                  null,
   LimitType            int                  null,
   ValueType            int                  null,
   LimitValues          varchar(4096)        null,
   CreateDateTime       datetime             null,
   LastUpdateDateTime   datetime             null,
   IsActive             bit                  null,
   constraint PK_TASKVALUELIMITS primary key (Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TaskValueLimits')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TaskValueLimits', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '阈值Id',
   'user', @CurrentUser, 'table', 'TaskValueLimits', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TaskValueLimits')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TaskId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TaskValueLimits', 'column', 'TaskId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '任务Id',
   'user', @CurrentUser, 'table', 'TaskValueLimits', 'column', 'TaskId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TaskValueLimits')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LimitType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TaskValueLimits', 'column', 'LimitType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '阈值限制类型',
   'user', @CurrentUser, 'table', 'TaskValueLimits', 'column', 'LimitType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TaskValueLimits')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ValueType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TaskValueLimits', 'column', 'ValueType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '阈值类型',
   'user', @CurrentUser, 'table', 'TaskValueLimits', 'column', 'ValueType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TaskValueLimits')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LimitValues')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TaskValueLimits', 'column', 'LimitValues'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '阈值',
   'user', @CurrentUser, 'table', 'TaskValueLimits', 'column', 'LimitValues'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TaskValueLimits')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateDateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TaskValueLimits', 'column', 'CreateDateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'TaskValueLimits', 'column', 'CreateDateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TaskValueLimits')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LastUpdateDateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TaskValueLimits', 'column', 'LastUpdateDateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '上次更新时间',
   'user', @CurrentUser, 'table', 'TaskValueLimits', 'column', 'LastUpdateDateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TaskValueLimits')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsActive')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TaskValueLimits', 'column', 'IsActive'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否删除',
   'user', @CurrentUser, 'table', 'TaskValueLimits', 'column', 'IsActive'
go

/*==============================================================*/
/* Table: TaskWarningLog                                        */
/*==============================================================*/
create table TaskWarningLog (
   Id                   int                  not null,
   TaskId               int                  null,
   WarnInfo             nvarchar(max)        null,
   CreateDateTime       datetime             null,
   IsActive             bit                  null,
   constraint PK_TASKWARNINGLOG primary key (Id)
)
go

alter table TaskExecutionCheckLog
   add constraint FK_TASKEXEC_REFERENCECHECK_TASKINFO foreign key (TaskId)
      references TaskInfo (Id)
go

alter table TaskExecutionResultLog
   add constraint FK_TASKEXECRESULT_REFERENCE_TASKINFO foreign key (TaskId)
      references TaskInfo (Id)
go

alter table TaskValueLimits
   add constraint FK_TASKVALU_REFERENCE_TASKINFO foreign key (TaskId)
      references TaskInfo (Id)
go

alter table TaskWarningLog
   add constraint FK_TASKWARN_REFERENCE_TASKINFO foreign key (TaskId)
      references TaskInfo (Id)
go
