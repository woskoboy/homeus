using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lances.Pages {
    public partial class MetalHoses : BasePage {
        const string mark = "hose";
        public string Hose_num { get; set; }
        public List<Hose> hoses_list = new List<Hose>();

        protected void Page_Load(object sender,EventArgs e){
            Hose_num = Hose_no_input.Value;
            if (!string.IsNullOrEmpty(Hose_num)) {
                Hose hose = GetDataFromCache<Hose>(mark + Hose_num);
                if (hose != null) {
                    hoses_list.Add(hose);
                    TableBinding(Repeater1,hoses_list);
                }
            }
        }
        //private void TableBinding(Hose hose){
        //    Repeater1.DataSource = new List<Hose> { hose };
        //    Repeater1.DataBind();
        //}
        protected void Page_Init(object sender,EventArgs e){
            RequestButton.Click += delegate {
                EditLink.Visible = true;
                EditLink.NavigateUrl = GetRouteUrl("hose",new { hose = Hose_num });
            };
        }
    }
}