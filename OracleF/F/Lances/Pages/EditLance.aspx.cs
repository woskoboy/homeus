using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using conf = System.Configuration.ConfigurationManager;

namespace Lances.Pages {
    public partial class EditLance : BasePage {

        const string mark = "lance", keys_collection = "lance_keys", LEFT = "левая",
            RIGHT = "правая", DATE_INSTALL = "DateInstall", DATE_DEINSTALL = "DateDeinstall";
        private Dictionary<string,string> dict;
        public string Lance_num { get; set; }

        protected void Page_Load(object sender,EventArgs e){
            Lance_num = string.IsNullOrEmpty(Lance_no.Value) ? GetNumberFromRequest(mark) : Lance_no.Value;
            Lance_no.Value = Lance_num;
        }

        protected void Page_PreRender(object sender,EventArgs e){
            Lance lance = GetDataFromCache<Lance>(mark + Lance_num);
            if (lance != null) {
                dict = GetDictFromObject(lance);
                FillControls(dict,EditTableDiv.Controls);

                Page.ClientScript.RegisterHiddenField(DATE_INSTALL + "_hidden",lance.DateInstall);
                Page.ClientScript.RegisterHiddenField(DATE_DEINSTALL + "_hidden",lance.DateDeinstall);
            }
        }
        protected void Page_Init(object sender,EventArgs e){

            BR br = new WorkerDB().GetHandBK();
            DL_Reasons.DataSource = br.Reason; DL_Reasons.DataBind();
            DL_Jobs.DataSource = br.Jobs; DL_Jobs.DataBind();

            SaveEditButton.Click += delegate {
                Lance lance = GetObjectFromControls<Lance>(EditTableDiv.Controls);

                lance.DateInstall = Request.Form[DATE_INSTALL];
                lance.DateDeinstall = Request.Form[DATE_DEINSTALL];

                Page.ClientScript.RegisterHiddenField(DATE_INSTALL + "_hidden",lance.DateInstall);
                Page.ClientScript.RegisterHiddenField(DATE_DEINSTALL + "_hidden",lance.DateDeinstall);

                string key = mark + Lance_num;
                DataInsertCache(key,lance);
                AddKey(key,keys_collection);

                new WorkerDB().DataInsertDB(lance);
                Response.Redirect("~/lances/" + Lance_num);
            };
        }
        [WebMethod]
        public static string[] Ajax(string Param1, string Param2){
            int cv_no; Int32.TryParse(Param1,out cv_no);
            string LR = Param2 == LEFT ? "L" : "R";
            
            WorkerDB db = new WorkerDB();
            Respon resp = db.CheckWorkPosition(cv_no,LR);
            if (resp.Heat_no == 0)
                resp.Heat_no = db.GetCurrentHeat(cv_no);

            string[] msg = { resp.Heat_no.ToString(), resp.Info ?? "фурма не в работе"};
            return msg;
        }
    }
}