using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Data;
using System.Web.Services;

namespace Lances.Pages {
    public partial class Default : BasePage {
        private List<Lance> lances_list = new List<Lance>();
        const string mark = "lance", keys_collection = "lance_keys";
        public string Lance_num { get; set; }
        protected void Page_Load(object sender,EventArgs e) {
            SetVisibility();
            Lance_num = Lance_no_input.Value;
            if (!string.IsNullOrEmpty(Lance_num)){
                Lance lance = GetDataFromCache<Lance>(mark+Lance_num);
                if (lance != null) TableBinding(Repeater1,new List<Lance> { lance });
                else TableBinding(Repeater1,new List<Lance>());
            }
        }
        private void SetVisibility(){ EditLink.Visible = true;
            excelBut.Visible = true; link.Visible = false;
        }
        protected void Page_Init(object sender, EventArgs e){
            RequestButton.Click += delegate{
                EditLink.NavigateUrl = GetRouteUrl("lance",new { lance = Lance_num });
            };
            excelBut.ServerClick += delegate {
                string path = new ExcelExport().Start<Lance>();
                link.Attributes["href"] = path;
                excelBut.Visible = false; link.Visible = true; 
            };
            all_but.ServerClick += delegate{
                IEnumerable<Lance> collection = GetAllCache<Lance>(keys_collection);
                TableBinding(Repeater1, collection);
            };
        }




    }
}