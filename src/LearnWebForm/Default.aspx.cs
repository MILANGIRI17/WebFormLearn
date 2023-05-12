using LearnWebForm.Domain;
using LearnWebForm.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LearnWebForm
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HelloWorldLabel.Text = "Hello, World";
        }

        protected void GreetButton_Click(object sender,EventArgs e)
        {
            HelloWorldLabel.Text = $"Hello, {TextInput.Text}";
        }

        protected void btnRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Contact");
        }

        protected void addCustomerClicked()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var customers = new List<Customer>
                    {
                        new Customer{ Id = 1, FirstName="Milan",LastName="Giri" },
                        new Customer{ Id = 2,FirstName="Sandesh",LastName="Kullung"},
                        new Customer{ Id = 3,FirstName="Ganesh",LastName="Aacharya"},
                        new Customer{ Id = 4,FirstName="Kushal",LastName="Ban"}
                    };
                    session.Save(customers);
                    transaction.Commit();
                }
            }
        }

        protected void GreetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            HelloWorldLabel.Text = $"Hello, {GreetList.SelectedValue}";
        }
        //protected void showCustomer_Click()
        //{

        //}
    }
}