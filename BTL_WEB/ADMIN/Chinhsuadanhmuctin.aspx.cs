using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_WEB.ADMIN
{
    public partial class Chinhsuadanhmuctin : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
             id =Int32.Parse(Request.QueryString["editid"].ToString());
            if (!IsPostBack)
            {
                loaddata(id);
            }
            

        }
        private void loaddata(int id)
        {
            DataTable dt = DATA.Dataprovider.Instance.ExecuteQuery("select *from Nhom where Id="+id+"");
            tenchudecs.Value = dt.Rows[0]["Tenchude"].ToString();
            anhcu.Src = "Image/" + dt.Rows[0]["img"] + "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var chude = tenchudecs.Value;
            //Nếu file ko thay đổi
            if (filedanhmuc.HasFile == false)
            {
                DATA.Dataprovider.Instance.ExecuteNonQuery("SP_updatenhomNofile @id , @ten ", new object[] {id, chude });
                Response.Redirect("Danhmuctin.aspx");
            }
            //neu co xay ra thay doi file
            else
            {
                string fileName = filedanhmuc.FileName;
                filedanhmuc.SaveAs(Server.MapPath("Image/") + fileName);
                //xoa file cu di

                DataTable dt = DATA.Dataprovider.Instance.ExecuteQuery("select *from Nhom where Id=" + Int32.Parse(Request.QueryString["editid"].ToString()) + "");
                var filePath = System.Web.HttpContext.Current.Server.MapPath("/ADMIN/Image/" + dt.Rows[0]["img"]);
                System.IO.File.Delete(filePath);

                //update vao csdl
                var result = DATA.Dataprovider.Instance.ExecuteNonQuery("SP_updatenhomHavefile @id , @ten , @file ", new object[] { id,chude, fileName });
                if (result > 0)
                {
                    Response.Redirect("Danhmuctin.aspx");
                }
            }
        }
    }
}