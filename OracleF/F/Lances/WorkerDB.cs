using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web;
using conf = System.Configuration.ConfigurationManager;

namespace Lances.Pages {

    public class Respon {
        public int Cv_no { get; set; }
        public string Position { get; set; }
        public int Lance_no { get; set; }
        public int Heat_no { get; set; }
        public string Info { get; set; }
    }

    public class WorkerDB {
        private OracleConnection conn;
        private OracleCommand cmd;
        private string conn_str = conf.AppSettings["kpbof"];
        int lance_no, heat_no;

        public Respon CheckWorkPosition(int cv_no,string LR) {

            using (conn = new OracleConnection(conn_str)) {
                conn.Open();
                cmd = conn.CreateCommand(); cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select cv_no, lancesel, lance_no,heat_no from HEAT_ACT where cv_no = :cv_no and lancesel = :LR";
                cmd.Parameters.Add(new OracleParameter("cv_no",cv_no));
                cmd.Parameters.Add(new OracleParameter("LR",LR));
                Respon resp = new Respon();
                using (OracleDataReader r = cmd.ExecuteReader()) {
                    if (r.HasRows)
                        while (r.Read()) {
                            Int32.TryParse(r.GetValue(0).ToString(),out cv_no);
                            Int32.TryParse(r.GetValue(2).ToString(),out lance_no);
                            Int32.TryParse(r.GetValue(3).ToString(),out heat_no);

                            resp.Cv_no = cv_no; resp.Lance_no = lance_no; resp.Heat_no = heat_no;
                            resp.Position = string.Format("{0}",r.GetValue(1));

                            string position_ = string.Format("{0}",resp.Position == "L" ? "левая" : "правая");

                            resp.Info = string.Format("На МПК-{0} в работе {1} фурма №{2}. Плавка №{3}",
                                resp.Cv_no, position_, resp.Lance_no, resp.Heat_no);
                        }
                } return  resp;
            }
        }

        public int GetCurrentHeat(int cv_no){
            using (conn = new OracleConnection(conn_str)) {
                int heat = 0;
                conn.Open();
                cmd = conn.CreateCommand(); cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select heat_no from HEAT_ACT where cv_no = :cv_no";
                cmd.Parameters.Add(new OracleParameter("cv_no",cv_no));
                //cmd.Parameters.Add(new OracleParameter("LR",LR));
                using (OracleDataReader r = cmd.ExecuteReader()) {
                    if (r.HasRows)
                        while (r.Read())
                            Int32.TryParse(r.GetValue(0).ToString(),out heat);
                } return heat;
            }
        }          

        public void DataInsertDB(Lance lance){
            string cv_no = lance.Cv_no; int cv;
            string pos = lance.Mpk;
            int durability;

            if (!string.IsNullOrEmpty(cv_no) && !string.IsNullOrEmpty(pos)) {
                pos = pos == "левая" ? "L" : "R";
                Int32.TryParse(cv_no,out cv);

                Respon resp = CheckWorkPosition(cv,pos);
                if(cv==resp.Cv_no && pos == resp.Position){
                    ReplaceActiveLance();
                }
                // новый наконечник
                if (!string.IsNullOrEmpty(lance.NewTip)) {
                    // обнулить стойкость
                    durability = ZeroDurability();}
                else {
                    // получить предыдущую стойкость
                    durability = GetPrevDurability(); }
                lance.Durability = string.Format("{0}",durability);
                // привязка фурмы к плавке (от которой вести отсчет)
                LanceHeatBind(lance);
            }
        }

        private void LanceHeatBind(Lance lance) {
            using (conn = new OracleConnection(conn_str)) {
                conn.Open(); 
                cmd = conn.CreateCommand(); cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "insert into TEST_LANCE_ACC (lance_no,heat_no,durability) values (:lance_no,:heat_no,:durability)";
                int lance_num, heat_num, dur_num;
                Int32.TryParse(lance.Lance_no,out lance_num);
                Int32.TryParse(lance.FirstHeat, out heat_num);
                Int32.TryParse(lance.Durability,out dur_num);
                cmd.CommandText = "merge into TEST_LANCE_ACC t using dual on(t.lance_no=:lance_no) " +
                    "when matched then update set t.heat_no=:heat_no,t.durability=:durability " +
                    "when not matched then insert (t.lance_no,t.heat_no,t.durability) values (:lance_no,:heat_no,:durability)";
                cmd.Parameters.Add(new OracleParameter("lance_no",lance_num));
                cmd.Parameters.Add(new OracleParameter("heat_no",heat_num));
                cmd.Parameters.Add(new OracleParameter("durability",dur_num));
                int count = cmd.ExecuteNonQuery();
                }
        }

        public BR GetHandBK(){
            using(conn= new OracleConnection(conn_str)) {
                conn.Open();
                cmd = conn.CreateCommand(); cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from TEST_LANCE_BR";
                cmd.Parameters.Add(new OracleParameter());
                int kind;
                List<string> list1 = new List<string>() { };
                List<string> list2 = new List<string>() { };
                using (OracleDataReader r = cmd.ExecuteReader()) {
                    if (r.HasRows)
                        while (r.Read()) {
                            Int32.TryParse(r.GetValue(0).ToString(),out kind);
                            if (kind == 1) list1.Add(string.Format("{0}",r.GetValue(1)));
                            if (kind == 2) list2.Add(string.Format("{0}",r.GetValue(1)));
                        }
                }
                return new BR { Reason = list1,Jobs = list2 };
            }
        }

        private int GetPrevDurability(){ return 50;}
        private int ZeroDurability(){ return 0;}
        private void ReplaceActiveLance(){}
        //public string CountDurability(int lance_no, int first_blow){
        //    using (conn) {
        //        conn.Open();
        //        cmd = conn.CreateCommand(); cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "select count(:lance_no) from heats where heat_no>:first_blow and lance_no=:lance_no order by heat_no desc";
        //        cmd.Parameters.Add(new OracleParameter("lance_no",lance_no));
        //        cmd.Parameters.Add(new OracleParameter("first_blow",first_blow));
        //        using (OracleDataReader reader = cmd.ExecuteReader()) {
        //            if (reader.HasRows)
        //                while (reader.Read()) {
        //                    durability = reader.GetValue(0).ToString();
        //                }
        //        }
        //    }
        //    return durability;
        //}
    }

    public class BR {
        public List<string> Reason { get; set; }
        public List<string> Jobs { get; set; }
    }
}