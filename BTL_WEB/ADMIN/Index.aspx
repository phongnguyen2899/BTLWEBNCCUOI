<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN/HeaderFooterAdmin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BTL_WEB.ADMIN.Index" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <style>
        .fa-plus-circle{
            color:#007bff;
        }
        .fa-edit{
            color:#007bff;
            margin-right:5px;
        }
        .fa-times{
            color:red;
        }
        
        #guitin{
            text-decoration:none;
            margin-bottom:20px;
        }
        .data-table{
            margin-top:20px;
        }
    </style>
   <div>
       <h1>Danh Mục</h1>
       <a id="guitin" href="/ADMIN/Guitin.aspx">Gửi tin</a>

		<div class="data-table">
			<table>
				<tr>
					<th>ID</th>
					<th>Link</th>
					<th>Ngày tạo</th>
                    <th>Nhóm</th>
                    <th>Mô Tả</th>
                    <th>Hành động</th>
				</tr>
                <tbody runat="server" id="List_tin">
                    <tr>
					    <td>aaa</td>
					    <td>aaa</td>
					    <td>aaa</td>
                        <td>aaa</td>
                        <td>aaa</td>
                        <td>
                            <a href="#"><i class="fas fa-edit"></i></a>
                            <a href="#"><i class="fas fa-times"></i></a>
                        </td>
				    </tr>
                </tbody>
			</table>
		</div>
   </div>
</asp:Content>
