using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTL_WEB.DATA
{
    public class Dataprovider
    {
        private string constr = @"Data Source=.\sqlexpress;Initial Catalog=SendMail;Integrated Security=True";
        private static Dataprovider instance; //Ctrl + R + E  (Pattern singleton)

        public static Dataprovider Instance
        {
            get
            {
                if (instance == null)
                    instance = new Dataprovider();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public static object ConfigurationManager { get; private set; }

        private Dataprovider() { }
        public DataTable ExecuteQuery(string query, object[] parameter = null) // Hàm chạy các câu select
        {
            DataTable tb;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int j = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[j]);
                                j++;
                            }
                        }
                    }
                    using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                    {
                        tb = new DataTable();
                        adap.Fill(tb);
                    }
                    cnn.Close();
                }
            }
            return tb;
        }
        public int ExecuteNonQuery(string query, object[] parameter = null) //Hàm khi chạy thủ tục insert, update, delete
        {
            int i;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cnn.Open();
                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int j = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[j]);
                                j++;
                            }
                        }
                    }
                    i = cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
            return i;
        }
    }
}