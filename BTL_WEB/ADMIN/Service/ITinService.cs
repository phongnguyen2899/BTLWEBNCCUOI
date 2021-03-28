using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BTL_WEB.ADMIN.Service
{
    public interface ITinService
    {
        DataTable GetTin();
        DataTable GetNhombyIdTin(int id);
        DataTable GetallNhomtin();
    }
}