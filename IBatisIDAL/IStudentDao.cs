using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;

namespace IBatisIDAL
{
    public interface IStudentDao
    {
        Student Select(string stuNum);
        string Insert(Student student);
    }
}
