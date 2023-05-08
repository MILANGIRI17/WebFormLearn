using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectFees;

namespace LearnWebForm
{
    public partial class ProjectCalculation : System.Web.UI.Page
    {
        public decimal BasePrice = 100.00m;
        protected void Page_Load(object sender, EventArgs e)
        {
            ltBasePrice.Text = BasePrice.ToString("C");
        }

        protected void ddlStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            States states= new States();
            decimal fee=states.GetFeeForState(ddlStates.SelectedValue);
            decimal finalPrice = BasePrice + fee;
            ltCustomPrice.Text=finalPrice.ToString("C");
        }
    }
}