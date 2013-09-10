using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace int422Final.Private.Exam
{
    public partial class q2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var context = new int422Final.Private.Models.exam_Entities();

           
            var theCustomer = context.v_Customer.Where(i => i.l_name == ddl1.SelectedValue).First();

            int422Final.Private.Classes.ExamManager.CreateDynamicTable(Panel1, theCustomer.customer_id.Trim()); 
        }
    }
}