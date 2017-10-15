using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lances.Pages{
    public partial class EditHose : BasePage{
        private string DATE_INSTALL = "DateInstall";
        private string DATE_DEINSTALL = "DateDeinstall";
        private Dictionary<string, string> dict;
        public string Hose_num { get; set; }
        const string mark = "hose";
        protected void Page_Load(object sender, EventArgs e){
            Hose_num = string.IsNullOrEmpty(Hose_no.Value) ? GetNumberFromRequest(mark) : Hose_no.Value;
            Hose_no.Value = Hose_num;
        }
        protected void Page_Init(object sender, EventArgs e){
            SaveEditButton.Click += SaveEditHandler;
        }
        protected void Page_PreRender(object sender, EventArgs e){
            Hose Hose = GetDataFromCache<Hose>(mark+ Hose_num);
            if (Hose != null){
                dict = GetDictFromObject(Hose);
                FillControls(dict, EditTableDiv.Controls);

                Page.ClientScript.RegisterHiddenField(DATE_INSTALL + "_hidden", Hose.DateInstall);
                Page.ClientScript.RegisterHiddenField(DATE_DEINSTALL + "_hidden", Hose.DateDeinstall);
            }

        }
        private void SaveEditHandler(object sender, EventArgs e){
            Hose hose = GetObjectFromControls<Hose>(EditTableDiv.Controls);
            hose.DateInstall = Request.Form[DATE_INSTALL];
            hose.DateDeinstall = Request.Form[DATE_DEINSTALL];

            DataInsertCache(mark + Hose_num,hose);
            Response.Redirect("~/metalhoses/" + Hose_num);
        }
    }
}