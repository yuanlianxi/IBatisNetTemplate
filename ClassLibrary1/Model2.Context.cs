﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码是根据模板生成的。
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，则所做更改将丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace ClassLibrary1
{
    public partial class StudentManageEntities : ObjectContext
    {
        public const string ConnectionString = "name=StudentManageEntities";
        public const string ContainerName = "StudentManageEntities";
    
        #region Constructors
    
        public StudentManageEntities()
            : base(ConnectionString, ContainerName)
        {
            Initialize();
        }
    
        public StudentManageEntities(string connectionString)
            : base(connectionString, ContainerName)
        {
            Initialize();
        }
    
        public StudentManageEntities(EntityConnection connection)
            : base(connection, ContainerName)
        {
            Initialize();
        }
    
        private void Initialize()
        {
            // 创建代理需要使用 ProxyDataContractResolver 和
            // 可允许延迟加载，这可以在序列化期间展开加载图。
            ContextOptions.ProxyCreationEnabled = false;
            ObjectMaterialized += new ObjectMaterializedEventHandler(HandleObjectMaterialized);
        }
    
        private void HandleObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            var entity = e.Entity as IObjectWithChangeTracker;
            if (entity != null)
            {
                bool changeTrackingEnabled = entity.ChangeTracker.ChangeTrackingEnabled;
                try
                {
                    entity.MarkAsUnchanged();
                }
                finally
                {
                    entity.ChangeTracker.ChangeTrackingEnabled = changeTrackingEnabled;
                }
                this.StoreReferenceKeyValues(entity);
            }
        }
    
        #endregion
    
        #region ObjectSet 属性
    
        public ObjectSet<Course> Course
        {
            get { return _course  ?? (_course = CreateObjectSet<Course>("Course")); }
        }
        private ObjectSet<Course> _course;
    
        public ObjectSet<CourseSelect> CourseSelect
        {
            get { return _courseSelect  ?? (_courseSelect = CreateObjectSet<CourseSelect>("CourseSelect")); }
        }
        private ObjectSet<CourseSelect> _courseSelect;
    
        public ObjectSet<CourseTeach> CourseTeach
        {
            get { return _courseTeach  ?? (_courseTeach = CreateObjectSet<CourseTeach>("CourseTeach")); }
        }
        private ObjectSet<CourseTeach> _courseTeach;
    
        public ObjectSet<Manager> Manager
        {
            get { return _manager  ?? (_manager = CreateObjectSet<Manager>("Manager")); }
        }
        private ObjectSet<Manager> _manager;
    
        public ObjectSet<Student> Student
        {
            get { return _student  ?? (_student = CreateObjectSet<Student>("Student")); }
        }
        private ObjectSet<Student> _student;
    
        public ObjectSet<Teacher> Teacher
        {
            get { return _teacher  ?? (_teacher = CreateObjectSet<Teacher>("Teacher")); }
        }
        private ObjectSet<Teacher> _teacher;

        #endregion
    }
}
