using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BTL_WEB.ADMIN.Service
{
    public class TinService : ITinService
    {
        public DataTable GetallNhomtin()
        {
            return DATA.Dataprovider.Instance.ExecuteQuery("select *from Nhom");
        }
        public DataTable GetNhombyIdTin(int id)
        {
            return DATA.Dataprovider.Instance.ExecuteQuery("SP_selectNhombyIDtin @ma ", new object[] { id});
        }

        public DataTable GetTin()
        {
            DataTable dt = new DataTable();
            object[] obj = new object[]
            {

            };
            dt = DATA.Dataprovider.Instance.ExecuteQuery(Const.SELECT_TIN);
            return dt;
        }
        
    }
}