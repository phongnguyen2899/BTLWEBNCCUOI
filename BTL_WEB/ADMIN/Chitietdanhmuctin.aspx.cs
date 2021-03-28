using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_WEB.ADMIN
{
    public partial class Chitietdanhmuctin : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int id =Int32.Parse(Request.QueryString["id"]);
            loaddata(id);
            
        }
        private void loaddata(int id)
        {
            DataTable dt = DATA.Dataprovider.Instance.ExecuteQuery("SP_selectuserbyidnhom @id ", new object[] { id });
            var html = "";
            for(var i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td>" + dt.Rows[i]["Id"] + "</td>";
                html += "<td>" + dt.Rows[i]["Ten"] + "</td>";
                html += "<td>" + dt.Rows[i]["Email"] + "</td>";

                html += "</tr>";
            }
            List_tin.InnerHtml = html;
        }

    }
}