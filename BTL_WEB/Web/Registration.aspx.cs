using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_WEB.Web
{
    public partial class Registration : System.Web.UI.Page
    {
        private String conStr = @"Data Source=.\sqlexpress;Initial Catalog=SendMail;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                load_checkBox();
            }
        }
        private List<int> IDs
        {
            get
            {
                if (this.ViewState["IDs"] == null)
                {
                    this.ViewState["IDs"] = new List<int>();
                }
                return (List<int>)this.ViewState["IDs"];
            }
        }

        private void getChecked()
        {
            foreach (ListViewDataItem item in List_categoties.Items)
            {
                CheckBox chkSelect = (CheckBox)item.FindControl("cb1");
                if (chkSelect != null)
                {
                    int ID = Convert.ToInt32(chkSelect.Attributes["value"]);
                    if (chkSelect.Checked && !this.IDs.Contains(ID + 1))
                    {
                        this.IDs.Add(ID + 1);

                    }
                    else if (!chkSelect.Checked && this.IDs.Contains(ID))
                    {
                        this.IDs.Remove(ID + 1);
                    }
                }
            }
        }

        private Boolean isExist(SqlConnection con)
        {
            int countUser = 0;
            using (SqlCommand cmd = new SqlCommand("countUser", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mail", mail.Text));
                countUser = int.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
            }

            Boolean isExit = countUser != 0 ? true : false;
            return isExit;
        }

        private void insertUser(SqlConnection con)
        {
            int IdUser = 0;
            List<int> categoriesId = new List<int>();
            using (SqlCommand cmd = new SqlCommand("inserUser", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mail", mail.Text));
                cmd.Parameters.Add(new SqlParameter("@name", txtName.Text));
                IdUser = int.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
            }
            con.Open();
            foreach (int item in IDs)
            {
                using (SqlCommand cmd = new SqlCommand("insertUser_Categoy", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@userId", IdUser));
                    cmd.Parameters.Add(new SqlParameter("@categoryId", item));
                    categoriesId.Add(int.Parse(cmd.ExecuteScalar().ToString()));

                }
            }
            con.Close();
            if (categoriesId.Count > 0)
            {
                Response.Write("<script>alert('Đăng kí thành công!')</script>");
                
            }

        }


        private void updateNewCategoryForUser(SqlConnection con)
        {
            using (SqlCommand cmd = new SqlCommand("deleteNhomNguoiDangKyByMail", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mail", mail.Text));
                cmd.ExecuteNonQuery();
                con.Close();
            }

            con.Open();
            foreach (int item in IDs)
            {
                using (SqlCommand cmd = new SqlCommand("insertUser_CategoyByMail", con))
                {
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@mail", mail.Text));
                    cmd.Parameters.Add(new SqlParameter("@categoryId", item));
                    cmd.ExecuteNonQuery();
                    
                }
            }
            Response.Write("<script>alert('Đăng kí thành công!')</script>");
            
            con.Close();

        }
        protected void Submit(object sender, EventArgs e)
        {
            getChecked();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                if (isExist(con))
                {
                    updateNewCategoryForUser(con);
                }
                else
                {
                    insertUser(con);
                }
            }
        }
        private void load_checkBox()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "selectNhom";
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    List_categoties.DataSource = dt;
                    List_categoties.DataBind();
                }
            }
        }
    }
}