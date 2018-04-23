using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class DefaultForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ObjectDataSource1_ObjectCreated(object sender, ObjectDataSourceEventArgs e)
        {
            if (Session["CustomAppointmentDataSource"] == null)
            {
                Session["CustomAppointmentDataSource"] = new CustomAppointmentDataSource();
            }
            e.ObjectInstance = Session["CustomAppointmentDataSource"];
        }
    }
}