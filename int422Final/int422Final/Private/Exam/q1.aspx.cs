using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace int422Final.Private.Exam
{
    public partial class q1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Text = string.Empty;
                tbColour.Text = string.Empty;
                tbTrans.Text = string.Empty;
                //ddlCustomer.Text = "Select a Customer";
            }
           /* if (tbTrans.Text != "auto" && tbTrans.Text != "manual") {
                lblError.Text = "Trans data should be auto or manual";
                tbTrans.Text = string.Empty;
                tbTrans.Focus();
            }   */
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int422Final.Private.Classes.ExamManager.addNewVehicle(ddlModel.SelectedValue.Trim(), ddlCustomer.SelectedValue.Trim(), tbColour.Text, tbTrans.Text);
            }
            catch (Exception ex)
            {
                if (ex.Message == "You must enter the transmission type, manual or auto ")
                {
                    lblError.Text = "You must enter the transmission type, manual or auto ";
                    tbTrans.Text = string.Empty;
                    tbTrans.Focus();
                }
                



            }
            lblError.Text = "Object added";
            tbColour.Text = string.Empty;
            tbTrans.Text = string.Empty;
        }
    }
}