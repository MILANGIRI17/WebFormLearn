using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LearnWebForm
{
    public partial class ValidationExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            valSummaryForm.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) //Without this check, if the user disables javascript there is no guarantee the page is valid. 
                ltMessage.Text = "Page is valid.";
            else
                valSummaryForm.Visible = true;
        }
    }
}