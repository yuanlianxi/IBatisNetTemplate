using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisIBLL;
using IBatisIDAL;

namespace IBatisBLL
{
    public class StudentService : BaseService<IStudentDao>, IStudentService
    {
        private static readonly StudentService _instance = new StudentService();
        private StudentService() : base(DALContextEnum.DefaultDAL) { }
        public static StudentService Instance
        {
            get
            {
                return _instance;
            }
        }
        public IBatisEntity.Student Select(string stuNum)
        {
            return Dao.Select(stuNum);
        }

        public string Insert(IBatisEntity.Student student)
        {
            return Dao.Insert(student);
        }
    }
}
