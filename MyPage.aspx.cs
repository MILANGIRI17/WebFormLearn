using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LearnWebForm
{
    public partial class MyPage : System.Web.UI.Page
    {
        private List<MyEvent> events;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Session["MyEvents"] = new List<MyEvent>();
        }

        protected void btnEvent_Click(object sender, EventArgs e)
        {
            UpdateEvents();
            BindEvents();
        }

        private void UpdateEvents()
        {
            if (Session["MyEvents"] != null)
                events = (List<MyEvent>)Session["MyEvents"];
            else
                events = new List<MyEvent>();

            events.Add(new MyEvent(txtEvent.Text, calenderEvents.SelectedDate));
            Session["MyEvents"] = events;
        }

        private void BindEvents()
        {
            rptEvents.DataSource = events;
            rptEvents.DataBind();
        }
    }


    public class MyEvent
    {
        public string EventName { get; private set; }
        public string EventDate { get; private set; }

        public MyEvent(string eventName, DateTime eventDate)
        {
            EventName = eventName;
            EventDate = eventDate.ToShortDateString();
        }
    }
}