using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using int422Final;


namespace int422Final
{
    public partial class temp1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int422Final.Private.Classes.ExamManager.addNewVehicle(t1.Text, t2.Text, t3.Text, t4.Text);
        }
    }
}