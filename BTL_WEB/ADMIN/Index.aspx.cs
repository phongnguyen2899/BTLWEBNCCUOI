using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_WEB.ADMIN
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_data();
        }
        private void Load_data()
        {
            string html = "";
            DataTable dt = new DataTable();
            Service.TinService tin = new Service.TinService();
            dt = tin.GetTin();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dt1 = new DataTable();
                int idtin = Int32.Parse(dt.Rows[i]["Id"].ToString());
                dt1 = tin.GetNhombyIdTin(idtin);
                html += "<tr>";
                html += "<td>"+dt.Rows[i]["Id"]+"</td>";
                html += "<td>" + dt.Rows[i]["Link"] + "</td>";
                html += "<td>" + dt.Rows[i]["NgayTao"] + "</td>";
                html += "<td>";
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    html += "<p>" + dt1.Rows[j]["Tenchude"] + "</p>";
                }
                html += "</td>";
                html += "<td>" + dt.Rows[i]["Mota"] + "</td>";
                html += "<td>";
                html += "<a href=\"ADMIN/Index.aspx?\"><i class=\"fas fa-edit\"></i></a>";
                html += "<a href=\"#\"><i class=\"fas fa-times\"></i></a>";
                html += "</td>";
                html += "</tr>";
            }
            List_tin.InnerHtml = html;
        }
    }
}