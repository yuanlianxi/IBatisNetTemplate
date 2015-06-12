using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IBatisBLL;
using IBatisEntity;

namespace Application
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.StuAge = 12;
            student.StuName = "xiaoming";
            student.StuNum = "110404010390";
            student.StuPassword = "123456";
            student.StuPhoto = "564654";
            student.StuGender = "男";
            student.StuSchoolStartDate = DateTime.Now;
            StudentService.Instance.Insert(student);
        }
    }
}
