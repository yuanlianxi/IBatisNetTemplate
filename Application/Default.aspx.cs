﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IBatisBLL;
using IBatisEntity;
using Monitor_WindowsService;

namespace Application
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Monitor m = new Monitor();
            m.Execute();
            
           
        }
    }
}
