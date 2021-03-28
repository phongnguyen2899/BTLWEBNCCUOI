using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_WEB.ADMIN
{
    public partial class Themmoidanhmuctin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ten = tenchude.Value;
            string fileName = filedanhmuc.FileName;
            if (filedanhmuc != null)
            {
                filedanhmuc.SaveAs(Server.MapPath("Image/") + fileName);
            }
           var result= DATA.Dataprovider.Instance.ExecuteNonQuery("SP_insertnhom @tenchude , @file ",new object[] {ten,fileName });
            if (result > 0)
            {
                Response.Redirect("Danhmuctin.aspx");
            }
        }
    }
}