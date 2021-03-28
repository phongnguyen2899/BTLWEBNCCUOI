<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN/HeaderFooterAdmin.Master" AutoEventWireup="true" CodeBehind="Danhmuctin.aspx.cs" Inherits="BTL_WEB.ADMIN.Danhmuctin" %>
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
        tr td a{
            margin-right:10px;
        }
        .fa-info{
            color:#007bff;
        }
        .anh{
            max-width:50px;
        }
    </style>
   <div>
       <h1>Danh Mục</h1>
       <a id="guitin" href="/ADMIN/Themmoidanhmuctin.aspx">Thêm Mới</a>

		<div class="data-table">
			<table>
				<tr>
					<th>ID</th>
					<th>Tên Chủ đề</th>
                    <th>Ảnh</th>
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

    <script>
        var url="Danhmuctin.aspx/deletedanhmuc"
        function xoadanhmuc(id) {
            fetch(url, {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({idnhom:id})
            })
                .then(function (response) {
                    return response.json();
                })
                .then(function (data) {
                    if (data.d == "thanh cong") {
                        var deleteelement = document.getElementById(id)
                        var hanhdongelement = deleteelement.parentElement;
                        var tr = hanhdongelement.parentElement;
                        tr.style.display='none'
                    }
                    else {
                        alert("Không thể xóa bản ghi này")
                    }
                })
        }
    </script>
</asp:Content>
