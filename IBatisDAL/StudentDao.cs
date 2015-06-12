using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisIDAL;

namespace IBatisDAL
{
    public class StudentDao:DaoBase,IStudentDao
    {

        public IBatisEntity.Student Select(string stuNum)
        {
            return ExecuteQueryForObject<IBatisEntity.Student>("Student-Select", stuNum);
        }

        public string Insert(IBatisEntity.Student student)
        {
            object result = ExecuteInsert("Student-Insert", student);
            if (result != null)
            {
                return result.ToString();
            }
            return "";
        }
    }
}
