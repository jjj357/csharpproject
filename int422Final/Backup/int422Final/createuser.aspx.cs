using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Data;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;
using System.Security.Principal;

namespace int422Final
{
    public partial class createuser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            // This fires after the user was successfully created

            // Add the new user to the "Member" role

            Roles.AddUserToRole(CreateUserWizard1.UserName, "Member");

            // Redirect to welcome page

            Response.Redirect("~/default.aspx");
        }
    }
}