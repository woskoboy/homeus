using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1 {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender,EventArgs e)
        {
            // A simple example using Page_Load


            if (!IsPostBack) {
                Repeater1.DataSource = GetP();
                Repeater1.DataBind();
            }
        }

        public List<Person> GetP()
        {
            return new List<Person> { new Person() { Name = "Test",Age = 10,LastName = "Test" } };
        }
    }
}