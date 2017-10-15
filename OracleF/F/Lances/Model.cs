using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lances.Pages {
    public class Lance {
        //[Required(ErrorMessage="Поле № фурмы обязательно для заполения")]
        public string Lance_no { get; set; }
        public string Cv_no { get; set; }
        public string Mpk { get; set; }
        public string Tip_no { get; set; }
        public string Tip_comp { get; set; }
        public string Durability { get; set; }
        public string Lance_len { get; set; }
        public string LastHeat { get; set; }
        public string Reper_label { get; set; }
        public string Spec_marks { get; set; }
        public string Reason { get; set; }
        public string Jobs { get; set; }
        //public string First_blow { get; set; }
        public string Dia { get; set; }
        public string Nozzle_wear { get; set; }
        public string Other { get; set; }
        public string DateInstall { get; set; }
        public string DateDeinstall { get; set; }
        public string FirstHeat { get; set; } 
        public string NewTip { get; set; }
    }

    public class Hose{
        public string Hose_no { get; set; }
        public string Cv_no { get; set; }
        public string Mpk { get; set; }
        public string Team { get; set; }
        public string Kind { get; set; }
        public string Durability { get; set; }
        public string DateInstall { get; set; }
        public string DateDeinstall { get; set; }
        public string Jobs { get; set; }
        public string Reason { get; set; }
        public string Part1 { get; set; }
        public string Part2 { get; set; }
        public string Part3 { get; set; }
        public string Part4 { get; set; }
        public string Part5 { get; set; }
        public string Part6 { get; set; }
        public string Part7 { get; set; }
        public string Part8 { get; set; }
    }
}