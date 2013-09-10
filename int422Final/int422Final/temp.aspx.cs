using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace int422Final
{
    public partial class temp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            MembershipCreateStatus status;

            

            Membership.CreateUser

                ("Tipson", "password#", "ian.tipson@gmail.com",

                "favorite color", "blue", true, out status);

            Roles.AddUserToRole

                ("Tipson", "Administrator");

            Response.Write("Done");

        

        

        
        }
    }
}