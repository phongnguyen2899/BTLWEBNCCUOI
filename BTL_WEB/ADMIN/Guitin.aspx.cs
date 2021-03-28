using BTL_WEB.ADMIN.Service;
using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_WEB.ADMIN
{
    public partial class Guitin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        private void loaddata()
        {
            string html = "";
            DataTable dt = new TinService().GetallNhomtin();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<div class=\"checkbox-item\">";
                html+= "<input class=\"nhom\" name=\"nhom\" value=\""+dt.Rows[i]["Id"]+"\" type=\"checkbox\"/>";
                html += "<label>"+dt.Rows[i]["Tenchude"]+"</label>";
                html += "</div>";
            }
            list_checkbox.InnerHtml = html;
        }

        [WebMethod]
        public static string num(string a,string b)
        {
            return (Convert.ToInt32(a) + Convert.ToInt32(b)).ToString();
        }
        [WebMethod]
        public static string sendmail(string nhom, string url)
        {
            int idnhom = Int32.Parse(nhom);
            DataTable dt = DATA.Dataprovider.Instance.ExecuteQuery("SP_selectEmailbynhom @idnhom ", new object[] { idnhom});
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                Mailhelper.SendMail("" + dt.Rows[i]["Email"] + "", "gui mail", url);
            }
            return "thanh cong";
        }
        
  
    }
}