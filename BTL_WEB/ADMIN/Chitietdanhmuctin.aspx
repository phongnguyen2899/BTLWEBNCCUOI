<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN/HeaderFooterAdmin.Master" AutoEventWireup="true" CodeBehind="Chitietdanhmuctin.aspx.cs" Inherits="BTL_WEB.ADMIN.Chitietdanhmuctin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
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
					<th>Tên Chủ đề</th>
                    <th>Email</th>
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
                            <a href="#"><i class="fas fa-info"></i></a>
                            <a href="#"><i class="fas fa-edit"></i></a>
                            <a href="#"><i class="fas fa-times"></i></a>
                        </td>
				    </tr>
                </tbody>
			</table>
		</div>
   </div>
</asp:Content>
