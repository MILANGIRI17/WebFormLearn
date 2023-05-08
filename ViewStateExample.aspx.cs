using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LearnWebForm
{
    public partial class ViewStateExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                ltPostBack.Text = "I'm a post back! This form is \"sticky\" your input has been loaded into the view state for the page!";
            else
                ltPostBack.Text = "Fill out this form. Don't worry, your data won't get lost when you submit. We have View State!.";
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}