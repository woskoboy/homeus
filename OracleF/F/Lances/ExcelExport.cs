using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using OfficeOpenXml;
using System.ComponentModel;
using System.Drawing;
using OfficeOpenXml.Style;
using System.IO;

namespace Lances.Pages {
    class ExcelExport : BasePage {
        const string keys_collection = "lance_keys";
        public string Start<T>(){
            IEnumerable<T> collection = GetAllCache<T>(keys_collection);
            if (collection.Count() > 0)
                return CreateExcel(collection);
            else return "";
        }
        public string CreateExcel<T>(IEnumerable<T> collection){
            string path = Server.MapPath(string.Format(@"~/docs/{0}.xlsx",
                    DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss")));

            int row = 1;
            using (ExcelPackage pack = new ExcelPackage()) {
                ExcelWorksheet ws = pack.Workbook.Worksheets.Add("Sheet1");
                int col = 0;
                foreach (PropertyDescriptor header in TypeDescriptor.GetProperties(collection.First())) {
                    ws.Cells[row,++col].Value = header.Name;
                }
                ws.Cells[1,1,1,col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells[1,1,1,col].Style.Fill.BackgroundColor.SetColor(Color.LightGreen);

                foreach (T obj in collection) {
                    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);
                    ++row; int i = 0;
                    foreach (PropertyDescriptor prop in properties) {
                        ws.Cells[row,++i].Value = prop.GetValue(obj);
                    }
                }
                ws.Cells[1,1,row,col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                FileInfo f = new FileInfo(path);
                pack.SaveAs(f);
                return "file://"+path;
                //dic.Add(prop.Name,string.Format("{0}",prop.GetValue(obj)));
            }
        }
    }
}