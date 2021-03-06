//------------------------------------------------------------------------------
// <auto-generated>
//     此代码是根据模板生成的。
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，则所做更改将丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace ClassLibrary1
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(CourseSelect))]
    [KnownType(typeof(Teacher))]
    public partial class CourseTeach: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region 基元属性
    
        [DataMember]
        public string TeaNum
        {
            get { return _teaNum; }
            set
            {
                if (_teaNum != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("属性“TeaNum”是对象键的一部分，不可更改。仅当未跟踪对象或对象处于“已添加”状态时，才能对键属性进行更改。");
                    }
                    if (!IsDeserializing)
                    {
                        if (Teacher != null && Teacher.TeaNum != value)
                        {
                            Teacher = null;
                        }
                    }
                    _teaNum = value;
                    OnPropertyChanged("TeaNum");
                }
            }
        }
        private string _teaNum;
    
        [DataMember]
        public string CrsNum
        {
            get { return _crsNum; }
            set
            {
                if (_crsNum != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("属性“CrsNum”是对象键的一部分，不可更改。仅当未跟踪对象或对象处于“已添加”状态时，才能对键属性进行更改。");
                    }
                    _crsNum = value;
                    OnPropertyChanged("CrsNum");
                }
            }
        }
        private string _crsNum;
    
        [DataMember]
        public System.DateTime SchoolYear
        {
            get { return _schoolYear; }
            set
            {
                if (_schoolYear != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("属性“SchoolYear”是对象键的一部分，不可更改。仅当未跟踪对象或对象处于“已添加”状态时，才能对键属性进行更改。");
                    }
                    _schoolYear = value;
                    OnPropertyChanged("SchoolYear");
                }
            }
        }
        private System.DateTime _schoolYear;
    
        [DataMember]
        public int Semester
        {
            get { return _semester; }
            set
            {
                if (_semester != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("属性“Semester”是对象键的一部分，不可更改。仅当未跟踪对象或对象处于“已添加”状态时，才能对键属性进行更改。");
                    }
                    _semester = value;
                    OnPropertyChanged("Semester");
                }
            }
        }
        private int _semester;
    
        [DataMember]
        public Nullable<int> Classes
        {
            get { return _classes; }
            set
            {
                if (_classes != value)
                {
                    _classes = value;
                    OnPropertyChanged("Classes");
                }
            }
        }
        private Nullable<int> _classes;
    
        [DataMember]
        public Nullable<int> SelectedCount
        {
            get { return _selectedCount; }
            set
            {
                if (_selectedCount != value)
                {
                    _selectedCount = value;
                    OnPropertyChanged("SelectedCount");
                }
            }
        }
        private Nullable<int> _selectedCount;
    
        [DataMember]
        public Nullable<int> SelectedCountMax
        {
            get { return _selectedCountMax; }
            set
            {
                if (_selectedCountMax != value)
                {
                    _selectedCountMax = value;
                    OnPropertyChanged("SelectedCountMax");
                }
            }
        }
        private Nullable<int> _selectedCountMax;
    
        [DataMember]
        public Nullable<bool> Start
        {
            get { return _start; }
            set
            {
                if (_start != value)
                {
                    _start = value;
                    OnPropertyChanged("Start");
                }
            }
        }
        private Nullable<bool> _start;
    
        [DataMember]
        public Nullable<bool> Selecting
        {
            get { return _selecting; }
            set
            {
                if (_selecting != value)
                {
                    _selecting = value;
                    OnPropertyChanged("Selecting");
                }
            }
        }
        private Nullable<bool> _selecting;

        #endregion
        #region 导航属性
    
        [DataMember]
        public TrackableCollection<CourseSelect> CourseSelect
        {
            get
            {
                if (_courseSelect == null)
                {
                    _courseSelect = new TrackableCollection<CourseSelect>();
                    _courseSelect.CollectionChanged += FixupCourseSelect;
                }
                return _courseSelect;
            }
            set
            {
                if (!ReferenceEquals(_courseSelect, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("当启用 ChangeTracking 时，无法设置 FixupChangeTrackingCollection");
                    }
                    if (_courseSelect != null)
                    {
                        _courseSelect.CollectionChanged -= FixupCourseSelect;
                        // 这是执行级联删除的关联中的主体端。
                        // 移除当前集合中所有实体的级联删除事件处理程序。
                        foreach (CourseSelect item in _courseSelect)
                        {
                            ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                        }
                    }
                    _courseSelect = value;
                    if (_courseSelect != null)
                    {
                        _courseSelect.CollectionChanged += FixupCourseSelect;
                        // 这是执行级联删除的关联中的主体端。
                        // 为新集合中已存在的所有实体添加级联删除事件处理程序。
                        foreach (CourseSelect item in _courseSelect)
                        {
                            ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                        }
                    }
                    OnNavigationPropertyChanged("CourseSelect");
                }
            }
        }
        private TrackableCollection<CourseSelect> _courseSelect;
    
        [DataMember]
        public Teacher Teacher
        {
            get { return _teacher; }
            set
            {
                if (!ReferenceEquals(_teacher, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added && value != null)
                    {
                        // 这是识别关系的依赖端，因此主体端在设置后不能更改，
                        // 否则它只能设置为主键值与依赖外键相同的实体。
                        if (TeaNum != value.TeaNum)
                        {
                            throw new InvalidOperationException("仅当依赖端处于“已添加”状态时，才能更改识别关系的主体端。");
                        }
                    }
                    var previousValue = _teacher;
                    _teacher = value;
                    FixupTeacher(previousValue);
                    OnNavigationPropertyChanged("Teacher");
                }
            }
        }
        private Teacher _teacher;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        // 此实体类型是至少一个执行级联删除的关联中的依赖端。
        // 此事件处理程序将处理在删除主体端时发生的通知。
        internal void HandleCascadeDelete(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                this.MarkAsDeleted();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            CourseSelect.Clear();
            Teacher = null;
        }

        #endregion
        #region 关联修复
    
        private void FixupTeacher(Teacher previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CourseTeach.Contains(this))
            {
                previousValue.CourseTeach.Remove(this);
            }
    
            if (Teacher != null)
            {
                if (!Teacher.CourseTeach.Contains(this))
                {
                    Teacher.CourseTeach.Add(this);
                }
    
                TeaNum = Teacher.TeaNum;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Teacher")
                    && (ChangeTracker.OriginalValues["Teacher"] == Teacher))
                {
                    ChangeTracker.OriginalValues.Remove("Teacher");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Teacher", previousValue);
                }
                if (Teacher != null && !Teacher.ChangeTracker.ChangeTrackingEnabled)
                {
                    Teacher.StartTracking();
                }
            }
        }
    
        private void FixupCourseSelect(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (CourseSelect item in e.NewItems)
                {
                    item.CourseTeach = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("CourseSelect", item);
                    }
                    // 这是执行级联删除的关联中的主体端。
                    // 更新事件侦听器以引用新依赖。
                    ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CourseSelect item in e.OldItems)
                {
                    if (ReferenceEquals(item.CourseTeach, this))
                    {
                        item.CourseTeach = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("CourseSelect", item);
                    }
                    // 这是执行级联删除的关联中的主体端。
                    // 从事件侦听器中移除前一个依赖。
                    ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                }
            }
        }

        #endregion
    }
}
