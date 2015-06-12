using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;

namespace IBatisIBLL
{
    public interface IStudentService
    {
        Student Select(string stuNum);
        string Insert(Student student);
    }
}
