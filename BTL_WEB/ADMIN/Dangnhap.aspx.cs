using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_WEB.ADMIN
{
    public partial class Dangnhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var thaotac = Request.QueryString["thaotac"];
            switch (thaotac)
            {
                case "dangxuat":
                    Session["user"] = null;
                    break;
            }
        }

        

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string taikhoan = username.Value;
            string matkhau = password.Value;
            DataTable dt = DATA.Dataprovider.Instance.ExecuteQuery("select *from Taikhoan where Taikhoan='" + taikhoan + "' and Matkhau='" + matkhau + "'");
            if (dt.Rows.Count > 0)
            {
                Session["user"] = dt.Rows[0]["Taikhoan"];
                Response.Redirect("Danhmuctin.aspx");
            }
        }
    }
}