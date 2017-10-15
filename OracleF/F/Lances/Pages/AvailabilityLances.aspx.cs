using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lances.Pages {
    public partial class AvailabilityLances : BasePage {
        const string keys_collection = "lance_keys";
        List<Mpk> mpk_list = new List<Mpk>();

        protected void Page_Load(object sender,EventArgs e){
            Repeater1.DataSource = Positions();
            Repeater1.DataBind();
        }

        protected List<Mpk> Positions() {
            IEnumerable<Lance> lances = GetAllCache<Lance>(keys_collection);

            foreach (var lance in lances) {
                //поумолчанию css класс empty
                string[] position = new string[] { "empty", "empty", "empty", "empty", "empty", "empty" };
                int cv_no; int offset = 0;
                Int32.TryParse(lance.Cv_no,out cv_no);
                switch (cv_no) {
                    case 1: offset = 0; break;
                    case 2: offset = 2; break;
                    case 3: offset = 4; break;
                }
                if (lance.Mpk == "правая" && cv_no != 0) ++offset;
                if (cv_no!=0) position[offset] = "instock";
                
                mpk_list.Add(new Mpk { Lance_no = lance.Lance_no, Position = position });
            }
            return mpk_list;
        }

        //dict = OffsetDict();
        //IDictionary<string, int> dict = new Dictionary<string,int>();
        //protected int[] OffsetDict(){
        //    int i = 0; int offset = 0;
        //    while (i < 3){
        //        var key = string.Format("МПК-{0}",++i);
        //        dict[key] = offset; offset += 2;
        //    }
        //    return dict;
        //}

        public class Mpk {
            public string Lance_no { get; set; }
            public Array Position { get; set; }
        }           
    }
}