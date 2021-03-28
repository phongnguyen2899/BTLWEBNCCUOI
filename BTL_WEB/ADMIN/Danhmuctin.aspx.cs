using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_WEB.ADMIN
{
    public partial class Danhmuctin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                loaddata();
            }
            else
            {
                Response.Redirect("401.aspx");
            }
            
        }
        private void loaddata()
        {
            DataTable dt = DATA.Dataprovider.Instance.ExecuteQuery("select *from Nhom");
            string html = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html+="<tr>";
                html += "<td>"+dt.Rows[i]["Id"]+"</td>";
                html += "<td>" + dt.Rows[i]["Tenchude"] + "</td>";
                html += "<td>"+"<img class=\"anh\" src='Image/"+dt.Rows[i]["img"]+"'>"+"</td>";
                html += "<td>";
                html += "<a href=\"/ADMIN/Chitietdanhmuctin.aspx?id="+dt.Rows[i]["Id"]+"\"><i class=\"fas fa-info\"></i></a>";
                html += "<a href=\"/ADMIN/Chinhsuadanhmuctin.aspx?editid="+dt.Rows[i]["Id"]+"\"><i class=\"fas fa-edit\"></i></a>";
                html += "<a id="+dt.Rows[i]["id"]+"  href=\"javascript:xoadanhmuc('"+dt.Rows[i]["Id"]+"')\"><i class=\"fas fa-times\"></i></a>";
                html += "</td>";
                html += "</tr>";

            }
            List_tin.InnerHtml = html;
        }

        [WebMethod,ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        public static string deletedanhmuc(int idnhom)
        {
            try
            {
                //Lay anh ra truoc khi xoa
                DataTable dt = DATA.Dataprovider.Instance.ExecuteQuery("select *from Nhom where Id=" + idnhom + "");
                int reslut = DATA.Dataprovider.Instance.ExecuteNonQuery("SP_deletenhom @id", new object[] { idnhom });
                if (reslut > 0)
                {
                    var filePath = System.Web.HttpContext.Current.Server.MapPath("/ADMIN/Image/" + dt.Rows[0]["img"]);
                    System.IO.File.Delete(filePath);
                    return "thanh cong";
                }
                return "that bai";
            }
            catch
            {
                return "that bai";
            }
        }
    }
}